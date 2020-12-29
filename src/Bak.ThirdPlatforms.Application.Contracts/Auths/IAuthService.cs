using Bak.ThirdPlatforms.Common.Base;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Bak.ThirdPlatforms.Application.Contracts.Auths
{
    public interface IAuthService : IApplicationService
    {
        /// <summary>
        /// 创建授权页面地址
        /// </summary>
        /// <returns></returns>
        Task<ServiceResult<string>> CreateAuthPageAsync(string redirectUrl);

        /// <summary>
        /// 创建授权者
        /// </summary>
        /// <returns></returns>
        Task<ServiceResult> CreateAuthorizerAsync(string authorizationCode, int expiresIn);

        ///// <summary>
        ///// 查询授权信息
        ///// </summary>
        ///// <returns></returns>
        //Task<ServiceResult<PagedResultDto<MerchanAuthorizationDto>>> QueryMerchanAuthAsync(PagedAndSortedResultRequestDto input);
    }
}