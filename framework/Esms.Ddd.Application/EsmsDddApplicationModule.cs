using Esms.Ddd.Application.Contracts;
using Esms.Ddd.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace Esms.Ddd.Application
{
    [DependsOn(
        typeof(EsmsDddApplicationContractsModule),
        typeof(EsmsDddDomainModule),
        typeof(AbpDddApplicationModule)
        )]
    public class EsmsDddApplicationModule: AbpModule
    {
    }
}
