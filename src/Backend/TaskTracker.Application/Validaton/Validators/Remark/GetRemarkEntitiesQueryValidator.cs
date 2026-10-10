using TaskTracker.Application.Queries.Remark.GetEntities;

namespace TaskTracker.Application.Validaton.Validators.Remark;

public sealed class GetRemarkEntitiesQueryValidator : ValidatorBase<GetRemarkEntitiesQuery>
{
    public GetRemarkEntitiesQueryValidator()
    {
        ValidatePage(x => x.Page);
        ValidatePageSize(x => x.PageSize);
        ValidateId(x => x.TaskId);
        ValidateDateRange(x => x.From, x => x.To);
        ValidateText(x => x.Text);
    }
}
