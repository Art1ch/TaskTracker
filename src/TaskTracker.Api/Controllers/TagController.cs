using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Application.Commands.Tag.CreateTag;
using TaskTracker.Application.Commands.Tag.DeleteTag;
using TaskTracker.Application.Commands.Tag.UpdateTag;
using TaskTracker.Application.Queries.Tag.Get;
using TaskTracker.Application.Queries.Tag.GetEntities;
using TaskTracker.Application.Requests.Tag;
using TaskTracker.Application.Responses.Tag;
using TaskTracker.Core.Enums;

namespace TaskTracker.Api.Controllers;

//[Authorize]
[Route("api/[controller]")]
[ApiController]
public class TagController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public TagController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<GetTagResponse>> Get([FromQuery] GetTagRequest request)
    {
        var command = _mapper.Map<GetTagQuery>(request);

        var result = await _sender.Send(command);

        var response = _mapper.Map<GetTagResponse>(result);

        return response;
    }

    [HttpGet("entities")]
    public async Task<ActionResult<GetTagEntitiesResponse>> GetEntities([FromQuery] GetTagEntitiesRequest request)
    {
        var command = _mapper.Map<GetTagEntitiesQuery>(request);

        var result = await _sender.Send(command);

        var response = _mapper.Map<GetTagEntitiesResponse>(result);

        return response;
    }

    [Authorize(Roles = nameof(UserRole.Admin))]
    [HttpPost]
    public async Task<ActionResult<CreateTagResponse>> Create([FromBody] CreateTagRequest request)
    {
        var command = _mapper.Map<CreateTagCommand>(request);

        var result = await _sender.Send(command);

        var response = _mapper.Map<CreateTagResponse>(result);

        return response;
    }

    [Authorize(Roles = nameof(UserRole.Admin))]
    [HttpPut]
    public async Task<ActionResult<UpdateTagResponse>> Update([FromBody] UpdateTagRequest request)
    {
        var command = _mapper.Map<UpdateTagCommand>(request);

        var result = await _sender.Send(command);

        var response = _mapper.Map<UpdateTagResponse>(result);

        return response;
    }

    [Authorize(Roles = nameof(UserRole.Admin))]
    [HttpDelete]
    public async Task<ActionResult<DeleteTagResponse>> Delete([FromBody] DeleteTagRequest request)
    {
        var command = _mapper.Map<DeleteTagCommand>(request);

        var result = await _sender.Send(command);

        var response = _mapper.Map<DeleteTagResponse>(result);

        return response;
    }
}
