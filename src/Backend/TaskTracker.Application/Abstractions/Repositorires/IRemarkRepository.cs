using TaskTracker.Application.Filters;
using TaskTracker.Application.Results;
using TaskTracker.Core.Entities;

namespace TaskTracker.Application.Abstractions.Repository;

public interface IRemarkRepository : IRepository<RemarkEntity>
{
    Task<GetRemarkEntitiesResult> GetEntitiesAsync(RemarkFilter filter, CancellationToken cancellationToken = default);
}