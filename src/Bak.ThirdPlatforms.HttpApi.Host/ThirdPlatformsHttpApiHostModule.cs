using Bak.ThirdPlatforms.Common.Base;
using Bak.ThirdPlatforms.Common.Extensions;
using Bak.ThirdPlatforms.Domain.Settings;
using Bak.ThirdPlatforms.EntityFrameworkCore;
using Bak.ThirdPlatforms.HttpApi.Host.Filters;
using Bak.ThirdPlatforms.HttpApi.Host.Middlewares;
using Bak.ThirdPlatforms.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.ExceptionHandling;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Bak.ThirdPlatforms.HttpApi.Host
{
    [DependsOn(
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutofacModule),
        typeof(ThirdPlatformsHttpApiModule),
        typeof(ThirdPlatformsSwaggerModule),
        typeof(ThirdPlatformsEntityFrameworkCoreModule)
     )]
    public class ThirdPlatformsHttpApiHostModule : AbpModule
    {
        private const string DefaultCorsPolicyName = "Default";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            ConfigureException(); //自定义异常配置
            ConfigureCors(context, configuration); //跨域配置
            ConfigureRouting(context); //路由配置
            ConfigureAuthentication(context, configuration); //身份认证配置
            ConfigureAuthorization(context);  //授权配置
            ConfigureHttpClient(context);
        }

        private void ConfigureException()
        {
            Configure<MvcOptions>(options => {
                var filterMetadata = options.Filters.FirstOrDefault(x => x is ServiceFilterAttribute attribute && attribute.ServiceType == typeof(AbpExceptionFilter));

                // 移除 AbpExceptionFilter
                options.Filters.Remove(filterMetadata);

                // 添加自定义异常处理
                options.Filters.Add(typeof(ThirdPlatformsExceptionFilter));
            });
        }

        private void ConfigureCors(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddCors(options =>
            {
                options.AddPolicy(DefaultCorsPolicyName, builder =>
                {
                    builder
                        .WithOrigins(
                            configuration["App:CorsOrigins"]
                                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .Select(o => o.RemovePostFix("/"))
                                .ToArray()
                        )
                        .WithAbpExposedHeaders()
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });
        }

        private void ConfigureRouting(ServiceConfigurationContext context)
        {
            context.Services.AddRouting(options => {
                // 设置Url为小写
                options.LowercaseUrls = true;
                // 在生成的Url后面添加斜杠
                options.AppendTrailingSlash = true;
            });
        }

        private void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // 是否验证颁发者
                        ValidateIssuer = true,
                        // 是否验证访问群体
                        ValidateAudience = true,
                        // 是否验证生存期
                        ValidateLifetime = true,
                        // 验证Token的时间偏移量
                        ClockSkew = TimeSpan.FromSeconds(30),
                        // 是否验证安全密钥
                        ValidateIssuerSigningKey = true,
                        // 访问群体
                        ValidAudience = AppSettings.Jwt.Domain,
                        // 颁发者
                        ValidIssuer = AppSettings.Jwt.Domain,
                        // 安全密钥
                        IssuerSigningKey = new SymmetricSecurityKey(AppSettings.Jwt.SecurityKey.GetBytes())
                    };

                    // 应用程序提供的对象，用于处理承载引发的事件，身份验证处理程序
                    options.Events = new JwtBearerEvents
                    {
                        OnChallenge = async context =>
                        {
                            // 跳过默认的处理逻辑，返回下面的模型数据
                            context.HandleResponse();

                            context.Response.ContentType = "application/json;charset=utf-8";
                            context.Response.StatusCode = StatusCodes.Status200OK;

                            var result = new ServiceResult();
                            result.IsFailed("UnAuthorized");

                            await context.Response.WriteAsync(result.ToJson());
                        }
                    };
                });
        }

        private void ConfigureAuthorization(ServiceConfigurationContext context)
        {
            context.Services.AddAuthorization();
        }

        private void ConfigureHttpClient(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClient();
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                //生成异常页面
                app.UseDeveloperExceptionPage();
            }

            //使用HSTS的中间件，该中间件添加了严格传输安全头
            app.UseHsts();

            //转发将标头代理到当前请求，配合 Nginx 使用，获取用户真实IP
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            //路由
            app.UseRouting();

            //跨域
            app.UseCors(DefaultCorsPolicyName);

            //异常处理中间件
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            //身份认证
            app.UseAuthentication();

            //授权
            app.UseAuthorization();

            // HTTP => HTTPS
            app.UseHttpsRedirection();

            // 路由映射
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
