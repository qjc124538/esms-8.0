using Esms.Ddd.Application.Contracts;
using Esms.Ddd.Domain;
using Esms.Ddd.Domain.Shared;
using Esms.Ddd.Domain.Shared.Accessors;
using Esms.Ddd.Domain.Shared.Attributes;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Esms.Ddd.Application
{
    [EnableEsmsDddSugarUnitOfWork]
    public abstract class EsmsDddApplicationService: ApplicationService
    {
        protected EsmsDddSqlSugarClient DbContext => LazyServiceProvider.LazyGetRequiredService<EsmsDddSqlSugarClient>();

        protected EsmsDddCurrentPrincipalAccessor CurrentPrincipalAccessor => LazyServiceProvider.LazyGetRequiredService<EsmsDddCurrentPrincipalAccessor>();
    }
}
