using System;
using System.Threading;
using System.Threading.Tasks;
using TaskTrackerDesktop.Core.Filters;
using TaskTrackerDesktop.Core.Responses.Remark;

namespace TaskTrackerDesktop.Core.Interfaces;

public interface IRemarkService
{
    Task<GetRemarkResponse> GetRemarkAsync(Guid id, CancellationToken cancellationToken = default);
    Task<GetRemarkEntitiesResponse> GetRemarksAsync(RemarkFilterForm filter, CancellationToken cancellationToken = default);
}
