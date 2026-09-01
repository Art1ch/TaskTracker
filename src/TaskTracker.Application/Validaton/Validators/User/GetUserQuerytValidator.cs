using TaskTracker.Application.Queries.User.Get;

namespace TaskTracker.Application.Validaton.Validators.User;

public sealed class GetUserQuerytValidator : ValidatorBase<GetUserQuery>
{
    public GetUserQuerytValidator()
    {
        ValidateId(x => x.Id, required: true);
    }
}