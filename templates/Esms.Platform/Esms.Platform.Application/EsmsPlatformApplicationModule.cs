using Esms.Ddd.Application;
using Esms.Platform.Application.Contracts;
using Esms.Platform.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;

namespace Esms.Platform.Application
{
    [DependsOn(
        typeof(EsmsPlatformApplicationContractsModule),
        typeof(EsmsPlatformDomainModule),
        typeof(EsmsDddApplicationModule)
        )]
    public class EsmsPlatformApplicationModule: AbpModule
    {
    }
}
