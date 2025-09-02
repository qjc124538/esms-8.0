using Esms.Ddd.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Esms.Ddd.Test
{
    public class EsmsDddTestService : EsmsDddApplicationService, IEsmsDddTestService
    {
        public async Task<List<decimal>> AddAbpTestListAsync(int count)
        {
            int dbCount = await DbContext.Queryable<AbpTest>().CountAsync();
            List<decimal> idList = new List<decimal>();
            for (int i = 0; i < count; i++)
            {
                dbCount++;
                await DbContext.Insertable(new AbpTest { Name = dbCount.ToString() }).ExecuteCommandAsync();
                idList.Add(Convert.ToDecimal((await DbContext.Queryable<AbpTest>().FirstAsync(x => x.Name == dbCount.ToString())).Id));
            }
            return idList;
        }

        public async Task DeleteAbpTestListAsync(List<decimal> idList)
        {
            foreach (decimal id in idList)
            {
                await DbContext.Deleteable<AbpTest>(x => x.Id == id).ExecuteCommandAsync();
            }
        }

        public async Task<string> ExcuteAsync()
        {
            return await Task.FromResult("成功");
        }

        public async Task<string> GetAbpTestListAsync()
        {
            var list = await DbContext.Queryable<AbpTest>().ToListAsync();
            return JsonSerializer.Serialize(list);
        }

        public async Task<string> GetCurrentPrincipalAccessor()
        {
            return await Task.FromResult(JsonSerializer.Serialize(CurrentPrincipalAccessor));
        }
    }
}
