using Esms.Ddd.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Esms.Ddd.Application
{
    [EsmsSqlSugarUnitOfWork]
    public abstract class EsmsApplicationService: ApplicationService
    {
    }
}
