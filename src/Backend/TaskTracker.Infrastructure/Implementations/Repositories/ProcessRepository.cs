using Microsoft.EntityFrameworkCore;
using TaskTracker.Application.Abstractions.Repository;
using TaskTracker.Application.Filters;
using TaskTracker.Core.Entities;
using TaskTracker.Infrastructure.Context;

namespace TaskTracker.Infrastructure.Implementations.Repositories;

internal sealed class ProcessRepository : RepositoryBase<ProcessEntity>, IProcessRepository
{
    public ProcessRepository(ApplicationDbContext context) : base(context)  
    {
        
    }

    public async Task<IEnumerable<ProcessEntity>> GetEntitiesAsync(ProcessFilter filter, CancellationToken cancellationToken)
    {
        var query = _dbSet.AsQueryable();

        if (filter.Name != null)
            query = query.Where(x => x.Name == filter.Name);

        if (filter.From != null)
            query = query.Where(x => x.CreatedAt >= filter.From);

        if (filter.To != null)
            query = query.Where(x => x.CreatedAt <= filter.To);

        if (filter.Description != null)
            query = query.Where(x => x.Description == filter.Description);

        if (filter.IsActive != null)
            query = query.Where(x => x.IsActive == filter.IsActive);

        query = query.OrderBy(x => x.CreatedAt);

        query = query
            .Skip((filter.Page - 1) * filter.PageSize)
            .Take(filter.PageSize);

        return await query.ToListAsync(cancellationToken);
    }
}
