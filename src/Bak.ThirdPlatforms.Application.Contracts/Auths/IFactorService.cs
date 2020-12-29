using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Bak.ThirdPlatforms.Application.Contracts.Auths
{
    public interface IFactorService : IApplicationService
    {
        /// <summary>
        /// 获取令牌
        /// </summary>
        /// <returns></returns>
        Task<string> GetAccessTokenAsync();

        /// <summary>
        /// 获取预授权码
        /// </summary>
        /// <returns></returns>
        Task<string> GetPreAuthCode();
    }
}