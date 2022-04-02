using CleanWorkerService.Application.Common.Interfaces;
using CleanWorkerService.Application.Common.Models.Configuration;
using CleanWorkerService.Domain.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CleanWorkerService.Infrastructure.Services;

public class WeatherReportServiceService : IWeatherReportService
{
    private readonly ILogger<WeatherReportServiceService> _logger;
    private readonly IDateTimeService _dateTimeService;
    private readonly Random _rnd;
    private readonly WeatherReportSettings _settings;

    public WeatherReportServiceService(ILogger<WeatherReportServiceService> logger, IDateTimeService dateTimeService, Random rnd, IOptions<WeatherReportSettings> settings)
    {
        _logger = logger;
        _dateTimeService = dateTimeService;
        _rnd = rnd;
        _settings = settings.Value;
    }

    private static readonly string[] cities = { "Berlin", "London", "Bruessel" };

    public WeatherReport GetRandom()
    {
        return new WeatherReport()
        {
            Created = _dateTimeService.Now,
            City = cities[_rnd.Next(3)],
            Temperature = _rnd.Next(_settings.MinTemperature, _settings.MaxTemperature)
        };
    }
}