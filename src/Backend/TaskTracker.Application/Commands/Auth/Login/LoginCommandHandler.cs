using MapsterMapper;
using MediatR;
using TaskTracker.Application.Abstractions.Services;

namespace TaskTracker.Application.Commands.Auth.Login;

internal sealed class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResult>
{
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;

    public LoginCommandHandler(IAuthService authService, IMapper mapper)
    {
        _authService = authService;
        _mapper = mapper;
    }

    public async Task<LoginCommandResult> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var result = await _authService.LoginAsync(request.Email, request.Password, cancellationToken);

        var commandResult = _mapper.Map<LoginCommandResult>(result);

        return commandResult;
    }
}
