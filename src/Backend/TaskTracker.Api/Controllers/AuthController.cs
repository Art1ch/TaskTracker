using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using TaskTracker.Application.Commands.Auth.Login;
using TaskTracker.Application.Commands.Auth.Register;
using TaskTracker.Application.Requests.Auth;
using TaskTracker.Application.Responses.Auth;
using TaskTracker.Infrastructure.Settings;

namespace TaskTracker.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<AuthController> _localizer;

    public AuthController(
        ISender sender,
        IMapper mapper,
        IStringLocalizer<AuthController> localizer,
        IOptions<JwtSettings> jwtOptions
,
        ILogger<AuthController> logger)
    {
        _sender = sender;
        _mapper = mapper;
        _localizer = localizer;
    }

    [HttpPost("register")]
    public async Task<ActionResult<RegisterResponse>> Register([FromBody] RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);

        var result = await _sender.Send(command);
        string? errorMessage = null;

        if (!result.IsSucceed)
        {
            errorMessage = _localizer.GetString(result.ErrorCode!);
        }

        var response = _mapper.Map<RegisterResponse>(result) with { ErrorMessage = errorMessage };

        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request)
    {
        var command = _mapper.Map<LoginCommand>(request);

        var result = await _sender.Send(command);

        string? errorMessage = null;

        if (!result.IsSucceed)
        {
            errorMessage = _localizer.GetString(result.ErrorCode!);
            return _mapper.Map<LoginResponse>(result) with { ErrorMessage = errorMessage, Token = null };
        }

        var response = _mapper.Map<LoginResponse>(result);

        return Ok(response);
    }
}
