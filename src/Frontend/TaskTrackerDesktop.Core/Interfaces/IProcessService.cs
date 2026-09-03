using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskTrackerDesktop.Core.Filters;
using TaskTrackerDesktop.Core.Models;

namespace TaskTrackerDesktop.Core.Interfaces;

public interface IProcessService
{
    Task<IEnumerable<ProcessModel>> GetProcessesAsync(ProcessFilterForm filter, CancellationToken cancellationToken = default);
    Task<ProcessModel> GetProcessAsync(Guid Id, CancellationToken cancellationToken = default);
}
