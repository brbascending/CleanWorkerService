using CleanWorkerService.Application.Common.Interfaces;
using CleanWorkerService.Domain.Entities;

namespace CleanWorkerService.Application.Common;

public class WeatherReportRepository
{
    private readonly IApplicationDbContext _dbContext;

    public WeatherReportRepository(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Create(WeatherReport report)
    {
        _dbContext.WeatherReports.Add(report);
        return await _dbContext.SaveChangesAsync(CancellationToken.None);
    }
}