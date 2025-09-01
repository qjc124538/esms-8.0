using Esms.Ddd.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace Esms.Ddd.Application.Contracts
{
    [DependsOn(
        typeof(EsmsDddDomainSharedModule),
        typeof(AbpDddApplicationContractsModule)
        )]
    public class EsmsDddApplicationContractsModule: AbpModule
    {
    }
}
