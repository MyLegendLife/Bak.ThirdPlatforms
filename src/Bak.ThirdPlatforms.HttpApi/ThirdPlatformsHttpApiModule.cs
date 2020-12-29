using Bak.ThirdPlatforms.Application;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Bak.ThirdPlatforms.HttpApi
{
    [DependsOn(
        typeof(AbpIdentityHttpApiModule),
        typeof(ThirdPlatformsApplicationModule)
        )]
    public class ThirdPlatformsHttpApiModule : AbpModule
    {
        
    }
}
