using CleanWorkerService.Application.Common;
using CleanWorkerService.Application.Common.Interfaces;
using CleanWorkerService.Application.Common.Models.Configuration;
using Microsoft.Extensions.Options;

namespace CleanWorkerService.ConsoleUI;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IDateTimeService _dateTimeService;
    private readonly IWeatherReportService _weatherReportService;
    private readonly WeatherReportRepository _weatherReportRepository;
    private readonly CooldownSettings _settings;

    public Worker(ILogger<Worker> logger, IDateTimeService dateTimeService, IOptions<CooldownSettings> settings,
        IWeatherReportService weatherReportService, WeatherReportRepository weatherReportRepository)
    {
        _logger = logger;
        _dateTimeService = dateTimeService;
        _weatherReportService = weatherReportService;
        _weatherReportRepository = weatherReportRepository;
        _settings = settings.Value;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (true)
        {
            var report = _weatherReportService.GetRandom();
            _logger.LogInformation("Weather Report: {weatherReport}", report);
            await _weatherReportRepository.Create(report);
            await Task.Delay(_settings.Cd, stoppingToken);
        }
        // Environment.Exit(0);
    }
}