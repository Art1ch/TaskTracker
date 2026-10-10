using Microsoft.EntityFrameworkCore;
using TaskTracker.Application.Abstractions.Repository;
using TaskTracker.Application.Filters;
using TaskTracker.Application.Results;
using TaskTracker.Core.Entities;
using TaskTracker.Infrastructure.Context;

namespace TaskTracker.Infrastructure.Implementations.Repositories;

internal sealed class TaskRepository : RepositoryBase<TaskEntity>, ITaskRepository
{
    public TaskRepository(ApplicationDbContext context) : base(context)
    {

    }

    public async Task<GetTaskEntitiesResult> GetEntitiesAsync(TaskFilter filter, CancellationToken cancellationToken = default)
    {
        var query = _dbSet.AsQueryable();

        if (filter.ProcessId != null)
            query = query.Where(x => x.ProcessId == filter.ProcessId);

        if (filter.AssignedToId != null)
            query = query.Where(x => x.AssignedToId == filter.AssignedToId);

        if (filter.CreatedById != null)
            query = query.Where(x => x.CreatedById == filter.CreatedById);

        if (filter.From != null)
            query = query.Where(x => x.CreatedAt >= filter.From);

        if (filter.To != null)
            query = query.Where(x => x.CreatedAt <= filter.To);

        if (filter.Title != null)
            query = query.Where(x => x.Title == filter.Title);

        if (filter.Description != null)
            query = query.Where(x => x.Description == filter.Description);

        if (filter.Deadline != null)
            query = query.Where(x => x.Deadline == filter.Deadline);

        if (filter.TaskState != null)
            query = query.Where(x => x.TaskState == filter.TaskState);

        query = query.OrderBy(x => x.CreatedAt);

        var totalCount = await query.CountAsync();
        var totalPages = (int)Math.Ceiling(totalCount / (double)filter.PageSize);

        var hasPreviousPage = filter.Page > 1;
        var hasNextPage = filter.Page < totalPages;

        query = query
            .Skip((filter.Page - 1) * filter.PageSize)
            .Take(filter.PageSize);

        var tasks = await query.ToListAsync(cancellationToken);

        return new GetTaskEntitiesResult(tasks, filter.Page, filter.PageSize, totalPages, totalCount, hasNextPage, hasPreviousPage);
    }
}
