using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esms.Ddd.Application.Contracts
{
    public interface IEsmsDddTestService: IEsmsDddApplicationService
    {
        Task<string> Excute();
    }
}
