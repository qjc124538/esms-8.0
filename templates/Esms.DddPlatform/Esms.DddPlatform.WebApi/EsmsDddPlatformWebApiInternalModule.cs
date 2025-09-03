using Esms.Account.WebApi;
using Esms.Ddd.Domain.Shared.Accessors;
using Esms.Ddd.WebApi.Extensions;
using Esms.Scm.WebApi;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace Esms.DddPlatform.WebApi
{
    [DependsOn(
        typeof(EsmsDddPlatformWebApiModule)
        )]
    internal class EsmsDddPlatformWebApiInternalModule: AbpModule
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
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "EsmsDddPlatform API", Version = "v1" });
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
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "EsmsDddPlatform API");
            });
            app.UseRouting();
            app.UseConfiguredEndpoints();
        }
    }
}
