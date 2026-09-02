using MediatR;
using TaskTracker.Application.Abstractions.Repository;

namespace TaskTracker.Application.Commands.Task.DeleteTask;

internal sealed class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, DeleteTaskCommandResult>
{
    private readonly ITaskRepository _repository;

    public DeleteTaskCommandHandler(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<DeleteTaskCommandResult> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Id, cancellationToken);

        return new DeleteTaskCommandResult();
    }
}
