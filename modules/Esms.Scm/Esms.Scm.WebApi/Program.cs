using Esms.Scm.WebApi;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseAutofac();
await builder.AddApplicationAsync<EsmsScmWebApiInternalModule>();
var app = builder.Build();
await app.InitializeApplicationAsync();
await app.RunAsync();
