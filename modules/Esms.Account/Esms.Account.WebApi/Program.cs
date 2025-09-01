using Esms.Account.WebApi;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseAutofac();
await builder.AddApplicationAsync<EsmsAccountWebApiInternalModule>();
var app = builder.Build();
await app.InitializeApplicationAsync();
await app.RunAsync();