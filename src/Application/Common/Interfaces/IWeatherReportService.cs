using CleanWorkerService.Domain.Entities;

namespace CleanWorkerService.Application.Common.Interfaces;

public interface IWeatherReportService
{
    WeatherReport GetRandom();
}