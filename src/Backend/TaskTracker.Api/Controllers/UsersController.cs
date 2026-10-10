using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskTracker.Application.Queries.User.Get;
using TaskTracker.Application.Queries.User.GetEntities;
using TaskTracker.Application.Requests.User;
using TaskTracker.Application.Responses.User;

namespace TaskTracker.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public UsersController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet("me")]
    public async Task<ActionResult<GetUserResponse>> Me()
    {
        var id = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var query = new GetUserQuery(id);

        var result = await _sender.Send(query);

        var response = _mapper.Map<GetUserResponse>(result);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetUserResponse>> Get([FromQuery] GetUserRequest request)
    {
        var query = _mapper.Map<GetUserQuery>(request);

        var result = await _sender.Send(query);

        var response = _mapper.Map<GetUserResponse>(result);

        return Ok(response);
    }

    [HttpGet("entities")]
    public async Task<ActionResult<GetUserEntitiesResponse>> GetEntities([FromQuery] GetUserEntitiesRequest request)
    {
        var query = _mapper.Map<GetUserEntitiesQuery>(request);

        var result = await _sender.Send(query);

        var response = _mapper.Map<GetUserEntitiesResponse>(result);

        return Ok(response);
    }
}
