using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Application.Commands.Remark.CreateRemark;
using TaskTracker.Application.Commands.Remark.DeleteRemark;
using TaskTracker.Application.Commands.Remark.UpdateRemark;
using TaskTracker.Application.Queries.Remark.Get;
using TaskTracker.Application.Queries.Remark.GetEntities;
using TaskTracker.Application.Requests.Remark;
using TaskTracker.Application.Responses.Remark;

namespace TaskTracker.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class RemarksController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public RemarksController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<GetRemarkResponse>> Get([FromQuery] GetRemarkRequest request)
    {
        var query = _mapper.Map<GetRemarkQuery>(request);

        var result = await _sender.Send(query);

        var response = _mapper.Map<GetRemarkResponse>(result);

        return Ok(response);
    }

    [HttpGet("entities")]
    public async Task<ActionResult<GetRemarkEntitiesResponse>> GetEntities([FromQuery] GetRemarkEntitiesRequest request)
    {
        var query = _mapper.Map<GetRemarkEntitiesQuery>(request);

        var result = await _sender.Send(query);

        var response = _mapper.Map<GetRemarkEntitiesResponse>(result);

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<CreateRemarkResponse>> Create([FromBody] CreateRemarkRequest request)
    {
        var command = _mapper.Map<CreateRemarkCommand>(request);

        var result = await _sender.Send(command);

        var response = _mapper.Map<CreateRemarkResponse>(result);

        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdateRemarkResponse>> Update([FromBody] UpdateRemarkRequest request)
    {
        var command = _mapper.Map<UpdateRemarkCommand>(request);

        var result = await _sender.Send(command);

        var response = _mapper.Map<UpdateRemarkResponse>(result);

        return Ok(response);
    }

    [HttpDelete]
    public async Task<ActionResult<DeleteRemarkResponse>> Delete([FromBody] DeleteRemarkRequest request)
    {
        var command = _mapper.Map<DeleteRemarkCommand>(request);

        var result = await _sender.Send(command);

        var response = _mapper.Map<DeleteRemarkResponse>(result);

        return Ok(response);
    }
}
