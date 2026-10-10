using TaskTracker.Application.Filters;
using TaskTracker.Application.Results;
using TaskTracker.Core.Entities;

namespace TaskTracker.Application.Abstractions.Repository;

public interface IUserRepository : IRepository<UserEntity>
{
    Task<GetUserEntitiesResult> GetEntitiesAsync(UserFilter filter, CancellationToken cancellationToken = default);
}
