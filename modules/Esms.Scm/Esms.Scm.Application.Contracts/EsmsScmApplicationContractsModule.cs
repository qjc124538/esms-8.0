using Esms.Ddd.Application.Contracts;
using Esms.Scm.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;

namespace Esms.Scm.Application.Contracts
{
    [DependsOn(
        typeof(EsmsScmDomainSharedModule),
        typeof(EsmsDddApplicationContractsModule)
        )]
    public class EsmsScmApplicationContractsModule: AbpModule
    {
    }
}
