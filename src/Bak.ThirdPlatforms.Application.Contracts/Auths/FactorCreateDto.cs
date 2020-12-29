using Bak.ThirdPlatforms.Domain.Shared.Enums;
using System;

namespace Bak.ThirdPlatforms.Application.Contracts.Auths
{
    /// <summary>
    /// 授权基础要素
    /// </summary>
    public class FactorCreateDto
    {
        public virtual FactorType Type { get; set; }

        public virtual string Vaule { get; set; }

        public virtual DateTime ExpireTime { get; set; }
    }
}
