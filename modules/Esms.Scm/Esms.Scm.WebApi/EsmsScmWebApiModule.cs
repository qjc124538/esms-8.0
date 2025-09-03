using Esms.Ddd.WebApi;
using Esms.Scm.Application;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace Esms.Scm.WebApi
{
    [DependsOn(
        typeof(EsmsScmApplicationModule),
        typeof(EsmsDddWebApiModule)
        )]
    public class EsmsScmWebApiModule: AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(EsmsScmApplicationModule).Assembly);
            });
        }
    }
}
