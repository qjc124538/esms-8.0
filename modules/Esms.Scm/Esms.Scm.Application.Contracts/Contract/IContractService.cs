using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Esms.Scm.Contract
{
    public interface IContractService: IApplicationService
    {
        Task AddAbpTest(int count);
    }
}
