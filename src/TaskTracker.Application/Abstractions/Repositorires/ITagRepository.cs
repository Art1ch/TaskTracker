using TaskTracker.Application.Filters;
using TaskTracker.Core.Entities;

namespace TaskTracker.Application.Abstractions.Repository;

public interface ITagRepository : IRepository<TagEntity>
{
    Task<IEnumerable<TagEntity>> GetEntitiesAsync(TagFilter filter, CancellationToken cancellationToken);
}
