using Esms.Ddd.Domain.Shared.Accessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Esms.Ddd.Domain
{
    public abstract class EsmsDddDomainService: DomainService
    {
        protected EsmsDddSqlSugarClient DbContext => LazyServiceProvider.LazyGetRequiredService<EsmsDddSqlSugarClient>();

        protected EsmsDddCurrentPrincipalAccessor CurrentPrincipalAccessor => LazyServiceProvider.LazyGetRequiredService<EsmsDddCurrentPrincipalAccessor>();
    }
}
