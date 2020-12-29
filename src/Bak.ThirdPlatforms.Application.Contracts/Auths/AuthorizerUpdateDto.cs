using System;
using Volo.Abp.Auditing;

namespace Bak.ThirdPlatforms.Application.Contracts.Auths
{
    /// <summary>
    /// 授权方信息
    /// </summary>
    public class AuthorizerUpdateDto
    {
        public virtual string authorizer_appid { get; set; }

        public virtual string nick_name { get; set; }

        public virtual string head_img { get; set; }

        public virtual string user_name { get; set; }

        public virtual string principal_name { get; set; }

        public virtual string authorizer_access_token { get; set; }

        public virtual DateTime ExpireTime { get; set; }
    }
}
