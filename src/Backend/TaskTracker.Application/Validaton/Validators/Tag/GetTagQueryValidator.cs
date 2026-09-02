using TaskTracker.Application.Queries.Tag.Get;

namespace TaskTracker.Application.Validaton.Validators.Tag;

public sealed class GetTagQueryValidator : ValidatorBase<GetTagQuery>
{
    public GetTagQueryValidator()
    {
        ValidateId(x => x.Id, required: true);
    }
}
