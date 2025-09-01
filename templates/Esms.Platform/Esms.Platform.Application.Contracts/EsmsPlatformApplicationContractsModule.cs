using Esms.Ddd.Application.Contracts;
using Esms.Platform.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;

namespace Esms.Platform.Application.Contracts
{
    [DependsOn(
        typeof(EsmsPlatformDomainSharedModule),
        typeof(EsmsDddApplicationContractsModule)
        )]
    public class EsmsPlatformApplicationContractsModule: AbpModule
    {
    }
}
