using CleanWorkerService.Domain.Entities;

namespace CleanWorkerService.Application.Common.Interfaces;

public interface IWeatherReport
{
    WeatherReport GetRandom();
}