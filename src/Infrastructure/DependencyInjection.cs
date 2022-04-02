using CleanWorkerService.Application.Common.Interfaces;
using CleanWorkerService.Infrastructure.Persistence;
using CleanWorkerService.Infrastructure.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanWorkerService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        if (configuration.GetValue<bool>("UseInMemoryDb"))
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("WeatherReportDb"), ServiceLifetime.Singleton);
        }
        else
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlite(new SqliteConnection(configuration.GetValue<string>("DbConnectionString")),
                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)),
                        ServiceLifetime.Singleton);
        }
        services.AddSingleton<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        
        services.AddTransient<Random>();
        services.AddTransient<IDateTime, DateTimeService>();
        services.AddTransient<IWeatherReport, WeatherReportService>();
        
        return services;
    }
}