using Esms.Ddd.Domain;
using Esms.Ddd.Domain.Shared.Attributes;
using Microsoft.AspNetCore.Mvc.Filters;
using SqlSugar;
using Volo.Abp.AspNetCore.Mvc;

namespace Esms.Ddd.WebApi.Filters
{
    public class EsmsDddActionFilter: IActionFilter
    {
        public SugarUnitOfWork? SugarUnitOfWork { get; set; }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var endpoint = context.HttpContext.GetEndpoint();
            var enableEsmsDddSugarUnitOfWorkAttribute = endpoint?.Metadata.GetMetadata<EnableEsmsDddSugarUnitOfWorkAttribute>();
            if (enableEsmsDddSugarUnitOfWorkAttribute != null)
            {
                EsmsDddSqlSugarClient dbContext = context.GetRequiredService<EsmsDddSqlSugarClient>();
                SugarUnitOfWork = dbContext.CreateContext();
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (SugarUnitOfWork != null)
            {
                if (context.Exception == null)
                {
                    SugarUnitOfWork.Commit();
                }
                SugarUnitOfWork.Dispose();
            }
        }
    }
}
