using Esms.Ddd.WebApi;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseAutofac();
await builder.AddApplicationAsync<EsmsDddWebApiInternalModule>();
var app = builder.Build();
await app.InitializeApplicationAsync();
await app.RunAsync();
