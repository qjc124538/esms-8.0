using Esms.Ddd.Domain;
using Microsoft.Extensions.Hosting;
using SqlSugar;
using Volo.Abp;

namespace Esms.Ddd.WebApi.Extensions
{
    public static class EsmsDddDbContextExtension
    {
        public static IServiceCollection AddEsmsDddDbContext(this IServiceCollection services, string? dataBaseType = null, string? connectionString = null)
        {
            var configuration = services.GetConfiguration();
            var hostEnvironment = services.GetAbpHostEnvironment();
            dataBaseType = dataBaseType ?? configuration["DataBaseType"];
            connectionString = connectionString ?? configuration["ConnectionStrings:Default"];
            services.AddScoped(sp =>
            {
                var connectionConfig = new ConnectionConfig
                {
                    ConnectionString = connectionString,
                    IsAutoCloseConnection = true
                };
                if (dataBaseType.Equals("Dm"))
                {
                    connectionConfig.DbType = DbType.Dm;
                }
                else if (dataBaseType.Equals("Oracle"))
                {
                    connectionConfig.DbType = DbType.Oracle;
                }
                else
                {
                    throw new NotImplementedException();
                }
                EsmsDddSqlSugarClient esmsAccountDbContext = new EsmsDddSqlSugarClient(connectionConfig);
                if (hostEnvironment.IsDevelopment())
                {
                    esmsAccountDbContext.Context.Aop.OnLogExecuting = (s, p) =>
                    {
                        foreach (var item in p)
                        {
                            if (item.Value == null)
                            {
                                continue;
                            }
                            else if (item.DbType.ToString().ToLower() == "string")
                            {
                                s = s.Replace(item.ParameterName, "'" + item.Value.ToString() + "'");
                            }
                            else if (item.DbType.ToString().ToLower() == "datetime")
                            {
                                s = s.Replace(item.ParameterName, "to_date('" + item.Value.ToString() + "','yyyy-mm-dd hh24:mi:ss')");
                            }
                            else if (item.DbType.ToString().ToLower() == "boolean")
                            {
                                s = s.Replace(item.ParameterName, Convert.ToBoolean(item.Value) == true ? "1" : "0");
                            }
                            else
                            {
                                s = s.Replace(item.ParameterName, item.Value.ToString());
                            }
                        }
                        Console.WriteLine(s.Trim() + (s.EndsWith(";") ? "" : ";"));
                    };
                }
                return esmsAccountDbContext;
            });
            return services;
        }
    }
}
