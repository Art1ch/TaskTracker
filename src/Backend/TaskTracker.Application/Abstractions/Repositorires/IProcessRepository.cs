using TaskTracker.Application.Filters;
using TaskTracker.Application.Results;
using TaskTracker.Core.Entities;

namespace TaskTracker.Application.Abstractions.Repository;

public interface IProcessRepository : IRepository<ProcessEntity>
{
    Task<GetProcessEntitiesResult> GetEntitiesAsync(ProcessFilter filter, CancellationToken cancellationToken = default);
    Task AddUserToProcessAsync(Guid processId, Guid userId, CancellationToken cancellationToken = default);
}
