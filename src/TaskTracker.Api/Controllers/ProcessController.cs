using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Application.Commands.Process.CreateProcess;
using TaskTracker.Application.Commands.Process.DeleteProcess;
using TaskTracker.Application.Commands.Process.UpdateProcess;
using TaskTracker.Application.Queries.Process.Get;
using TaskTracker.Application.Queries.Process.GetEntities;
using TaskTracker.Application.Requests.Process;
using TaskTracker.Application.Responses.Process;
using TaskTracker.Core.Enums;

namespace TaskTracker.Api.Controllers;

//[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ProcessController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public ProcessController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<GetProcessResponse>> Get([FromQuery] GetProcessRequest request)
    {
        var command = _mapper.Map<GetProcessQuery>(request);

        var result = await _sender.Send(command);

        var response = _mapper.Map<GetProcessResponse>(result);

        return response;
    }

    [HttpGet("entities")]
    public async Task<ActionResult<GetProcessEntitiesResponse>> GetEntities([FromQuery] GetProcessEntitiesRequest request)
    {
        var command = _mapper.Map<GetProcessEntitiesQuery>(request);

        var result = await _sender.Send(command);

        var response = _mapper.Map<GetProcessEntitiesResponse>(result);

        return response;
    }

    [Authorize(Roles = nameof(UserRole.Admin))]
    [HttpPost]
    public async Task<ActionResult<CreateProcessResponse>> Create([FromBody] CreateProcessRequest request)
    {
        var command = _mapper.Map<CreateProcessCommand>(request);

        var result = await _sender.Send(command);

        var response = _mapper.Map<CreateProcessResponse>(result);

        return response;
    }

    [Authorize(Roles = nameof(UserRole.Admin))]
    [HttpPut]
    public async Task<ActionResult<UpdateProcessResponse>> Update([FromBody] UpdateProcessRequest request)
    {
        var command = _mapper.Map<UpdateProcessCommand>(request);

        var result = await _sender.Send(command);

        var response = _mapper.Map<UpdateProcessResponse>(result);

        return response;
    }

    [Authorize(Roles = nameof(UserRole.Admin))]
    [HttpDelete]
    public async Task<ActionResult<DeleteProcessResponse>> Delete([FromBody] DeleteProcessRequest request)
    {
        var command = _mapper.Map<DeleteProcessCommand>(request);

        var result = await _sender.Send(command);

        var response = _mapper.Map<DeleteProcessResponse>(result);

        return response;
    }
}
