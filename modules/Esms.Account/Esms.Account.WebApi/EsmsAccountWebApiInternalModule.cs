using Esms.Account.Application;
using Esms.Account.Domain;
using Esms.Ddd.Application;
using Esms.Ddd.WebApi;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SqlSugar;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.AntiForgery;
using Volo.Abp.Modularity;

namespace Esms.Account.WebApi
{
    [DependsOn(
        typeof(EsmsAccountApplicationModule),
        typeof(EsmsDddWebApiModule)
        )]
    internal class EsmsAccountWebApiInternalModule: AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(EsmsAccountApplicationModule).Assembly);
            });
            var configuration = context.Services.GetConfiguration();
            var hostEnvironment = context.Services.GetAbpHostEnvironment();
            context.Services.AddScoped(options =>
            {
                var connectionConfig = new ConnectionConfig
                {
                    ConnectionString = configuration["ConnectionStrings:EsmsAccount"] ?? configuration["ConnectionStrings:Default"],
                    IsAutoCloseConnection = true
                };
                var dataBaseType = configuration["DataBaseType"] ?? "Dm";
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
                EsmsAccountSqlSugarClient esmsAccountDbContext = new EsmsAccountSqlSugarClient(connectionConfig);
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
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "EsmsAccount API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseAbpSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "EsmsAccount API");
            });
            app.UseRouting();
            app.UseConfiguredEndpoints();
        }
    }
}
