using Esms.Ddd.Application;
using Esms.Ddd.Domain;
using Microsoft.OpenApi.Models;
using SqlSugar;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.AntiForgery;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;

namespace Esms.Ddd.WebApi
{
    [DependsOn(
        typeof(EsmsDddApplicationModule),
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutofacModule),
        typeof(AbpSwashbuckleModule)
        )]
    internal class EsmsDddWebApiInternalModule: AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            var hostEnvironment = context.Services.GetAbpHostEnvironment();
            if (hostEnvironment.IsDevelopment())
            {
                Configure<AbpAntiForgeryOptions>(options =>
                {
                    options.TokenCookie.SecurePolicy = CookieSecurePolicy.Always;
                });
            }
            PreConfigure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(EsmsDddApplicationModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "EsmsDdd API", Version = "v1" });
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
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "EsmsDdd API");
            });
            app.UseRouting();
            app.UseConfiguredEndpoints();
        }
    }
}
