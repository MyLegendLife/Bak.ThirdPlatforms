namespace Bak.ThirdPlatforms.Application.Contracts.MiniPrograms
{
    public class MiniProgramSearchInput
    {
        /// <summary>
        /// 企业名（需与工商部门登记信息一致）
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 法人微信号
        /// </summary>
        public string legal_persona_wechat { get; set; }

        /// <summary>
        /// 法人姓名（绑定银行卡）
        /// </summary>
        public string legal_persona_name { get; set; }
    }
}
