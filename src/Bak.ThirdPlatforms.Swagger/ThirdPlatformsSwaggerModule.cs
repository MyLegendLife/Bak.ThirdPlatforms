using Bak.ThirdPlatforms.Domain;
using Microsoft.AspNetCore.Builder;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace Bak.ThirdPlatforms.Swagger
{
    [DependsOn(typeof(ThirdPlatformsDomainModule))]
    public class ThirdPlatformsSwaggerModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddSwagger();
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();

            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
