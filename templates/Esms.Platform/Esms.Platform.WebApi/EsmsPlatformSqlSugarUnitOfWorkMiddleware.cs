using Esms.Ddd.Application;
using Esms.Ddd.WebApi;
using Esms.Platform.Domain;

namespace Esms.Platform.WebApi
{
    public class EsmsPlatformSqlSugarUnitOfWorkMiddleware: EsmsDddSqlSugarUnitOfWorkMiddleware<EsmsPlatformSqlSugarClient>
    {
    }
}
