using MediatR;
using TaskTracker.Application.Abstractions.Repository;

namespace TaskTracker.Application.Commands.Process.AddUserToProcess;

internal sealed class AddUserToProcessCommandHandler : IRequestHandler<AddUserToProcessCommand, AddUserToProcessCommandResult>
{
    private readonly IProcessRepository _processRepository;

    public AddUserToProcessCommandHandler(IProcessRepository processRepository)
    {
        _processRepository = processRepository;
    }

    public async Task<AddUserToProcessCommandResult> Handle(AddUserToProcessCommand request, CancellationToken cancellationToken)
    {
        var process = await _processRepository.GetAsync(request.ProcessId, cancellationToken);

        if (process.AdminId != request.AdminId)
            throw new InvalidOperationException();

        await _processRepository.AddUserToProcessAsync(request.ProcessId, request.UserId, cancellationToken);

        return new AddUserToProcessCommandResult();
    }
}
