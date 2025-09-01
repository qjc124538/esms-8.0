using Esms.Ddd.Domain;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esms.Platform.Domain
{
    public class EsmsPlatformSqlSugarClient : EsmsDddSqlSugarClient
    {
        public EsmsPlatformSqlSugarClient(ConnectionConfig config) : base(config)
        {
        }
    }
}
