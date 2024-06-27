using System.Diagnostics;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
IConfigurationRoot configuration;
if (environment == "Development")
{
    configuration = new ConfigurationBuilder()
    .AddJsonFile("ocelotDev.json")
    .Build();
}
else
{
    configuration = new ConfigurationBuilder()
    .AddJsonFile("ocelot.json")
    .Build();
}
Log.Logger = new LoggerConfiguration()
        .WriteTo.Seq("http://host.docker.internal:8080")
        .CreateLogger();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddOcelot(configuration);
builder.Services.AddSwaggerForOcelot(configuration);
var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerForOcelotUI();
//}
app.Use(async (context, next) =>
{
    var stopwatch = Stopwatch.StartNew();
    await next();
    stopwatch.Stop();

    var responseTimeMs = stopwatch.ElapsedMilliseconds;
    if (responseTimeMs > 500)
    {
        Log.Warning($"Request {context.Request.Path} took {responseTimeMs}ms");
    }
});
app.UseHttpsRedirection();
app.UseOcelot().Wait();

app.UseAuthorization();

app.MapControllers();

app.Run();
