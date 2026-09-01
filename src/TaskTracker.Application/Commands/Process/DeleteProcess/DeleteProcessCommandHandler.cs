using MediatR;
using TaskTracker.Application.Abstractions.Repository;

namespace TaskTracker.Application.Commands.Process.DeleteProcess;

internal sealed class DeleteProcessCommandHandler : IRequestHandler<DeleteProcessCommand, DeleteProcessCommandResult>
{
    private readonly IProcessRepository _repository;

    public DeleteProcessCommandHandler(IProcessRepository repository)
    {
        _repository = repository;
    }

    public async Task<DeleteProcessCommandResult> Handle(DeleteProcessCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Id, cancellationToken);

        return new DeleteProcessCommandResult();
    }
}
