namespace TaskTracker.Application.Requests.Base;

public abstract record GetEntitiesRequestBase(
    int Page,
    int PageSize,
    DateTime? From,
    DateTime? To
);