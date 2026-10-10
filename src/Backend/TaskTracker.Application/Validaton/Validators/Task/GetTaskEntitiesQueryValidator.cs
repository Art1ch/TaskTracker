using TaskTracker.Application.Queries.Task.GetEntities;
using TaskTracker.Application.Requests.Task;
using TaskTracker.Core.Enums;

namespace TaskTracker.Application.Validaton.Validators.Task;

public sealed class GetTaskEntitiesQueryValidator : ValidatorBase<GetTaskEntitiesQuery>
{
    public GetTaskEntitiesQueryValidator()
    {
        ValidatePage(x => x.Page);
        ValidatePageSize(x => x.PageSize);
        ValidateId(x => x.ProcessId);
        ValidateId(x => x.AssignedToId);
        ValidateId(x => x.CreatedById);
        ValidateDateRange(x => x.From, x => x.To);
        ValidateDescription(x => x.Description);
        ValidateTitle(x => x.Title);
        ValidateEnum<TaskState>(x => x.TaskState);
        ValidateDeadline(x => x.Deadline);
    }
}
