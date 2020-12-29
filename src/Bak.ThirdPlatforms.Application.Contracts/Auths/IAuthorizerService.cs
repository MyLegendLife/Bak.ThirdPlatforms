using Bak.ThirdPlatforms.Common.Base;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Bak.ThirdPlatforms.Application.Contracts.Auths
{
    public interface IAuthorizerService : IApplicationService
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
        Task<ServiceResult> CreateAsync(string authCode, int expiresIn);

        /// <summary>
        /// 更新授权者
        /// </summary>
        /// <returns></returns>
        Task<ServiceResult> UpdateAsync(string authorizerAppId);

        /// <summary>
        /// 更新授权者
        /// </summary>
        /// <returns></returns>
        Task<ServiceResult<string>> UpdateAccessTokenAsync(string authorizerAppid);

        /// <summary>
        /// 查询授权者
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ServiceResult<PagedResultDto<AuthorizerDto>>> GetListAsync(PagedAndSortedResultRequestDto input);
    }
}