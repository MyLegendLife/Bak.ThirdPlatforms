using Microsoft.AspNetCore.Mvc.Filters;
using System;
using log4net;

namespace Bak.ThirdPlatforms.HttpApi.Host.Filters
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
