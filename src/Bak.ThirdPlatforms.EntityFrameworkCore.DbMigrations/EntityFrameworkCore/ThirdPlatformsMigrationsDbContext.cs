using Bak.ThirdPlatforms.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Bak.ThirdPlatforms.EntityFrameworkCore.DbMigrations.EntityFrameworkCore
{
    public class ThirdPlatformsMigrationsDbContext : AbpDbContext<ThirdPlatformsMigrationsDbContext>
    {
        public ThirdPlatformsMigrationsDbContext(DbContextOptions<ThirdPlatformsMigrationsDbContext> options) 
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