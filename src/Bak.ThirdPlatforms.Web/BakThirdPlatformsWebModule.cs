using Bak.ThirdPlatforms.EntityFrameworkCore;
using Bak.ThirdPlatforms.HttpApi;
using Bak.ThirdPlatforms.Web.Filters;
using Bak.ThirdPlatforms.Web.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Security.Policy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc.ExceptionHandling;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Bak.ThirdPlatforms.Web
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(ThirdPlatformsHttpApiModule),
        typeof(ThirdPlatformsEntityFrameworkCoreModule)
        )]
    public class BakThirdPlatformsWebModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            //ConfigureUrls(configuration);
            ConfigureException(); //自定义异常配置
            ConfigureRouting(context); //路由配置
            ConfigureHttpClient(context);

            context.Services.AddControllersWithViews();
        }

        //private void ConfigureUrls(IConfiguration configuration)
        //{
        //    Configure<AppUrlOptions>(options =>
        //    {
        //        options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"];
        //    });
        //}

        private void ConfigureException()
        {
            Configure<MvcOptions>(options =>
            {
                var filterMetadata = options.Filters.FirstOrDefault(x => x is ServiceFilterAttribute attribute && attribute.ServiceType == typeof(AbpExceptionFilter));

                // 移除 AbpExceptionFilter
                options.Filters.Remove(filterMetadata);

                // 添加自定义异常处理
                options.Filters.Add(typeof(ThirdPlatformsExceptionFilter));
            });
        }

        private void ConfigureRouting(ServiceConfigurationContext context)
        {
            context.Services.AddRouting(options =>
            {
                // 设置Url为小写
                options.LowercaseUrls = true;
                // 在生成的Url后面添加斜杠
                options.AppendTrailingSlash = true;
            });
        }

        private void ConfigureHttpClient(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClient();
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            // 环境变量，开发环境
            if (env.IsDevelopment())
            {
                // 生成异常页面
                app.UseDeveloperExceptionPage();
            }

            // 使用HSTS的中间件，该中间件添加了严格传输安全头
            app.UseHsts();

            // 转发将标头代理到当前请求，配合 Nginx 使用，获取用户真实IP
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            // 路由
            app.UseRouting();

            // 异常处理中间件
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            // HTTP => HTTPS
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            // 路由映射
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern:  "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}