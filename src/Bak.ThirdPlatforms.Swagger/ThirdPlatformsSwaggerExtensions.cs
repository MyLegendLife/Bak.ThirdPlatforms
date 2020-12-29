using Bak.ThirdPlatforms.Domain.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Bak.ThirdPlatforms.Swagger.Filter;
using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Bak.ThirdPlatforms.Swagger
{
    public static class ThirdPlatformsSwaggerExtensions
    {
        /// <summary>
        /// 当前API版本，从appsettings.json获取
        /// </summary>
        private static readonly string version = $"v" + AppSettings.ApiVersion;

        /// <summary>
        /// Swagger描述信息
        /// </summary>
        private static readonly string description = "<b>微信第三方平台</b>";

        /// <summary>
        /// Swagger分组信息，将进行遍历使用
        /// </summary>
        private static readonly List<SwaggerApiInfo> ApiInfos = new List<SwaggerApiInfo>() {
        new SwaggerApiInfo
            {
                UrlPrefix = "v1",
                Name = "小程序",
                OpenApiInfo = new OpenApiInfo
                {
                    Version = version,
                    Title = "小程序",
                    Description = description
                }
            }
        };

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(options => {
                ApiInfos.ForEach(x => {
                    options.SwaggerDoc(x.UrlPrefix,x.OpenApiInfo);
                });

                //Api描述信息
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Resources/Bak.ThirdPlatforms.Application.Contracts.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Resources/Bak.ThirdPlatforms.Domain.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Resources/Bak.ThirdPlatforms.HttpApi.xml"));

                // 应用Controller的API文档描述信息
                options.DocumentFilter<SwaggerDocumentFilter>();
            });
        }

        /// <summary>
        /// UseSwaggerUI
        /// </summary>
        /// <param name="app"></param>
        public static void UseSwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwaggerUI(options =>
            {
                // 遍历分组信息，生成Json
                ApiInfos.ForEach(x =>
                {
                    options.SwaggerEndpoint($"/swagger/{x.UrlPrefix}/swagger.json", x.Name);
                });

                // 模型的默认扩展深度，设置为 -1 完全隐藏模型
                options.DefaultModelsExpandDepth(-1);
                // API文档仅展开标记
                options.DocExpansion(DocExpansion.List);
                // API前缀设置为空
                options.RoutePrefix = string.Empty;
                // API页面Title
                options.DocumentTitle = "微信第三方平台" + version;
            });
        }
    }
}
