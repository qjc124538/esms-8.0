using Microsoft.OpenApi.Models;
using Volo.Abp.AspNetCore.Mvc.AntiForgery;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;
using Volo.Abp;
using Esms.Ddd.Application;
using Volo.Abp.Autofac;
using Volo.Abp.Swashbuckle;
using SqlSugar;
using Esms.Ddd.Domain;
using Esms.Ddd.WebApi.Filters;
using Esms.Ddd.Domain.Shared.Accessors;
using Esms.Ddd.WebApi.Extensions;

namespace Esms.Ddd.WebApi
{
    [DependsOn(
        typeof(EsmsDddApplicationModule),
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutofacModule),
        typeof(AbpSwashbuckleModule)
        )]
    public class EsmsDddWebApiModule: AbpModule
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
            context.Services.AddControllers(options => 
            {
                options.Filters.Add<EsmsDddActionFilter>();
            });
        }
    }
}
