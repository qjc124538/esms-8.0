
using Esms.Account.Domain;
using Esms.Ddd.Application;

namespace Esms.Account.WebApi
{
    public class EsmsAccountUnitOfWorkMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var endpoint = context.GetEndpoint();
            var esmsSqlSugarUnitOfWorkAttribute = endpoint?.Metadata?.GetMetadata<EsmsSqlSugarUnitOfWorkAttribute>();
            bool useUow = esmsSqlSugarUnitOfWorkAttribute != null && esmsSqlSugarUnitOfWorkAttribute.IsEnable == true;
            if (useUow)
            {
                EsmsAccountSqlSugarClient dbContext = context.RequestServices.GetRequiredService<EsmsAccountSqlSugarClient>();
                using (var uow = dbContext.CreateContext())
                {
                    await next(context);
                    uow.Commit();
                }
            }
            else
            {
                await next(context);
            }
        }
    }
}
