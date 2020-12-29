using Bak.ThirdPlatforms.Domain.Auths;
using Bak.ThirdPlatforms.Domain.Auths.Repositories;
using Bak.ThirdPlatforms.EntityFrameworkCore.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Bak.ThirdPlatforms.EntityFrameworkCore.Repositories.Auths
{
    public class FactorRepository : EfCoreRepository<ThirdPlatformsDbContext, Factor, int>, IFactorRepository
    {
        public FactorRepository(IDbContextProvider<ThirdPlatformsDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}