namespace CleanWorkerService.Application.Common.Models.Configuration;

public class WeatherReportSettings : BaseSettings
{
    public int MaxTemperature { get; set; }
    public int MinTemperature { get; set; }
}