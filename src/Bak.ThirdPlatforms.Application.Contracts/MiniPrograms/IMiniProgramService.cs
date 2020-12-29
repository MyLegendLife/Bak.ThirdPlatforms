using Bak.ThirdPlatforms.Common.Base;
using System.Threading.Tasks;
using Bak.ThirdPlatforms.Domain.MiniPrograms;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Bak.ThirdPlatforms.Application.Contracts.MiniPrograms
{
    public interface IMiniProgramService : IApplicationService
    {
        /// <summary>
        /// 创建小程序接口
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ServiceResult<string>> FastRegisterAsync(MiniProgramRegisterInput input);

        /// <summary>
        /// 查询创建任务状态
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ServiceResult<string>> RegisterSearchAsync(MiniProgramSearchInput input);

        /// <summary>
        /// 申请开通直播
        /// </summary>
        /// <returns></returns>
        Task<ServiceResult<string>> ApplyLiveAsync(string authAccessToken);

        /// <summary>
        /// 查询小程序创建记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ServiceResult<PagedResultDto<MiniProgramRecordDto>>> RecordAsync(PagedAndSortedResultRequestDto input);
    }
}