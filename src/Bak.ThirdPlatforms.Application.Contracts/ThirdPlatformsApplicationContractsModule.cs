using Bak.ThirdPlatforms.Domain;
using Volo.Abp.Modularity;

namespace Bak.ThirdPlatforms.Application.Contracts
{
    [DependsOn(typeof(ThirdPlatformsDomainModule))]
    public class ThirdPlatformsApplicationContractsModule :AbpModule
    {
    }
}
