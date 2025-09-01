using Esms.Ddd.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Esms.Ddd.Domain
{
    [DependsOn(
        typeof(EsmsDddDomainSharedModule),
        typeof(AbpDddDomainModule)
        )]
    public class EsmsDddDomainModule: AbpModule
    {
    }
}
