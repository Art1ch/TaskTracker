using Microsoft.EntityFrameworkCore;
using TaskTracker.Application.Abstractions.Repository;
using TaskTracker.Application.Filters;
using TaskTracker.Application.Results;
using TaskTracker.Core.Entities;
using TaskTracker.Infrastructure.Context;

namespace TaskTracker.Infrastructure.Implementations.Repositories;

internal sealed class ProcessRepository : RepositoryBase<ProcessEntity>, IProcessRepository
{
    public ProcessRepository(ApplicationDbContext context) : base(context)  
    {
        
    }

    public async Task AddUserToProcessAsync(Guid processId, Guid userId, CancellationToken cancellationToken = default)
    {
        var process = await _dbSet
            .Include(x => x.Users)
            .FirstAsync(x => x.Id == processId, cancellationToken);

        if (process.Users.Any(x => x.Id == userId))
            throw new InvalidOperationException();

        var user = await _context
            .Set<UserEntity>()
            .FirstAsync(x => x.Id == userId, cancellationToken);

        process.Users.Add(user);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<GetProcessEntitiesResult> GetEntitiesAsync(ProcessFilter filter, CancellationToken cancellationToken = default)
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

        var totalCount = await query.CountAsync(cancellationToken);
        var totalPages = (int)Math.Ceiling(totalCount / (double)filter.PageSize);

        var hasPreviousPage = filter.Page > 1;
        var hasNextPage = filter.Page < totalPages;

        query = query
            .Skip((filter.Page - 1) * filter.PageSize)
            .Take(filter.PageSize);

        var processes = await query.ToListAsync(cancellationToken);

        return new GetProcessEntitiesResult(processes, filter.Page, filter.PageSize, totalPages, totalCount, hasNextPage, hasPreviousPage);
    }
}
