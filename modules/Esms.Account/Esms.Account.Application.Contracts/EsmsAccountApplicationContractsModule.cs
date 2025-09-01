using Esms.Account.Domain.Shared;
using Esms.Ddd.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;

namespace Esms.Account.Application.Contracts
{
    [DependsOn(
        typeof(EsmsAccountDomainSharedModule),
        typeof(EsmsDddApplicationContractsModule)
        )]
    public class EsmsAccountApplicationContractsModule: AbpModule
    {
    }
}
