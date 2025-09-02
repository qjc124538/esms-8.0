using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Esms.Ddd.Domain
{
    public class EsmsDddSqlSugarClient: SqlSugarClient
    {
        public EsmsDddSqlSugarClient(ConnectionConfig config) : base(config)
        {
        }
    }
}
