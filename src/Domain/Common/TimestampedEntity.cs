namespace CleanWorkerService.Domain.Common;

public abstract class TimestampedEntity : BaseEntity
{
    public DateTime Created { get; set; }
}