using Microsoft.Extensions.Configuration;
using System.IO;

namespace Bak.ThirdPlatforms.Common.Extensions
{
    /// <summary>
    /// 返回码扩展类
    /// </summary>
    public static class ReturnCodeExtensions
    {
        private static readonly IConfigurationRoot _config;

        static ReturnCodeExtensions()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "Resources"))
                .AddJsonFile("returncodes.json", true, true);

            _config = builder.Build();
        }

        /// <summary>
        /// 获取错误码描述信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string ToDescription(this string code)
        {
            return _config[code];
        }
    }
}
