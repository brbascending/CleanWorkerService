using CleanWorkerService.Application.Common.Interfaces;

namespace CleanWorkerService.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}