using Esms.Ddd.Domain;
using Esms.Platform.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;

namespace Esms.Platform.Domain
{
    [DependsOn(
        typeof(EsmsPlatformDomainSharedModule),
        typeof(EsmsDddDomainModule)
        )]
    public class EsmsPlatformDomainModule: AbpModule
    {
    }
}
