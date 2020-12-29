using Bak.ThirdPlatforms.Domain.Base;
using Bak.ThirdPlatforms.Domain.Base.Repositories;
using Bak.ThirdPlatforms.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Bak.ThirdPlatforms.EntityFrameworkCore.Repositories.Base
{
    public class ThirdTicketRepository : EfCoreRepository<ThirdPlatformsDbContext, ThirdTicket>, IThirdTicketRepository
    {
        public ThirdTicketRepository(IDbContextProvider<ThirdPlatformsDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        /// <summary>
        /// 获取票据
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetTicketAsync()
        {
            var entity = await DbContext.Set<ThirdTicket>().FirstOrDefaultAsync();

            return entity == null ? "" : entity.Ticket;
        }
    }
}