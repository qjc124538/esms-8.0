using Esms.Ddd.Domain.Shared.Accessors;
using System;

namespace Esms.Ddd.WebApi.Extensions
{
    public static class EsmsDddCurrentPrincipalAccessorExtension
    {
        public static IServiceCollection AddEsmsDddCurrentPrincipalAccessor(this IServiceCollection services, Func<EsmsDddCurrentPrincipalAccessor> func)
        {
            services.AddScoped(sp => 
            {
                return func();
            });
            return services;
        }
    }
}
