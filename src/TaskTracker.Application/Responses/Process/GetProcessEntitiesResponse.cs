namespace TaskTracker.Application.Responses.Process;

public sealed record GetProcessEntitiesResponse(
    IEnumerable<GetProcessEntitiesResponseItem> Processes
);
