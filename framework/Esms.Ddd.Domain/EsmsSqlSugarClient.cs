using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esms.Ddd.Domain
{
    public abstract class EsmsSqlSugarClient : SqlSugarClient
    {
        public EsmsSqlSugarClient(ConnectionConfig config) : base(config)
        {
        }
    }
}
