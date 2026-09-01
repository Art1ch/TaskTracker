using MediatR;
using TaskTracker.Application.Abstractions.Repository;

namespace TaskTracker.Application.Commands.Tag.DeleteTag;

internal sealed class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, DeleteTagCommandResult>
{
    private readonly ITagRepository _repository;

    public DeleteTagCommandHandler(ITagRepository repository)
    {
        _repository = repository;
    }

    public async Task<DeleteTagCommandResult> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Id, cancellationToken);

        return new DeleteTagCommandResult();
    }
}
