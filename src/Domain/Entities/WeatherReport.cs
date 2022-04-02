using CleanWorkerService.Domain.Common;

namespace CleanWorkerService.Domain.Entities;

public class WeatherReport : TimestampedEntity
{
    public string City { get; set; }
    public double Temperature { get; set; }

    public override string ToString()
    {
        return $"At {Created} it is {Temperature} in {City}";
    }
}