using MediatR;
using TaskTracker.Application.Abstractions.Repository;

namespace TaskTracker.Application.Commands.Remark.DeleteRemark;

internal sealed class DeleteRemarkCommandHandler : IRequestHandler<DeleteRemarkCommand, DeleteRemarkCommandResult>
{
    private readonly IRemarkRepository _repository;

    public DeleteRemarkCommandHandler(IRemarkRepository repository)
    {
        _repository = repository;
    }

    public async Task<DeleteRemarkCommandResult> Handle(DeleteRemarkCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Id, cancellationToken);

        return new DeleteRemarkCommandResult();
    }
}
