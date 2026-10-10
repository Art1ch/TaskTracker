using MapsterMapper;
using MediatR;
using TaskTracker.Application.Abstractions.Services;

namespace TaskTracker.Application.Commands.Auth.Logout;

internal sealed class LogoutCommandHandler : IRequestHandler<LogoutCommand, LogoutCommandResult>
{
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;

    public LogoutCommandHandler(IAuthService authService, IMapper mapper)
    {
        _authService = authService;
        _mapper = mapper;
    }

    public async Task<LogoutCommandResult> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        var result = await _authService.LogoutAsync(request.RefreshToken, cancellationToken);

        var commandResult = _mapper.Map<LogoutCommandResult>(result);

        return commandResult;
    }
}
