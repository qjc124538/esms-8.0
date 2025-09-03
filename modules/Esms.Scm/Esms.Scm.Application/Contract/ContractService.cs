using Esms.Ddd.Application;
using Esms.Ddd.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esms.Scm.Contract
{
    public class ContractService : EsmsDddApplicationService, IContractService
    {
        public async Task AddAbpTest(int count)
        {
            int dbCount = await DbContext.Queryable<AbpTest>().CountAsync();
            List<decimal> idList = new List<decimal>();
            for (int i = 0; i < count; i++)
            {
                dbCount++;
                await DbContext.Insertable(new AbpTest { Name = dbCount.ToString() }).ExecuteCommandAsync();
                idList.Add(Convert.ToDecimal((await DbContext.Queryable<AbpTest>().FirstAsync(x => x.Name == dbCount.ToString())).Id));
            }
            Console.WriteLine("你好");
        }
    }
}
