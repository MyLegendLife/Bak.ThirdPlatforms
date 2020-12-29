using Bak.ThirdPlatforms.Application.Contracts.Orders;
using Bak.ThirdPlatforms.Common.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using static Bak.ThirdPlatforms.Domain.Shared.ThirdPlatformsConsts;

namespace Bak.ThirdPlatforms.Application.MiniPrograms
{
    public class OrderAppService : ApplicationService, IOrderAppService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderAppService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// 新增订单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ServiceResult> CreateAsync(OrderCreateDto input)
        {
            var result = new ServiceResult();

            var order = ObjectMapper.Map<OrderCreateDto, Order>(input);

            await _orderRepository.InsertAsync(order);

            result.IsSuccess(ResponseText.INSERT_SUCCESS);
            return result;;
        }

        /// <summary>
        /// 分页查询订单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ServiceResult<PagedResultDto<OrderDto>>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var result = new ServiceResult<PagedResultDto<OrderDto>>();

            var count = await _orderRepository.GetCountAsync();

            var orders = await _orderRepository.GetPagedListAsync(input.SkipCount, input.MaxResultCount, input.Sorting);
            //var query = _orderRepository.OrderBy(input.Sorting)
            //    .Skip(input.SkipCount)
            //    .Take(input.MaxResultCount);

            //var list = await query.ToListAsync();

            var orderDtos = ObjectMapper.Map<List<Order>, List<OrderDto>>(orders);

            result.IsSuccess(new PagedResultDto<OrderDto>
            {
                TotalCount = count,
                Items = orderDtos
            });

            return result;
        }
    }
}