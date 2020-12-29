using Bak.ThirdPlatforms.Domain.Shared.Enums;

namespace Bak.ThirdPlatforms.Application.Contracts.MiniPrograms
{
    public class MiniProgramRegisterInput
    {
        /// <summary>
        /// 企业名（需与工商部门登记信息一致）
        /// </summary>
        public virtual string name { get; set; }

        /// <summary>
        /// 企业代码
        /// </summary>
        public virtual string code { get; set; }

        /// <summary>
        /// 企业代码类型
        /// </summary>
        public virtual CodeType code_type { get; set; }

        /// <summary>
        /// 法人微信号
        /// </summary>
        public virtual string legal_persona_wechat { get; set; }

        /// <summary>
        /// 法人姓名（绑定银行卡）
        /// </summary>
        public virtual string legal_persona_name { get; set; }

        /// <summary>
        /// 第三方联系电话
        /// </summary>
        public virtual string component_phone { get; set; }
    }
}
