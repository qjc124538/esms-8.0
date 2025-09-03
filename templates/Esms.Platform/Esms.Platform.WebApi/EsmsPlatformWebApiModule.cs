using Esms.Account.WebApi;
using Esms.Ddd.WebApi;
using Esms.Platform.Application;
using Esms.Scm.WebApi;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace Esms.Platform.WebApi
{
    [DependsOn(
        typeof(EsmsPlatformApplicationModule),
        typeof(EsmsAccountWebApiModule),
        typeof(EsmsScmWebApiModule),
        typeof(EsmsDddWebApiModule)
        )]
    public class EsmsPlatformWebApiModule: AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(EsmsPlatformApplicationModule).Assembly);
            });
        }
    }
}
