using Microsoft.EntityFrameworkCore;
using TaskTracker.Application.Abstractions.Repository;
using TaskTracker.Application.Filters;
using TaskTracker.Application.Results;
using TaskTracker.Core.Entities;
using TaskTracker.Infrastructure.Context;

namespace TaskTracker.Infrastructure.Implementations.Repositories;

internal sealed class UserRepository : RepositoryBase<UserEntity>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {

    }

    public async Task<GetUserEntitiesResult> GetEntitiesAsync(UserFilter filter, CancellationToken cancellationToken = default)
    {
        var query = _dbSet.AsQueryable();

        if (filter.UserRole != null)
            query = query.Where(x => x.UserRole == filter.UserRole);

        if (filter.From != null)
            query = query.Where(x => x.CreatedAt >= filter.From);

        if (filter.To != null)
            query = query.Where(x => x.CreatedAt <= filter.To);

        if (filter.FirstName != null)
            query = query.Where(x => x.FirstName == filter.FirstName);

        if (filter.LastName != null)
            query = query.Where(x => x.LastName == filter.LastName);

        query = query.OrderBy(x => x.CreatedAt);

        var totalCount = await query.CountAsync();
        var totalPages = (int)Math.Ceiling(totalCount / (double)filter.PageSize);

        var hasPreviousPage = filter.Page > 1;
        var hasNextPage = filter.Page < totalPages;

        query = query
            .Skip((filter.Page - 1) * filter.PageSize)
            .Take(filter.PageSize);

        var users = await query.ToListAsync(cancellationToken);

        return new GetUserEntitiesResult(users, filter.Page, filter.PageSize, totalPages, totalCount, hasNextPage, hasPreviousPage);
    }
}
