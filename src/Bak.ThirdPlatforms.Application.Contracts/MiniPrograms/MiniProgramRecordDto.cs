using System;
using Bak.ThirdPlatforms.Domain.Shared.Enums;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;

namespace Bak.ThirdPlatforms.Application.Contracts.MiniPrograms
{
    public class MiniProgramRecordDto : EntityDto<int>, IHasCreationTime,IHasModificationTime
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