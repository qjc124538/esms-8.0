using Esms.Ddd.Application;
using Esms.Scm.Application.Contracts;
using Esms.Scm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;

namespace Esms.Scm.Application
{
    [DependsOn(
        typeof(EsmsScmApplicationContractsModule),
        typeof(EsmsScmDomainModule),
        typeof(EsmsDddApplicationModule)
        )]
    public class EsmsScmApplicationModule: AbpModule
    {
    }
}
