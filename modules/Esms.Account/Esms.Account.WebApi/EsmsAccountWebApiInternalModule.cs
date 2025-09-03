using Castle.DynamicProxy;
using Esms.Account.Application;
using Esms.Account.Domain;
using Esms.Ddd.Domain;
using Esms.Ddd.Domain.Shared.Accessors;
using Esms.Ddd.WebApi;
using Esms.Ddd.WebApi.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SqlSugar;
using System.Reflection;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace Esms.Account.WebApi
{
    [DependsOn(
        typeof(EsmsAccountWebApiModule)
        )]
    internal class EsmsAccountWebApiInternalModule : AbpModule
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
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "EsmsAccount API", Version = "v1" });
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
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "EsmsAccount API");
            });
            app.UseRouting();
            app.UseConfiguredEndpoints();
        }
    }
}
