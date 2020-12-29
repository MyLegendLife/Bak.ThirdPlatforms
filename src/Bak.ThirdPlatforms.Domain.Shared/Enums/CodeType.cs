using System.ComponentModel;

namespace Bak.ThirdPlatforms.Domain.Shared.Enums
{
    /// <summary>
    /// 企业代码类型
    /// </summary>
    public enum CodeType
    {
        [Description("统一社会信用代码（18 位）")]
        credit = 1,

        [Description("组织机构代码（9 位 xxxxxxxx-x）")]
        organizing = 2,

        [Description("营业执照注册号（15 位）")]
        license = 3,
    }
}