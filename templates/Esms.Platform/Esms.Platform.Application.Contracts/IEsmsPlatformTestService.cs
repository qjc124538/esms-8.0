using Esms.Ddd.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esms.Platform.Application.Contracts
{
    public interface IEsmsPlatformTestService: IEsmsDddApplicationService
    {
        Task<string> ExcuteAsync();

        Task<string> GetAbpTestListAsync();

        Task<List<decimal>> AddAbpTestListAsync(int count);

        Task DeleteAbpTestListAsync(List<decimal> idList);
    }
}
