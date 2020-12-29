using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;

namespace Bak.ThirdPlatforms.Application.Contracts.MiniPrograms
{
    public class MiniProgramRecordCreateDto
    {
        public virtual string Name { get; set; }

        public virtual string Code { get; set; }

        public virtual string CodeType { get; set; }

        public virtual string LegalPersonaWechat { get; set; }

        public virtual string LegalPersonaName { get; set; }

        public virtual string ComponentPhone { get; set; }

        public virtual string ErrCode { get; set; }

        public virtual string ErrMsg { get; set; }
    }
}