using Esms.Account.WebApi;
using Esms.Ddd.WebApi;
using Esms.Platform.Application;
using Esms.Platform.Domain;
using Microsoft.OpenApi.Models;
using SqlSugar;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace Esms.Platform.WebApi
{
    [DependsOn(
        typeof(EsmsPlatformApplicationModule),
        typeof(EsmsAccountWebApiModule),
        typeof(EsmsDddWebApiModule)
        )]
    internal class EsmsPlatformWebApiInternalModule: AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(EsmsPlatformApplicationModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "EsmsPlatform API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseAbpSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "EsmsPlatform API");
            });
            app.UseRouting();
            app.UseConfiguredEndpoints();
        }
    }
}
