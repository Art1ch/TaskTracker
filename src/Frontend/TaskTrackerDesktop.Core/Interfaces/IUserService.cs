using System;
using System.Threading;
using System.Threading.Tasks;
using TaskTrackerDesktop.Core.Filters;
using TaskTrackerDesktop.Core.Responses.User;

namespace TaskTrackerDesktop.Core.Interfaces;

public interface IUserService
{
    Task<GetUserResponse> GetUserAsync(Guid id, CancellationToken cancellationToken = default);
    Task<GetUserEntitiesResponse> GetUsersAsync(UserFilterForm filter, CancellationToken cancellationToken = default);
}
