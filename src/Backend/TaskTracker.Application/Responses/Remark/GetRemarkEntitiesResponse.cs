namespace TaskTracker.Application.Responses.Remark;

public sealed record GetRemarkEntitiesResponse(
    IEnumerable<GetRemarkEntitiesResponseItem> Remarks
);
