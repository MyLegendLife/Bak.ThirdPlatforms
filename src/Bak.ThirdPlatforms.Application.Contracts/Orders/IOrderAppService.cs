using Bak.ThirdPlatforms.Common.Base;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Bak.ThirdPlatforms.Application.Contracts.Orders
{
    public interface IOrderAppService : IApplicationService
    {
        /// <summary>
        /// 新增订单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ServiceResult> CreateAsync(OrderCreateDto input);

        /// <summary>
        /// 分页查询订单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ServiceResult<PagedResultDto<OrderDto>>> GetListAsync(PagedAndSortedResultRequestDto input);
    }
}