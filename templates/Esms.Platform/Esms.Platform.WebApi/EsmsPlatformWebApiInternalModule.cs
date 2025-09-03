using Esms.Account.WebApi;
using Esms.Ddd.Domain.Shared.Accessors;
using Esms.Ddd.WebApi;
using Esms.Ddd.WebApi.Extensions;
using Esms.Platform.Application;
using Esms.Platform.Domain;
using Esms.Scm.WebApi;
using Microsoft.OpenApi.Models;
using SqlSugar;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace Esms.Platform.WebApi
{
    [DependsOn(
        typeof(EsmsPlatformWebApiModule)
        )]
    internal class EsmsPlatformWebApiInternalModule: AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddEsmsDddDbContext();
            context.Services.AddEsmsDddCurrentPrincipalAccessor(() =>
            {
                return new EsmsDddCurrentPrincipalAccessor("Development", null);
            });
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
