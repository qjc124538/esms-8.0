using Dm.util;
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
    public class EsmsAccountTestService: EsmsDddApplicationService, IEsmsAccountTestService
    {
        private readonly EsmsAccountSqlSugarClient esmsAccountSqlSugarClient;

        public EsmsAccountTestService(EsmsAccountSqlSugarClient _esmsAccountSqlSugarClient)
        {
            esmsAccountSqlSugarClient = _esmsAccountSqlSugarClient;
        }

        public async Task<List<decimal>> AddAbpTestListAsync(int count)
        {
            int dbCount = await esmsAccountSqlSugarClient.Queryable<AbpTest>().CountAsync();
            List<decimal> idList = new List<decimal>();
            for (int i = 0; i < count; i++)
            {
                dbCount++;
                string name = "EsmsAccountTestService: " + dbCount;
                await esmsAccountSqlSugarClient.Insertable(new AbpTest { Name = name }).ExecuteCommandAsync();
                idList.Add(Convert.ToDecimal((await esmsAccountSqlSugarClient.Queryable<AbpTest>().FirstAsync(x => x.Name == name)).Id));
            }
            return idList;
        }

        public async Task DeleteAbpTestListAsync(List<decimal> idList)
        {
            foreach (decimal id in idList)
            {
                await esmsAccountSqlSugarClient.Deleteable<AbpTest>(x => x.Id == id).ExecuteCommandAsync();
            }
        }

        public async Task<string> ExcuteAsync()
        {
            return await Task.FromResult("EsmsAccountTestService: 成功");
        }

        public async Task<string> GetAbpTestListAsync()
        {
            var list = await esmsAccountSqlSugarClient.Queryable<AbpTest>().ToListAsync();
            return JsonSerializer.Serialize(list);
        }
    }
}
