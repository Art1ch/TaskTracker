using TaskTracker.Application.Queries.Task.Get;

namespace TaskTracker.Application.Validaton.Validators.Task;

public sealed class GetTaskQueryValidator : ValidatorBase<GetTaskQuery>
{
    public GetTaskQueryValidator()
    {
        ValidateId(x => x.Id, required: true);
    }
}
