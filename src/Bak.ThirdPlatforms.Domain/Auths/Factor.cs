using Bak.ThirdPlatforms.Domain.Shared.Enums;
using System;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Bak.ThirdPlatforms.Domain.Auths
{
    /// <summary>
    /// 授权基础要素
    /// </summary>
    public class Factor : Entity<int>
    {
        public virtual FactorType Type { get; set; }

        public virtual string Vaule { get; set; }

        public virtual DateTime ExpireTime { get; set; }
    }
}
