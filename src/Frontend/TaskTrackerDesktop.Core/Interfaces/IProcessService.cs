using System;
using System.Threading;
using System.Threading.Tasks;
using TaskTrackerDesktop.Core.Filters;
using TaskTrackerDesktop.Core.Responses.Process;

namespace TaskTrackerDesktop.Core.Interfaces;

public interface IProcessService
{
    Task<GetProcessResponse> GetProcessAsync(Guid id, CancellationToken cancellationToken = default);
    Task<GetProcessEntitiesResponse> GetProcessesAsync(ProcessFilterForm filter, CancellationToken cancellationToken = default);
}