using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Bak.ThirdPlatforms.Domain.Shared
{
    [DependsOn(
        typeof(AbpIdentityDomainSharedModule)
        )]
    public class ThirdPlatformsDomainSharedModule : AbpModule
    {
        
    }
}
