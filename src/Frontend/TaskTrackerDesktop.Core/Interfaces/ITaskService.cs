using System;
using System.Threading;
using System.Threading.Tasks;
using TaskTrackerDesktop.Core.Filters;
using TaskTrackerDesktop.Core.Responses.Task;

namespace TaskTrackerDesktop.Core.Interfaces;

public interface ITaskService
{
    Task<GetTaskResponse> GetTaskAsync(Guid id, CancellationToken cancellationToken = default);
    Task<GetTaskEntitiesResponse> GetTasksAsync(TaskFilterForm filter, CancellationToken cancellationToken = default);
}
