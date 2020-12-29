using Bak.ThirdPlatforms.Domain.Shared.Enums;
using System;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Bak.ThirdPlatforms.Domain.MiniPrograms
{
    /// <summary>
    /// 小程序创建记录
    /// </summary>
    public class MiniProgramRecord : Entity<int>,IHasCreationTime,IHasModificationTime
    {
        public virtual string name { get; set; }

        public virtual string code { get; set; }

        public virtual CodeType code_type { get; set; }

        public virtual string legal_persona_wechat { get; set; }

        public virtual string legal_persona_name { get; set; }

        public virtual string component_phone { get; set; }

        public virtual string errcode { get; set; }

        public virtual string errmsg { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime? LastModificationTime { get; set; }
    }
}