using Esms.Account.WebApi;
using Esms.Scm.WebApi;
using Volo.Abp.Modularity;

namespace Esms.DddPlatform.WebApi
{

    [DependsOn(
        typeof(EsmsAccountWebApiModule),
        typeof(EsmsScmWebApiModule)
        )]
    public class EsmsDddPlatformWebApiModule: AbpModule
    {
    }
}
