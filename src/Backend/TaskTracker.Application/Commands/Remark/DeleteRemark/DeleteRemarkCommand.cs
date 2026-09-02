using MediatR;

namespace TaskTracker.Application.Commands.Remark.DeleteRemark;

public sealed record DeleteRemarkCommand(
    Guid Id
) : IRequest<DeleteRemarkCommandResult>;
