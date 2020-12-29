using log4net;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Bak.ThirdPlatforms.Web.Filters
{
    public class ThirdPlatformsExceptionFilter : IExceptionFilter
    {
        private readonly ILog _log;
        public ThirdPlatformsExceptionFilter()
        {
            _log = LogManager.GetLogger(typeof(ThirdPlatformsExceptionFilter)); ;
        }

        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            // 错误日志记录
            _log.Error($"{context.HttpContext.Request.Path}|{context.Exception.Message}", context.Exception);
        }
    }
}
