namespace CleanWorkerService.Application.Common.Models.Configuration;

public abstract class BaseSettings
{
    public virtual string SectionName => this.GetType().Name;
}