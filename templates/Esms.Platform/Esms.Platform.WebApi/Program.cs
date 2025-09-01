
using Esms.Platform.WebApi;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseAutofac();
await builder.AddApplicationAsync<EsmsPlatformWebApiInternalModule>();
var app = builder.Build();
await app.InitializeApplicationAsync();
await app.RunAsync();