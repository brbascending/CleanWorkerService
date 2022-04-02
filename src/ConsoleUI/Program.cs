using CleanWorkerService.Application;
using CleanWorkerService.Application.Common.Interfaces;
using CleanWorkerService.ConsoleUI;
using CleanWorkerService.Infrastructure;
using Serilog;

var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true);

var configurationRoot = builder.Build();

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddInfrastructure(configurationRoot);
        services.AddAllOptions(configurationRoot);
        services.AddHostedService<Worker>();
    })
    .ConfigureLogging(logging =>
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configurationRoot)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();
    })
    .UseSerilog()
    .Build();

if (!configurationRoot.GetValue<bool>("UseInMemoryDb"))
{
    var dbContext = host.Services.GetService<IApplicationDbContext>();
    dbContext.Migrate();
}

await host.RunAsync();