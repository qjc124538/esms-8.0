using Esms.Ddd.Application;
using Esms.Ddd.Domain;
using Esms.Ddd.Domain.Shared.Accessors;
using Esms.Ddd.WebApi.Extensions;
using Esms.Ddd.WebApi.Filters;
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
        typeof(EsmsDddWebApiModule)
        )]
    internal class EsmsDddWebApiInternalModule: AbpModule
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
