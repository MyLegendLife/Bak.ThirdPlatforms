using Bak.ThirdPlatforms.Application.Contracts;
using Bak.ThirdPlatforms.Domain;
using Bak.ThirdPlatforms.Domain.Settings;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;

namespace Bak.ThirdPlatforms.Application.Caching
{
    [DependsOn(
        typeof(AbpCachingModule),
        typeof(ThirdPlatformsDomainModule),
        typeof(ThirdPlatformsApplicationContractsModule)
        )]
    public class ThirdPlatformsApplicationCachingModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            if (AppSettings.Caching.IsOpen)
            {
                context.Services.AddStackExchangeRedisCache(options =>
                {
                    options.Configuration = AppSettings.Caching.RedisConnectionString;
                });

                var csredis = new CSRedis.CSRedisClient(AppSettings.Caching.RedisConnectionString);
                RedisHelper.Initialization(csredis);

                context.Services.AddSingleton<IDistributedCache>(new CSRedisCache(RedisHelper.Instance));
            }
        }
    }
}
