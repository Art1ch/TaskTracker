using Microsoft.EntityFrameworkCore;
using TaskTracker.Application.Abstractions.Repository;
using TaskTracker.Application.Filters;
using TaskTracker.Application.Results;
using TaskTracker.Application.Results.Items;
using TaskTracker.Core.Entities;
using TaskTracker.Infrastructure.Context;

namespace TaskTracker.Infrastructure.Implementations.Repositories;

internal sealed class RemarkRepository : RepositoryBase<RemarkEntity>, IRemarkRepository
{
    public RemarkRepository(ApplicationDbContext context) : base(context)
    {

    }

    public async Task<GetRemarkEntitiesResult> GetEntitiesAsync(RemarkFilter filter, CancellationToken cancellationToken = default)
    {
        var query = _dbSet.AsQueryable();

        if (filter.Text != null)
            query = query.Where(x => x.Text == filter.Text);

        if (filter.From != null)
            query = query.Where(x => x.CreatedAt >= filter.From);

        if (filter.To != null)
            query = query.Where(x => x.CreatedAt <= filter.To);

        if (filter.TaskId != null)
            query = query.Where(x => x.TaskId == filter.TaskId);

        query = query.OrderBy(x => x.CreatedAt);

        var totalCount = await query.CountAsync();
        var totalPages = (int)Math.Ceiling(totalCount / (double)filter.PageSize);

        var hasPreviousPage = filter.Page > 1;
        var hasNextPage = filter.Page < totalPages;

        var itemQuery = query
            .Skip((filter.Page - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(x => new RemarkItem(
                x.Id,
                x.Text,
                x.User.FirstName,
                x.User.LastName,
                x.User.UserRole
            ));
        
        var remarks = await itemQuery.ToListAsync(cancellationToken);

        return new GetRemarkEntitiesResult(remarks, filter.Page, filter.PageSize, totalPages, totalCount, hasNextPage, hasPreviousPage);
    }
}
