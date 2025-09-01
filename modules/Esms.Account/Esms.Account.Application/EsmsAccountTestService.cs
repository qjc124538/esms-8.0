using Esms.Account.Application.Contracts;
using Esms.Account.Domain;
using Esms.Ddd.Application;
using Esms.Ddd.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Esms.Account.Application
{
    public class EsmsAccountTestService: EsmsApplicationService, IEsmsAccountTestService
    {
        private readonly EsmsAccountSqlSugarClient esmsAccountDbContext;

        public EsmsAccountTestService(EsmsAccountSqlSugarClient _esmsAccountDbContext)
        {
            esmsAccountDbContext = _esmsAccountDbContext;
        }

        public async Task AddAbpTestList(int count)
        {
            int dbCount = await esmsAccountDbContext.Queryable<AbpTest>().CountAsync();
            for (int i = 0; i < count; i++)
            {
                dbCount++;
                await esmsAccountDbContext.Insertable(new AbpTest { Name = "R: " + dbCount }).ExecuteCommandAsync();
            }
        }

        public async Task<string> Excute()
        {
            return await Task.FromResult("EsmsAccountTestService: 成功");
        }

        public async Task<string> GetAbpTestList()
        {
            var list = await esmsAccountDbContext.Queryable<AbpTest>().ToListAsync();
            return JsonSerializer.Serialize(list);
        }
    }
}
