using Esms.Ddd.Domain;
using SqlSugar;

namespace Esms.Account.Domain
{
    public class EsmsAccountSqlSugarClient : EsmsSqlSugarClient
    {
        public EsmsAccountSqlSugarClient(ConnectionConfig config) : base(config)
        {
        }
    }
}
