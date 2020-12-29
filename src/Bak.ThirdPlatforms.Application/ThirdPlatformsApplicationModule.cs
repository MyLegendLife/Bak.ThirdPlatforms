using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Bak.ThirdPlatforms.Application
{
    [DependsOn(
        typeof(AbpIdentityApplicationModule),
        typeof(AbpAutoMapperModule)
        )]
    public class ThirdPlatformsApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                //options.AddMaps<ThirdPlatformsApplicationModule>(validate:true);
                //options.AddProfile<ThirdPlatformsApplicationAutoMapperProfile>(validate: true);
                options.AddMaps<ThirdPlatformsApplicationModule>();
                options.AddProfile<ThirdPlatformsApplicationAutoMapperProfile>();
            });
        }
    }
}
