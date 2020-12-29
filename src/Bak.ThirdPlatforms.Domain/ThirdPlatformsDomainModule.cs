using Bak.ThirdPlatforms.Domain.Shared;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Bak.ThirdPlatforms.Domain
{
    [DependsOn(
        typeof(AbpIdentityDomainModule),
        typeof(ThirdPlatformsDomainSharedModule)
    )]
    public class ThirdPlatformsDomainModule : AbpModule
    {
        
    }
}
