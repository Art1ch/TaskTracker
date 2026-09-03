using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskTrackerDesktop.Core.Filters;
using TaskTrackerDesktop.Core.Models;

namespace TaskTrackerDesktop.Core.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserModel>> GetUsersAsync(UserFilterForm filter, CancellationToken cancellationToken = default);
    Task<UserModel> GetUserAsync(Guid Id, CancellationToken cancellationToken = default);
}
