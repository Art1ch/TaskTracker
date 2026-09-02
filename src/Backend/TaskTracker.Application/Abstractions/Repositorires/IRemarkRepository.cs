using TaskTracker.Application.Filters;
using TaskTracker.Core.Entities;

namespace TaskTracker.Application.Abstractions.Repository;

public interface IRemarkRepository : IRepository<RemarkEntity>
{
    Task<IEnumerable<RemarkEntity>> GetEntitiesAsync(RemarkFilter filter, CancellationToken cancellationToken);
}