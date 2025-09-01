using Esms.Account.Application.Contracts;
using Esms.Account.Domain;
using Esms.Ddd.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;

namespace Esms.Account.Application
{
    [DependsOn(
        typeof(EsmsAccountApplicationContractsModule),
        typeof(EsmsAccountDomainModule),
        typeof(EsmsDddApplicationModule)
        )]
    public class EsmsAccountApplicationModule: AbpModule
    {
    }
}
