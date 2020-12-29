using System;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Bak.ThirdPlatforms.Application.Contracts.Auths
{
    /// <summary>
    /// 授权方信息
    /// </summary>
    public class AuthorizerCreateDto
    {
        public virtual string authorizer_appid { get; set; }

        public virtual string authorizer_access_token { get; set; }

        public virtual string authorizer_refresh_token { get; set; }

        public virtual DateTime ExpireTime { get; set; }
    }
}
