using CleanWorkerService.Application.Common.Interfaces;
using CleanWorkerService.Application.Common.Models.Configuration;
using CleanWorkerService.Domain.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CleanWorkerService.Infrastructure.Services;

public class WeatherReportService : IWeatherReport
{
    private readonly ILogger<WeatherReportService> _logger;
    private readonly IDateTime _dateTime;
    private readonly Random _rnd;
    private readonly WeatherReportSettings _settings;

    public WeatherReportService(ILogger<WeatherReportService> logger, IDateTime dateTime, Random rnd, IOptions<WeatherReportSettings> settings)
    {
        _logger = logger;
        _dateTime = dateTime;
        _rnd = rnd;
        _settings = settings.Value;
    }

    private static readonly string[] cities = { "Berlin", "London", "Bruessel" };

    public WeatherReport GetRandom()
    {
        return new WeatherReport()
        {
            Created = _dateTime.Now,
            City = cities[_rnd.Next(3)],
            Temperature = _rnd.Next(_settings.MinTemperature, _settings.MaxTemperature)
        };
    }
}