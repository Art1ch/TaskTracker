using TaskTracker.Application.Filters;
using TaskTracker.Core.Entities;

namespace TaskTracker.Application.Abstractions.Repository;

public interface IUserRepository : IRepository<UserEntity>
{
    Task<IEnumerable<UserEntity>> GetEntitiesAsync(UserFilter filter, CancellationToken cancellationToken);
}
