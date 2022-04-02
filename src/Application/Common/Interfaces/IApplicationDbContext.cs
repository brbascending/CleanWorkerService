using CleanWorkerService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanWorkerService.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<WeatherReport> WeatherReports { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    void Migrate();
}