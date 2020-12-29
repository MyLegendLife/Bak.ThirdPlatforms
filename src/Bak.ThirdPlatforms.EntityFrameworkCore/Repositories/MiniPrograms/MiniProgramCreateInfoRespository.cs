using Bak.ThirdPlatforms.Domain.MiniPrograms;
using Bak.ThirdPlatforms.Domain.MiniPrograms.Repositories;
using Bak.ThirdPlatforms.EntityFrameworkCore.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Bak.ThirdPlatforms.EntityFrameworkCore.Repositories.MiniPrograms
{
    public class MiniProgramRecordRepository : EfCoreRepository<ThirdPlatformsDbContext, MiniProgramRecord, int>, IMiniProgramRecordRepository
    {
        public MiniProgramRecordRepository(IDbContextProvider<ThirdPlatformsDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}