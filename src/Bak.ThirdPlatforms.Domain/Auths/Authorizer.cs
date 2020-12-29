using System;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Bak.ThirdPlatforms.Domain.Auths
{
    /// <summary>
    /// 授权方信息
    /// </summary>
    public class Authorizer : Entity<int>, IHasCreationTime, IHasModificationTime
    {
        public virtual string authorizer_appid { get; set; }

        public virtual string nick_name { get; set; }

        public virtual string head_img { get; set; }

        public virtual string user_name { get; set; }

        public virtual string principal_name { get; set; }

        public virtual string authorizer_access_token { get; set; }

        public virtual string authorizer_refresh_token { get; set; }

        public virtual DateTime ExpireTime { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime? LastModificationTime { get; set; }
    }
}
