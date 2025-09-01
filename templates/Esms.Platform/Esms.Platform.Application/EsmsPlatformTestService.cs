using Esms.Account.Application.Contracts;
using Esms.Ddd.Application;
using Esms.Ddd.Domain;
using Esms.Platform.Application.Contracts;
using Esms.Platform.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Esms.Platform.Application
{
    public class EsmsPlatformTestService : EsmsDddApplicationService, IEsmsPlatformTestService
    {
        private readonly EsmsPlatformSqlSugarClient esmsPlatformSqlSugarClient;

        private readonly IEsmsAccountTestService esmsAccountTestService;

        public EsmsPlatformTestService(EsmsPlatformSqlSugarClient _esmsPlatformSqlSugarClient, IEsmsAccountTestService _esmsAccountTestService)
        {
            esmsPlatformSqlSugarClient = _esmsPlatformSqlSugarClient;
            esmsAccountTestService = _esmsAccountTestService;
        }

        public async Task<List<decimal>> AddAbpTestListAsync(int count)
        {
            List<decimal> idList = new List<decimal>();
            try
            {
                idList = await esmsAccountTestService.AddAbpTestListAsync(count);
            }
            catch (Exception)
            {
                await esmsAccountTestService.DeleteAbpTestListAsync(idList);
                throw;
            }
            return idList;
        }

        public async Task DeleteAbpTestListAsync(List<decimal> idList)
        {
            await esmsAccountTestService.DeleteAbpTestListAsync(idList);
        }

        public async Task<string> ExcuteAsync()
        {
            return await Task.FromResult("EsmsPlatformTestService: 成功");
        }

        public async Task<string> GetAbpTestListAsync()
        {
            return await esmsAccountTestService.GetAbpTestListAsync();
        }
    }
}
