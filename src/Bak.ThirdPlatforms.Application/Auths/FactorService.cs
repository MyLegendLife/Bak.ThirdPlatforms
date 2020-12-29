using Bak.ThirdPlatforms.Application.Contracts.Auths;
using Bak.ThirdPlatforms.Common.Extensions;
using Bak.ThirdPlatforms.Domain.Auths.Repositories;
using Bak.ThirdPlatforms.Domain.Base;
using Bak.ThirdPlatforms.Domain.Settings;
using Bak.ThirdPlatforms.Domain.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Bak.ThirdPlatforms.Application.Auths
{
    public class FactorService : ApplicationService, IFactorService
    {
        private readonly IFactorRepository _factorRepository;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IRepository<ThirdTicket> _thirdTicketRepository;

        public FactorService(IFactorRepository factorRepository,
            IHttpClientFactory httpClientFactory, IRepository<ThirdTicket> thirdTicketRepository)
        {
            _factorRepository = factorRepository;
            _httpClientFactory = httpClientFactory;
            _thirdTicketRepository = thirdTicketRepository;
        }

        /// <summary>
        /// 获取令牌
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetAccessTokenAsync()
        {
            var value = "";

            var entity = await _factorRepository.FindAsync(x => x.Type.Equals(FactorType.AccessToken));

            if (Clock.Now > entity.ExpireTime.AddMinutes(-10))
            {
                var body = new
                {
                    component_appid = AppSettings.Weixin.AppId,
                    component_appsecret = AppSettings.Weixin.AppSecret,
                    component_verify_ticket = (await _thirdTicketRepository.FirstOrDefaultAsync()).Ticket
                };

                var client = _httpClientFactory.CreateClient();
                var content = new StringContent(body.ToJson());

                var response = await client.PostAsync(UrlsConfig.GetAccessToken, content);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    var jObj = json.ToJObject();

                    var accessToken = jObj["component_access_token"]?.ToString();

                    if (!string.IsNullOrWhiteSpace(accessToken))
                    {
                        value = accessToken;

                        entity.Vaule = accessToken;
                        entity.ExpireTime = Clock.Now.AddSeconds(jObj["expires_in"].TryToInt());
                        await _factorRepository.UpdateAsync(entity);
                    }
                }
            }
            else
            {
                value = entity.Vaule;
            }

            return value;
        }

        /// <summary>
        /// 获取预授权码
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetPreAuthCode()
        {
            var value = "";

            var entity = await _factorRepository.FindAsync(x => x.Type.Equals(FactorType.PreAuthCode));

            if (Clock.Now > entity.ExpireTime.AddMinutes(-1))
            {
                var accessToken = await GetAccessTokenAsync();

                if (string.IsNullOrWhiteSpace(accessToken)) return "";

                var client = _httpClientFactory.CreateClient();

                var content = new StringContent("{" + $"\"component_appid\":\"{AppSettings.Weixin.AppId}\"" + "}");

                var response = await client.PostAsync(UrlsConfig.CreatePreAuthCode.FormatWith(accessToken), content);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    var jObj = json.ToJObject();

                    var ticket = jObj["pre_auth_code"]?.ToString();

                    if (!string.IsNullOrWhiteSpace(ticket))
                    {
                        value = ticket;

                        entity.Vaule = ticket;
                        entity.ExpireTime = Clock.Now.AddSeconds(jObj["expires_in"].TryToInt());
                        await _factorRepository.UpdateAsync(entity);
                    }
                }
            }
            else
            {
                value = entity.Vaule;
            }

            return value;
        }
    }
}