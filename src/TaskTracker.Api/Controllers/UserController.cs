using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Application.Queries.User.Get;
using TaskTracker.Application.Queries.User.GetEntities;
using TaskTracker.Application.Requests.User;
using TaskTracker.Application.Responses.User;

namespace TaskTracker.Api.Controllers;

//[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public UserController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<GetUserResponse>> Get([FromQuery] GetUserRequest request)
    {
        var command = _mapper.Map<GetUserQuery>(request);

        var result = await _sender.Send(command);

        var response = _mapper.Map<GetUserResponse>(result);

        return response;
    }

    [HttpGet("entities")]
    public async Task<ActionResult<GetUserEntitiesResponse>> GetEntities([FromQuery] GetUserEntitiesRequest request)
    {
        var command = _mapper.Map<GetUserEntitiesQuery>(request);

        var result = await _sender.Send(command);

        var response = _mapper.Map<GetUserEntitiesResponse>(result);

        return response;
    }
}
