using System.ComponentModel;

namespace Bak.ThirdPlatforms.Domain.Shared.Enums
{
    public enum FactorType
    {
        [Description("第三方令牌")]
        AccessToken = 0,

        [Description("预授权码")]
        PreAuthCode = 1
    }
}
