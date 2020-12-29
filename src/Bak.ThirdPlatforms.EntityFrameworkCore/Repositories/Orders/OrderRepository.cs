using Bak.ThirdPlatforms.EntityFrameworkCore.EntityFrameworkCore;
using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Bak.ThirdPlatforms.EntityFrameworkCore.Repositories.Orders
{
    /// <summary>
    /// OrderRepository
    /// </summary>
    public class OrderRepository : EfCoreRepository<ThirdPlatformsDbContext,Order,Guid>,IOrderRepository
    {
        public OrderRepository(IDbContextProvider<ThirdPlatformsDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}