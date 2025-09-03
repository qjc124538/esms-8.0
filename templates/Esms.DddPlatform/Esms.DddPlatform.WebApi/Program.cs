using Esms.DddPlatform.WebApi;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseAutofac();
await builder.AddApplicationAsync<EsmsDddPlatformWebApiInternalModule>();
var app = builder.Build();
await app.InitializeApplicationAsync();
await app.RunAsync();
