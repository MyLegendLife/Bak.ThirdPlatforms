using log4net;
using log4net.Config;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Reflection;

namespace Bak.ThirdPlatforms.Common.Extensions
{
    public static class Log4NetExtensions
    {
        public static IHostBuilder UseLog4Net(this IHostBuilder builder)
        {
            var log4NetRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(log4NetRepository, new FileInfo("Resources/log4net.config"));

            return builder;
        }
    }
}
