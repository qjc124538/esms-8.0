using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Esms.Ddd.Test
{
    public interface IEsmsDddTestService: IApplicationService
    {
        Task<string> ExcuteAsync();

        Task<string> GetAbpTestListAsync();

        Task<List<decimal>> AddAbpTestListAsync(int count);

        Task DeleteAbpTestListAsync(List<decimal> idList);

        Task<string> GetCurrentPrincipalAccessor();
    }
}
