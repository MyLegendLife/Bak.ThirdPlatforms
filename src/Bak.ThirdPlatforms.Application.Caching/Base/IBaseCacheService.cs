using System;
using Bak.ThirdPlatforms.Common.Base;
using System.Threading.Tasks;

namespace Bak.ThirdPlatforms.Application.Caching.Base
{
    public interface IBaseCacheService
    {
        /// <summary>
        /// 创建预授权码
        /// </summary>
        /// <returns></returns>
        Task<ServiceResult<string>> CreatePreAuthCode(Func<Task<ServiceResult<string>>> factory);

        /// <summary>
        /// 创建授权页面地址
        /// </summary>
        /// <returns></returns>
        Task<ServiceResult<string>> CreateComponentLoginPage(string preAuthCode, string redirectUrl, int authType = 3);

        /// <summary>
        /// 回调 URI，获取授权码
        /// </summary>
        /// <returns></returns>
        Task<ServiceResult<string>> GetAuthCode();

        /// <summary>
        /// 使用授权码获取授权信息
        /// </summary>
        /// <returns></returns>
        Task<ServiceResult<string>> QueryAuth();

        /// <summary>
        /// 获取令牌
        /// </summary>
        /// <returns></returns>
        Task<ServiceResult<string>> GetComponentAccessToken();
    }
}