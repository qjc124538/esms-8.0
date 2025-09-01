using Esms.Account.Domain.Shared;
using Esms.Ddd.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;

namespace Esms.Account.Domain
{
    [DependsOn(
        typeof(EsmsAccountDomainSharedModule),
        typeof(EsmsDddDomainModule)
        )]
    public class EsmsAccountDomainModule: AbpModule
    {
    }
}
