using System;
using Bak.ThirdPlatforms.Domain.MiniPrograms;
using Volo.Abp.Domain.Repositories;

namespace Bak.ThirdPlatforms.Domain.Orders
{
    /// <summary>
    /// IOrderRepository
    /// </summary>
    public interface IOrderRepository : IRepository<Order,Guid>
    {
        
    }
}