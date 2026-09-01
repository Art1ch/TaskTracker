using TaskTracker.Application.Queries.User.GetEntities;
using TaskTracker.Core.Enums;

namespace TaskTracker.Application.Validaton.Validators.User;

public sealed class GetUserEntitiesQueryValidator : ValidatorBase<GetUserEntitiesQuery>
{
    public GetUserEntitiesQueryValidator()
    {
        ValidatePage(x => x.Page);
        ValidatePageSize(x => x.PageSize);
        ValidateDateRange(x => x.From, x => x.To);
        ValidateEnum<UserRole>(x => x.Role);
        ValidateFirstName(x => x.FirstName);
        ValidateLastName(x => x.LastName);
    }
}
