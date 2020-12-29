using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Bak.ThirdPlatforms.Domain.Shared.Enums
{
    public enum OrderType
    {
        [Description("美团")]
        Meituan = 0,

        [Description("饿了么")]
        Eleme = 1,
    }
}
