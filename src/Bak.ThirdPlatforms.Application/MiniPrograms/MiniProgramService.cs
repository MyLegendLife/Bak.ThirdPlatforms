using Bak.ThirdPlatforms.Application.Contracts.Auths;
using Bak.ThirdPlatforms.Application.Contracts.MiniPrograms;
using Bak.ThirdPlatforms.Common.Base;
using Bak.ThirdPlatforms.Common.Extensions;
using Bak.ThirdPlatforms.Domain.MiniPrograms;
using Bak.ThirdPlatforms.Domain.MiniPrograms.Repositories;
using Bak.ThirdPlatforms.Domain.Settings;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Bak.ThirdPlatforms.Domain.Auths.Repositories;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using static Bak.ThirdPlatforms.Domain.Shared.ThirdPlatformsConsts;

namespace Bak.ThirdPlatforms.Application.MiniPrograms
{
    public class MiniProgramService : ApplicationService, IMiniProgramService
    {
        private readonly IFactorService _factorService;
        private readonly IAuthorizerService _authorizerService;
        private readonly IAuthorizerRepository _authorizerRepository;
        private readonly IMiniProgramRecordRepository _miniProgramRecordRepository;
        private readonly IHttpClientFactory _httpClientFactory;

        public MiniProgramService(
            IHttpClientFactory httpClientFactory, 
            IMiniProgramRecordRepository miniProgramRecordRepository, 
            IAuthorizerService authorizerService, 
            IFactorService factorService, 
            IAuthorizerRepository authorizerRepository)
        {
            _httpClientFactory = httpClientFactory;
            _miniProgramRecordRepository = miniProgramRecordRepository;
            _authorizerService = authorizerService;
            _factorService = factorService;
            _authorizerRepository = authorizerRepository;
        }

        /// <summary>
        /// 创建小程序
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ServiceResult<string>> FastRegisterAsync(MiniProgramRegisterInput input)
        {
            var result = new ServiceResult<string>();

            var record = await _miniProgramRecordRepository.FindAsync(x => x.code.Equals(input.code));
            if (record != null)
            {
                result.IsFailed("该商户已创建过小程序");
                return result;
            }

            var accessToken = await _factorService.GetAccessTokenAsync();

            if (string.IsNullOrWhiteSpace(accessToken))
            {
                result.IsFailed("获取令牌失败");
                return result;
            }

            var client = _httpClientFactory.CreateClient();

            var content = new StringContent(input.ToJson());

            var response = await client.PostAsync(UrlsConfig.MiniProgram.FastRegisterCreate.FormatWith(accessToken), content);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                var jObj = json.ToJObject();

                var code = jObj["errcode"]?.ToString();
                var msg = code?.ToDescription();

                #region 保存记录

                if (code == "0")
                {
                    result.IsSuccess(code + ":" + msg);

                    var entity = ObjectMapper.Map<MiniProgramRegisterInput, MiniProgramRecord>(input);
                    entity.errcode = code;
                    entity.errmsg = msg;
                    await _miniProgramRecordRepository.InsertAsync(entity);
                }
                else
                {
                    result.IsFailed(code + ":" + msg);
                }

                #endregion
            }
            else
            {
                result.IsFailed(ResponseText.ERR_NETWORK);
            }

            return result;
        }

        /// <summary>
        /// 查询创建任务状态
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ServiceResult<string>> RegisterSearchAsync(MiniProgramSearchInput input)
        {
            var result = new ServiceResult<string>();

            var accessToken = await _factorService.GetAccessTokenAsync();

            var client = _httpClientFactory.CreateClient();

            var content = new StringContent(input.ToJson());

            var response = await client.PostAsync(UrlsConfig.MiniProgram.FastRegisterSearch.FormatWith(accessToken), content);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                var jObj = json.ToJObject();

                var code = jObj["errcode"]?.ToString();
                var msg = code?.ToDescription();

                #region 更新记录

                var entity = await _miniProgramRecordRepository.FindAsync(x => x.legal_persona_wechat.Equals(input.legal_persona_wechat));
                if (entity.IsNotNull())
                {
                    entity.errcode = code;
                    entity.errmsg = msg;
                    await _miniProgramRecordRepository.UpdateAsync(entity);
                }

                #endregion

                result.IsSuccess(code + ":" + msg);
            }
            else
            {
                result.IsFailed(ResponseText.ERR_NETWORK);
            }

            return result;
        }

        /// <summary>
        /// 申请开通直播
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResult<string>> ApplyLiveAsync(string authorizerAppId)
        {
            var result = new ServiceResult<string>();

            var entity = await _authorizerRepository.FindAsync(x => x.authorizer_appid.Equals(authorizerAppId));

            var authAccessToken = "";

            //如果令牌过期，则请求新的令牌
            if (Clock.Now > entity.ExpireTime.AddMinutes(-10))
            {
                authAccessToken = (await _authorizerService.UpdateAccessTokenAsync(authorizerAppId)).Result;
            }
            else
            {
                authAccessToken = entity.authorizer_access_token;
            }

            var client = _httpClientFactory.CreateClient();

            var content = new StringContent("\"action:\":\"apply\"");

            var response = await client.PostAsync(UrlsConfig.MiniProgram.ApplyLive.FormatWith(authAccessToken), content);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                var obj = json.ToJObject();

                var errCode = obj["errcode"]?.ToString();

                var message = errCode + ":" + errCode.ToDescription();

                #region 保存申请记录

                #endregion

                result.IsSuccess(message);
            }
            else
            {
                result.IsFailed(ResponseText.ERR_NETWORK);
            }

            return result;
        }

        /// <summary>
        /// 查询小程序创建记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ServiceResult<PagedResultDto<MiniProgramRecordDto>>> RecordAsync(PagedAndSortedResultRequestDto input)
        {
            var result = new ServiceResult<PagedResultDto<MiniProgramRecordDto>>();

            var count = await _miniProgramRecordRepository.GetCountAsync();

            var list = await _miniProgramRecordRepository.GetPagedListAsync(input.SkipCount, input.MaxResultCount, input.Sorting);

            result.IsSuccess(new PagedResultDto<MiniProgramRecordDto>
            {
                TotalCount = count,
                Items = ObjectMapper.Map<List<MiniProgramRecord>, List<MiniProgramRecordDto>>(list)
            });

            return result;
        }
    }
}