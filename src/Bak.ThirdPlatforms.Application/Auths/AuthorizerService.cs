using Bak.ThirdPlatforms.Application.Contracts.Auths;
using Bak.ThirdPlatforms.Common.Base;
using Bak.ThirdPlatforms.Common.Extensions;
using Bak.ThirdPlatforms.Domain.Auths;
using Bak.ThirdPlatforms.Domain.Auths.Repositories;
using Bak.ThirdPlatforms.Domain.Settings;
using Bak.ThirdPlatforms.Domain.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Bak.ThirdPlatforms.Application
{
    public class AuthorizerService : ApplicationService, IAuthorizerService
    {
        private readonly IFactorService _factorService;
        private readonly IAuthorizerRepository _authorizerRepository;
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthorizerService(IAuthorizerRepository authorizerRepository,
            IFactorService factorService,
            IHttpClientFactory httpClientFactory)
        {
            _authorizerRepository = authorizerRepository;
            _factorService = factorService;
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// 创建授权页面地址
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResult<string>> CreateAuthPageAsync(string redirectUrl)
        {
            var result = new ServiceResult<string>();

            var preAuthCode = await _factorService.GetPreAuthCode();

            if (string.IsNullOrWhiteSpace(preAuthCode))
            {
                result.IsFailed("获取预授权码失败");
                return result;
            }

            var url = UrlsConfig.ComponentLoginPage.FormatWith(AppSettings.Weixin.AppId, preAuthCode, redirectUrl, 3);

            result.IsSuccess(url);

            return result;
        }

        /// <summary>
        /// 创建授权者
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResult> CreateAsync(string authCode, int expiresIn)
        {
            var result = new ServiceResult();

            var accessToken = await _factorService.GetAccessTokenAsync();

            var client = _httpClientFactory.CreateClient();
            var body = new
            {
                component_appid = AppSettings.Weixin.AppId,
                authorization_code = authCode
            };

            var content = new StringContent(body.ToJson());

            var response = await client.PostAsync(UrlsConfig.QueryAuth.FormatWith(accessToken), content);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                var jObj = json.ToJObject();

                //获取授权信息失败错误信息
                if (jObj["errcode"] != null)
                {
                    result.IsFailed(jObj["errcode"]?.ToString().ToDescription());
                    return result;
                }

                var jObjChild = jObj["authorization_info"]?.ToString().ToJObject();
                if (jObjChild != null)
                {
                    var authorizerAppid = jObjChild["authorizer_appid"]?.ToString();
                    var entity = await _authorizerRepository.FirstOrDefaultAsync(x => x.authorizer_appid.Equals(authorizerAppid));
                    
                    if (entity == null)
                    {
                        entity = new Authorizer()
                        {
                            authorizer_appid = jObjChild["authorizer_appid"]?.ToString(),
                            authorizer_access_token = jObjChild["authorizer_access_token"]?.ToString(),
                            authorizer_refresh_token = jObjChild["authorizer_refresh_token"]?.ToString(),
                            ExpireTime = Clock.Now.AddSeconds(jObjChild["expires_in"].TryToInt())
                        };
                        await _authorizerRepository.InsertAsync(entity);
                    }
                    else
                    {
                        entity.authorizer_appid = jObjChild["authorizer_appid"]?.ToString();
                        entity.authorizer_access_token = jObjChild["authorizer_access_token"]?.ToString();
                        entity.authorizer_refresh_token = jObjChild["authorizer_refresh_token"]?.ToString();
                        entity.ExpireTime = Clock.Now.AddSeconds(jObjChild["expires_in"].TryToInt());
                        await _authorizerRepository.UpdateAsync(entity);
                    }

                   
                    result.IsSuccess();

                    await UpdateAsync(entity.authorizer_appid);
                }
            }
            else
            {
                result.IsFailed(ThirdPlatformsConsts.ResponseText.ERR_NETWORK);
            }

            return result;
        }

        /// <summary>
        /// 更新授权者信息
        /// </summary>
        /// <param name="authorizerAppid"></param>
        /// <returns></returns>
        public async Task<ServiceResult> UpdateAsync(string authorizerAppId)
        {
            var result = new ServiceResult();

            var accessToken = await _factorService.GetAccessTokenAsync();

            var entity = await _authorizerRepository.FindAsync(x => x.authorizer_appid.Equals(authorizerAppId));

            if (entity == null)
            {
                result.IsFailed();
                return result;
            }

            var client = _httpClientFactory.CreateClient();
            var body = new
            {
                component_appid = AppSettings.Weixin.AppId,
                authorizer_appid = authorizerAppId
            };

            var content = new StringContent(body.ToJson());

            var response = await client.PostAsync(UrlsConfig.GetAuthorizerInfo.FormatWith(accessToken), content);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                var jObj = json.ToJObject();

                var jObjChild = jObj["authorizer_info"]?.ToString().ToJObject();
                if (jObjChild != null)
                {

                    entity.nick_name = jObjChild["nick_name"]?.ToString();
                    entity.head_img = jObjChild["head_img"]?.ToString();
                    entity.user_name = jObjChild["user_name"]?.ToString();
                    entity.principal_name = jObjChild["principal_name"]?.ToString();

                    await _authorizerRepository.UpdateAsync(entity);

                    result.IsSuccess();
                }
            }
            else
            {
                result.IsFailed(ThirdPlatformsConsts.ResponseText.ERR_NETWORK);
            }

            return result;
        }

        /// <summary>
        /// 更新令牌
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResult<string>> UpdateAccessTokenAsync(string authorizerAppid)
        {
            var result = new ServiceResult<string>();

            var accessToken = await _factorService.GetAccessTokenAsync();

            var entity = await _authorizerRepository.FindAsync(x => x.authorizer_appid.Equals(authorizerAppid));

            if (entity == null)
            {
                result.IsFailed();
                return result;
            }

            var client = _httpClientFactory.CreateClient();
            var body = new
            {
                component_appid = AppSettings.Weixin.AppId,
                authorizer_appid = authorizerAppid,
                authorizer_refresh_token = entity.authorizer_refresh_token
            };

            var content = new StringContent(body.ToJson());

            var response = await client.PostAsync(UrlsConfig.AuthorizerToken.FormatWith(accessToken), content);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                var jObj = json.ToJObject();

                entity.authorizer_access_token = jObj["authorizer_access_token"]?.ToString();
                entity.authorizer_refresh_token = jObj["authorizer_refresh_token"]?.ToString();
                entity.ExpireTime = Clock.Now.AddSeconds(jObj["expires_in"].TryToInt());

                await _authorizerRepository.UpdateAsync(entity);

                result.IsSuccess(entity.authorizer_access_token);
            }

            return result;
        }

        /// <summary>
        /// 查询授权者
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ServiceResult<PagedResultDto<AuthorizerDto>>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var result = new ServiceResult<PagedResultDto<AuthorizerDto>>();

            var count = await _authorizerRepository.GetCountAsync();

            var list = await _authorizerRepository.GetPagedListAsync(input.SkipCount, input.MaxResultCount, input.Sorting);

            result.IsSuccess(new PagedResultDto<AuthorizerDto>
            {
                TotalCount = count,
                Items = ObjectMapper.Map<List<Authorizer>, List<AuthorizerDto>>(list)
            });

            return result;
        }
    }
}