using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Esms.Ddd.Domain.Shared
{
    [DependsOn(typeof(AbpDddDomainSharedModule))]
    public class EsmsDddDomainSharedModule: AbpModule
    {
    }
}
