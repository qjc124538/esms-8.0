using Esms.Ddd.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;

namespace Esms.Platform.Domain.Shared
{
    [DependsOn(typeof(EsmsDddDomainSharedModule))]
    public class EsmsPlatformDomainSharedModule: AbpModule
    {
    }
}
