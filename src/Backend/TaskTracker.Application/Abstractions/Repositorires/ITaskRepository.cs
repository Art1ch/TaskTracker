using TaskTracker.Application.Filters;
using TaskTracker.Core.Entities;

namespace TaskTracker.Application.Abstractions.Repository;

public interface ITaskRepository : IRepository<TaskEntity>
{
    Task<IEnumerable<TaskEntity>> GetEntitiesAsync(TaskFilter filter, CancellationToken cancellationToken);
}
