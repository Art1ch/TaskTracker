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
    private readonly JwtSettings _jwtSettings;

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
        _jwtSettings = jwtOptions.Value;
    }

    [HttpPost("register")]
    public async Task<ActionResult<AuthResponse>> Register([FromBody] RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);

        var result = await _sender.Send(command);
        string? errorMessage = null;

        if (!result.IsSucceed)
        {
            errorMessage = _localizer.GetString(result.ErrorCode!);
        }

        var response = _mapper.Map<AuthResponse>(result) with { ErrorMessage = errorMessage };

        return response;
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Login([FromBody] LoginRequest request)
    {
        var command = _mapper.Map<LoginCommand>(request);

        var result = await _sender.Send(command);
        string? errorMessage = null;

        if (!result.IsSucceed)
        {
            errorMessage = _localizer.GetString(result.ErrorCode!);
            return _mapper.Map<AuthResponse>(result) with { ErrorMessage = errorMessage };
        }

        var response = _mapper.Map<AuthResponse>(result);

        SetTokenInCookies(Response, result.Token!, DateTime.UtcNow.AddDays(_jwtSettings.ExpiresAtDays));

        return response;
    }

    [HttpPost("logout")]
    public async Task<ActionResult> Logout()
    {
        Response.Cookies.Delete("token");

        return Ok();
    }

    private static void SetTokenInCookies(HttpResponse httpResponse, string token, DateTime? expiry)
    {
        httpResponse.Cookies.Append("token", token, new CookieOptions
        {
            Expires = expiry,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            HttpOnly = true
        });
    }
}
