using TaskTracker.Application.Filters;
using TaskTracker.Application.Results;
using TaskTracker.Core.Entities;

namespace TaskTracker.Application.Abstractions.Repository;

public interface ITagRepository : IRepository<TagEntity>
{
    Task<GetTagEntitiesResult> GetEntitiesAsync(TagFilter filter, CancellationToken cancellationToken = default);
}
