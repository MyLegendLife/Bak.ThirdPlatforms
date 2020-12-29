using Bak.ThirdPlatforms.Domain.Auths;
using Bak.ThirdPlatforms.Domain.Base;
using Bak.ThirdPlatforms.Domain.MiniPrograms;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Bak.ThirdPlatforms.EntityFrameworkCore.EntityFrameworkCore
{
    [ConnectionStringName("Default")]
    public class ThirdPlatformsDbContext : AbpDbContext<ThirdPlatformsDbContext>
    {
        public DbSet<ThirdTicket> ThirdTickets { get; set; }
        public DbSet<Factor> Factors { get; set; }
        public DbSet<Authorizer> Authorizers { get; set; }
        public DbSet<MiniProgramRecord> MiniProgramRecords { get; set; }

        public ThirdPlatformsDbContext(DbContextOptions<ThirdPlatformsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureThirdPlatforms();
        }
    }
}
