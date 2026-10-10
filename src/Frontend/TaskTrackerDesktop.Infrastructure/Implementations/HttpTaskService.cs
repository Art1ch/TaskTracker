using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using TaskTrackerDesktop.Core.Filters;
using TaskTrackerDesktop.Core.Interfaces;
using TaskTrackerDesktop.Core.Responses.Task;

namespace TaskTrackerDesktop.Infrastructure.Implementations;

internal sealed class HttpTaskService : ITaskService
{
    private readonly HttpClient _httpClient;

    public HttpTaskService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetTaskResponse> GetTaskAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var taskResponse = await _httpClient.GetAsync($"api/tasks?id={id}", cancellationToken);
        var taskResult = await taskResponse.Content.ReadFromJsonAsync<GetTaskResponse>(cancellationToken);

        return taskResult;
    }

    public async Task<GetTaskEntitiesResponse> GetTasksAsync(TaskFilterForm filter, CancellationToken cancellationToken = default)
    {
        var basePath = "api/tasks/entities";

        var queryParams = new Dictionary<string, string?>()
        {
            ["page"] = filter.Page.ToString(),
            ["pageSize"] = filter.PageSize.ToString(),
            ["processId"] = filter.ProcessId?.ToString(),
            ["createdById"] = filter.CreatedById?.ToString(),
            ["assignedToId"] = filter.AssignedToId?.ToString(),
            ["from"] = filter.From?.ToString("O"),
            ["to"] = filter.To?.ToString("O"),
            ["title"] = filter.Title,
            ["description"] = filter.Description,
            ["taskState"] = filter.TaskState?.ToString(),
            ["deadline"] = filter.Deadline?.ToString("O")
        };

        var filteredQueryParams = queryParams
            .Where(x => x.Value is not null)
            .ToDictionary(x => x.Key, x => x.Value!);

        string urlWithQuery = QueryHelpers.AddQueryString(basePath, filteredQueryParams);

        var getRemarkEntitiesResponse = await _httpClient.GetAsync(urlWithQuery, cancellationToken);
        var getRemarkEntitiesResult = await getRemarkEntitiesResponse.Content.ReadFromJsonAsync<GetTaskEntitiesResponse>(cancellationToken);

        return getRemarkEntitiesResult;
    }
}
