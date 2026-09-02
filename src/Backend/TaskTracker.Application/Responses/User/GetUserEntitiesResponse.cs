namespace TaskTracker.Application.Responses.User;

public sealed record GetUserEntitiesResponse(
    IEnumerable<GetUserEntitiesResponseItem> Users
);
