using Microsoft.EntityFrameworkCore;
using TaskTracker.Application.Abstractions.Repository;
using TaskTracker.Application.Filters;
using TaskTracker.Core.Entities;
using TaskTracker.Infrastructure.Context;

namespace TaskTracker.Infrastructure.Implementations.Repositories;

internal sealed class TagRepository : RepositoryBase<TagEntity>, ITagRepository
{
    public TagRepository(ApplicationDbContext context) : base(context)
    {
        
    }

    public async Task<IEnumerable<TagEntity>> GetEntitiesAsync(TagFilter filter, CancellationToken cancellationToken)
    {
        var query = _dbSet.AsQueryable();

        if (filter.Name != null)
            query = query.Where(x => x.Name == filter.Name);

        if (filter.From != null)
            query = query.Where(x => x.CreatedAt >= filter.From);

        if (filter.To != null)
            query = query.Where(x => x.CreatedAt <= filter.To);

        if (filter.ProcessId != null)
            query = query.Where(x => x.ProcessId == filter.ProcessId);

        query = query.OrderBy(x => x.CreatedAt);

        query = query
            .Skip((filter.Page - 1) * filter.PageSize)
            .Take(filter.PageSize);

        return await query.ToListAsync(cancellationToken);
    }
}
