using Bak.ThirdPlatforms.EntityFrameworkCore.DbMigrations.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Bak.ThirdPlatforms.EntityFrameworkCore.DbMigrations
{
    [DependsOn(
        typeof(ThirdPlatformsEntityFrameworkCoreModule)
        )]
    public class ThirdPlatformsEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<ThirdPlatformsMigrationsDbContext>();
        }
    }
}
