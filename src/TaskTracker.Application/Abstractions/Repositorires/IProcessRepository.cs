using TaskTracker.Application.Filters;
using TaskTracker.Core.Entities;

namespace TaskTracker.Application.Abstractions.Repository;

public interface IProcessRepository : IRepository<ProcessEntity>
{
    Task<IEnumerable<ProcessEntity>> GetEntitiesAsync(ProcessFilter filter, CancellationToken cancellationToken);
}
