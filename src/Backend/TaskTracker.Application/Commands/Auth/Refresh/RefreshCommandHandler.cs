using MapsterMapper;
using MediatR;
using TaskTracker.Application.Abstractions.Services;

namespace TaskTracker.Application.Commands.Auth.Refresh;

internal sealed class RefreshCommandHandler : IRequestHandler<RefreshCommand, RefreshCommandResult>
{
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;

    public RefreshCommandHandler(IAuthService authService, IMapper mapper)
    {
        _authService = authService;
        _mapper = mapper;
    }

    public async Task<RefreshCommandResult> Handle(RefreshCommand request, CancellationToken cancellationToken)
    {
        var result = await _authService.RefreshAsync(request.RefreshToken, cancellationToken);

        var commandResult = _mapper.Map<RefreshCommandResult>(result);

        return commandResult;
    }
}
