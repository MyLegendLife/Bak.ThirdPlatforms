using System;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Bak.ThirdPlatforms.Application.Contracts.Auths
{
    /// <summary>
    /// 授权方信息
    /// </summary>
    public class AuthorizerDto : Entity<int>, IHasCreationTime, IHasModificationTime
    {
        public virtual string authorizer_appid { get; set; }

        public virtual string nick_name { get; set; }

        public virtual string head_img { get; set; }

        public virtual string user_name { get; set; }

        public virtual string principal_name { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime? LastModificationTime { get; set; }
    }
}
