using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Application.Commands.Task.CreateTask;
using TaskTracker.Application.Commands.Task.DeleteTask;
using TaskTracker.Application.Commands.Task.UpdateTask;
using TaskTracker.Application.Queries.Task.Get;
using TaskTracker.Application.Queries.Task.GetEntities;
using TaskTracker.Application.Requests.Task;
using TaskTracker.Application.Responses.Task;
using TaskTracker.Core.Enums;

namespace TaskTracker.Api.Controllers;

//[Authorize]
[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public TaskController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<GetTaskResponse>> Get([FromQuery] GetTaskRequest request)
    {
        var command = _mapper.Map<GetTaskQuery>(request);

        var result = await _sender.Send(command);

        var response = _mapper.Map<GetTaskResponse>(result);

        return response;
    }

    [HttpGet("entities")]
    public async Task<ActionResult<GetTaskEntitiesResponse>> GetEntities([FromQuery] GetTaskEntitiesRequest request)
    {
        var command = _mapper.Map<GetTaskEntitiesQuery>(request);

        var result = await _sender.Send(command);

        var response = _mapper.Map<GetTaskEntitiesResponse>(result);

        return response;
    }

    [Authorize(Roles = nameof(UserRole.Admin))]
    [HttpPost]
    public async Task<ActionResult<CreateTaskResponse>> Create([FromBody] CreateTaskRequest request)
    {
        var command = _mapper.Map<CreateTaskCommand>(request);

        var result = await _sender.Send(command);

        var response = _mapper.Map<CreateTaskResponse>(result);

        return response;
    }

    [Authorize(Roles = nameof(UserRole.Admin))]
    [HttpPut]
    public async Task<ActionResult<UpdateTaskResponse>> Update([FromBody] UpdateTaskQuery request)
    {
        var command = _mapper.Map<UpdateTaskCommand>(request);

        var result = await _sender.Send(command);

        var response = _mapper.Map<UpdateTaskResponse>(result);

        return response;
    }

    [Authorize(Roles = nameof(UserRole.Admin))]
    [HttpDelete]
    public async Task<ActionResult<DeleteTaskResponse>> Delete([FromBody] DeleteTaskRequest request)
    {
        var command = _mapper.Map<DeleteTaskCommand>(request);

        var result = await _sender.Send(command);

        var response = _mapper.Map<DeleteTaskResponse>(result);

        return response;
    }
}
