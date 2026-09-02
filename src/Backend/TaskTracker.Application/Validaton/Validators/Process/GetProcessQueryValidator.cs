using TaskTracker.Application.Queries.Process.Get;

namespace TaskTracker.Application.Validaton.Validators.Process;

public sealed class GetProcessQueryValidator : ValidatorBase<GetProcessQuery>
{
    public GetProcessQueryValidator()
    {
        ValidateId(x => x.Id, required: true);
    }
}
