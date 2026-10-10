using TaskTracker.Application.Filters;
using TaskTracker.Application.Results;
using TaskTracker.Core.Entities;

namespace TaskTracker.Application.Abstractions.Repository;

public interface ITaskRepository : IRepository<TaskEntity>
{
    Task<GetTaskEntitiesResult> GetEntitiesAsync(TaskFilter filter, CancellationToken cancellationToken = default);
}
