using Esms.Ddd.Domain;
using Esms.Scm.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;

namespace Esms.Scm.Domain
{
    [DependsOn(
        typeof(EsmsScmDomainSharedModule),
        typeof(EsmsDddDomainModule)
        )]
    public class EsmsScmDomainModule: AbpModule
    {
    }
}
