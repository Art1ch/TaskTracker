using MediatR;

namespace TaskTracker.Application.Commands.Remark.CreateRemark;

public sealed record CreateRemarkCommand(
    Guid TaskId,
    Guid UserId,
    string Text
) : IRequest<CreateRemarkCommandResult>;