using TaskTracker.Application.Queries.Process.GetEntities;

namespace TaskTracker.Application.Validaton.Validators.Process;

public sealed class GetProcessEntitiesQueryValidator : ValidatorBase<GetProcessEntitiesQuery>
{
    public GetProcessEntitiesQueryValidator()
    {
        ValidatePage(x => x.Page);
        ValidatePageSize(x => x.PageSize);
        ValidateDateRange(x => x.From, x => x.To);
        ValidateName(x => x.Name);
        ValidateDescription(x => x.Description);
        ValidateBoolean(x => x.IsActive);
    }
}
