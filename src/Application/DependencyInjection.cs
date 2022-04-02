using System.Reflection;
using CleanWorkerService.Application.Common;
using CleanWorkerService.Application.Common.Models.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanWorkerService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddAllOptions(this IServiceCollection services, IConfiguration configuration)
    {
        foreach (var type in
                 Assembly.GetAssembly(typeof(BaseSettings)).GetTypes()
                     .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(BaseSettings))))
        {
            var configurationInstance = (BaseSettings)Activator.CreateInstance(type);
            if (configurationInstance != null)
            {
                var configurationSection = configuration.GetSection(configurationInstance.SectionName);
                var configureMethod = typeof(OptionsConfigurationServiceCollectionExtensions).GetMethods()
                    .Where(x => x.Name == "Configure")
                    .Single(m => m.GetParameters().Length == 2)
                    .MakeGenericMethod(type);
                configureMethod.Invoke(null, new object[] { services, configurationSection });
            }
        }

        services.AddTransient<WeatherReportRepository>();
        
        return services;
    }
}