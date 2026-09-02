using TaskTracker.Application.Queries.Tag.GetEntities;

namespace TaskTracker.Application.Validaton.Validators.Tag;

public sealed class GetTagEntitiesQueryValidator : ValidatorBase<GetTagEntitiesQuery>
{
    public GetTagEntitiesQueryValidator()
    {
        ValidatePage(x => x.Page);
        ValidatePageSize(x => x.PageSize);
        ValidateDateRange(x => x.From, x => x.To);
        ValidateName(x => x.Name);
    }
}