namespace TaskTracker.Application.Queries.Remark.GetEntities;

public sealed record GetRemarkEntitiesQueryResult(
    IEnumerable<GetRemarkEntitiesQueryResultItem> Remarks
);
