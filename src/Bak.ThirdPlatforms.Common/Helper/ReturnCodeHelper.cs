using Microsoft.Extensions.Configuration;
using System.IO;

namespace Bak.ThirdPlatforms.Common.Helper
{
    /// <summary>
    /// 错误码处理
    /// </summary>
    public class ReturnCodeHelper
    {
        private static readonly IConfigurationRoot _config;

        static ReturnCodeHelper()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "Resources"))
                .AddJsonFile("returncodes.json", true, true);
            _config = builder.Build();
        }

        public static string Description(string code) => _config[code];
    }
}
