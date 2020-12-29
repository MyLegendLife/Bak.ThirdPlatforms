using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bak.ThirdPlatforms.Domain.Settings
{
    /// <summary>
    /// appsettings.json配置文件数据读取类
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// 配置文件的根节点
        /// </summary>
        private static readonly IConfigurationRoot _config;

        /// <summary>
        /// 静态构造函数，加载appsettings.json，并构建IConfigurationRoot
        /// </summary>
        static AppSettings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true);

            _config = builder.Build();
        }

        /// <summary>
        /// Api版本
        /// </summary>
        public static string ApiVersion => _config["ApiVersion"];

        /// <summary>
        /// ConnectionString
        /// </summary>
        public static string ConnectionString => _config.GetConnectionString("Default");

        /// <summary>
        /// JWT
        /// </summary>
        public static class Jwt
        {
            public static string Domain => _config["JWT:Domain"];

            public static string SecurityKey => _config["JWT:SecurityKey"];

            public static int Expires => Convert.ToInt32(_config["JWT:Expires"]);
        }

        /// <summary>
        /// 微信开放平台
        /// </summary>
        public static class Weixin
        {
            public static string AppId => _config["Weixin:AppId"];

            public static string AppSecret => _config["Weixin:AppSecret"];
        }

        /// <summary>
        /// Bak
        /// </summary>
        public static class Bak
        {
            public static string ConnectionString => _config["Bak:ConnectionString"];
        }

        /// <summary>
        /// Caching
        /// </summary>
        public static class Caching
        {
            /// <summary>
            /// RedisConnectionString
            /// </summary>
            public static string RedisConnectionString => _config["Caching:RedisConnectionString"];

            /// <summary>
            /// 是否开启
            /// </summary>
            public static bool IsOpen => Convert.ToBoolean(_config["Caching:IsOpen"]);
        }
    }
}
