using CleanWorkerService.Application.Common.Interfaces;

namespace CleanWorkerService.Infrastructure.Services;

public class DateTimeService : IDateTimeService
{
    public DateTime Now => DateTime.Now;
}