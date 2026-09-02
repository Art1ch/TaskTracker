using TaskTracker.Application.Queries.Remark.Get;

namespace TaskTracker.Application.Validaton.Validators.Remark;

public sealed class GetRemarkQueryValidator : ValidatorBase<GetRemarkQuery>
{
    public GetRemarkQueryValidator()
    {
        ValidateId(x => x.Id, required: true);
    }
}
