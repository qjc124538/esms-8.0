using Esms.Account.Application;
using Esms.Account.Domain;
using Esms.Ddd.Domain;
using Esms.Ddd.WebApi;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace Esms.Account.WebApi
{
    [DependsOn(
        typeof(EsmsAccountApplicationModule),
        typeof(EsmsDddWebApiModule)
        )]
    public class EsmsAccountWebApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(EsmsAccountApplicationModule).Assembly);
            });
        }
    }
}
