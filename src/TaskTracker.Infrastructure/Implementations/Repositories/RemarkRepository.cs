using Microsoft.EntityFrameworkCore;
using TaskTracker.Application.Abstractions.Repository;
using TaskTracker.Application.Filters;
using TaskTracker.Core.Entities;
using TaskTracker.Infrastructure.Context;

namespace TaskTracker.Infrastructure.Implementations.Repositories;

internal sealed class RemarkRepository : RepositoryBase<RemarkEntity>, IRemarkRepository
{
    public RemarkRepository(ApplicationDbContext context) : base(context)
    {
        
    }

    public async Task<IEnumerable<RemarkEntity>> GetEntitiesAsync(RemarkFilter filter, CancellationToken cancellationToken)
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

        query = query
            .Skip((filter.Page - 1) * filter.PageSize)
            .Take(filter.PageSize);

        return await query.ToListAsync(cancellationToken);
    }
}
