using Microsoft.EntityFrameworkCore;
using TaskTracker.Application.Abstractions.Repository;
using TaskTracker.Application.Filters;
using TaskTracker.Application.Results;
using TaskTracker.Core.Entities;
using TaskTracker.Infrastructure.Context;

namespace TaskTracker.Infrastructure.Implementations.Repositories;

internal sealed class TagRepository : RepositoryBase<TagEntity>, ITagRepository
{
    public TagRepository(ApplicationDbContext context) : base(context)
    {

    }

    public async Task<GetTagEntitiesResult> GetEntitiesAsync(TagFilter filter, CancellationToken cancellationToken = default)
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

        var totalCount = await query.CountAsync();
        var totalPages = (int)Math.Ceiling(totalCount / (double)filter.PageSize);

        var hasPreviousPage = filter.Page > 1;
        var hasNextPage = filter.Page < totalPages;

        query = query
            .Skip((filter.Page - 1) * filter.PageSize)
            .Take(filter.PageSize);

        var tags = await query.ToListAsync(cancellationToken);

        return new GetTagEntitiesResult(tags, filter.Page, filter.PageSize, totalPages, totalCount, hasNextPage, hasPreviousPage);
    }
}
