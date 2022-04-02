using CleanWorkerService.Application.Common.Interfaces;
using CleanWorkerService.Domain.Entities;

namespace CleanWorkerService.Application.Common;

public class CreateWeatherReport
{
    private readonly IApplicationDbContext _dbContext;

    public CreateWeatherReport(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Add(WeatherReport report)
    {
        _dbContext.WeatherReports.Add(report);
        return await _dbContext.SaveChangesAsync(CancellationToken.None);
    }
}