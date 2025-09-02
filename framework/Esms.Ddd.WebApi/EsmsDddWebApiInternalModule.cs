using Esms.Ddd.Application;
using Esms.Ddd.Domain;
using Esms.Ddd.Domain.Shared.Accessors;
using Esms.Ddd.WebApi.Filters;
using Microsoft.OpenApi.Models;
using SqlSugar;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.AntiForgery;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;

namespace Esms.Ddd.WebApi
{
    [DependsOn(
        typeof(EsmsDddApplicationModule),
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutofacModule),
        typeof(AbpSwashbuckleModule)
        )]
    internal class EsmsDddWebApiInternalModule: AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            var hostEnvironment = context.Services.GetAbpHostEnvironment();
            if (hostEnvironment.IsDevelopment())
            {
                Configure<AbpAntiForgeryOptions>(options =>
                {
                    options.TokenCookie.SecurePolicy = CookieSecurePolicy.Always;
                });
            }
            PreConfigure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(EsmsDddApplicationModule).Assembly);
            });
            context.Services.AddScoped(sp =>
            {
                var connectionConfig = new ConnectionConfig
                {
                    ConnectionString = configuration["ConnectionStrings:Default"],
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
            context.Services.AddControllers(options =>
            {
                options.Filters.Add<EsmsDddActionFilter>();
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "EsmsDdd API", Version = "v1" });
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
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "EsmsDdd API");
            });
            app.UseRouting();
            app.UseConfiguredEndpoints();
        }
    }
}
