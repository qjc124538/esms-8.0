using Esms.Ddd.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esms.Ddd.Application
{
    public class EsmsDddTestService : EsmsDddApplicationService, IEsmsDddTestService
    {
        public async Task<string> Excute()
        {
            return await Task.FromResult("EsmsDddTestService: 成功");
        }
    }
}
