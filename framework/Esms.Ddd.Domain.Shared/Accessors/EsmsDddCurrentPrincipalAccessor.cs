using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Esms.Ddd.Domain.Shared.Accessors
{
    public class EsmsDddCurrentPrincipalAccessor
    {
        public string? UserId { get; }
        public decimal? CorpNo { get; }
        public EsmsDddCurrentPrincipalAccessor(string userId, decimal? corpNo)
        {
            UserId = userId;
            CorpNo = corpNo;
        }
    }
}
