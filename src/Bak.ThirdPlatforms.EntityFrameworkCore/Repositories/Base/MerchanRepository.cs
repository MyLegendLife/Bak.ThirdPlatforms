using Bak.ThirdPlatforms.EntityFrameworkCore.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Bak.ThirdPlatforms.EntityFrameworkCore.Repositories.Base
{
    public class MerchanRepository : EfCoreRepository<ThirdPlatformsDbContext, Merchan>, IMerchanRepository
    {
        public MerchanRepository(IDbContextProvider<ThirdPlatformsDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        
    }
}