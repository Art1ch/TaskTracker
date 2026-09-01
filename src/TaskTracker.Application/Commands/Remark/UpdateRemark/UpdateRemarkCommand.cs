using MediatR;

namespace TaskTracker.Application.Commands.Remark.UpdateRemark;

public sealed record UpdateRemarkCommand(
    Guid Id,
    string? Text,
    Guid? TaskId,
    Guid? UserId
) : IRequest<UpdateRemarkCommandResult>;
