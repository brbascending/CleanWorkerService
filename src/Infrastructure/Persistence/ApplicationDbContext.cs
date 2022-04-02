using CleanWorkerService.Application.Common.Interfaces;
using CleanWorkerService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanWorkerService.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)        
    {        
    }

    public DbSet<WeatherReport> WeatherReports => Set<WeatherReport>();

    public void Migrate()
    {
        Database.Migrate();
    }
}