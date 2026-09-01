using MapsterMapper;
using MediatR;
using TaskTracker.Application.Abstractions.Services;

namespace TaskTracker.Application.Commands.Auth.Register;

internal sealed class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterCommandResult>
{
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;

    public RegisterCommandHandler(IAuthService authService, IMapper mapper)
    {
        _authService = authService;
        _mapper = mapper;
    }

    public async Task<RegisterCommandResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var result = await _authService.RegisterAsync(
            request.Email,
            request.FirstName, 
            request.LastName, 
            request.Password,
            cancellationToken
        );

        var commandResult = _mapper.Map<RegisterCommandResult>(result);

        return commandResult;
    }
}
