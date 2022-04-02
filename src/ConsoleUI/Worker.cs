using CleanWorkerService.Application.Common;
using CleanWorkerService.Application.Common.Interfaces;
using CleanWorkerService.Application.Common.Models.Configuration;
using Microsoft.Extensions.Options;

namespace CleanWorkerService.ConsoleUI;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IDateTime _dateTime;
    private readonly IWeatherReport _weatherReport;
    private readonly CreateWeatherReport _createWeatherReport;
    private readonly CooldownSettings _settings;

    public Worker(ILogger<Worker> logger, IDateTime dateTime, IOptions<CooldownSettings> settings, IWeatherReport weatherReport,
        CreateWeatherReport createWeatherReport)
    {
        _logger = logger;
        _dateTime = dateTime;
        _weatherReport = weatherReport;
        _createWeatherReport = createWeatherReport;
        _settings = settings.Value;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (true)
        {
            var report = _weatherReport.GetRandom();
            _logger.LogInformation("Weather Report: {weatherReport}", report);
            await _createWeatherReport.Add(report);
            await Task.Delay(_settings.Cd, stoppingToken);
        }
        // Environment.Exit(0);
    }
}