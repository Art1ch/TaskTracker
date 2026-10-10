using MapsterMapper;
using MediatR;
using TaskTracker.Application.Abstractions.Repository;
using TaskTracker.Core.Entities;

namespace TaskTracker.Application.Commands.Task.CreateTask;

internal sealed class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, CreateTaskCommandResult>
{
    private readonly ITaskRepository _repository;
    private readonly IMapper _mapper;

    public CreateTaskCommandHandler(ITaskRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CreateTaskCommandResult> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<TaskEntity>(request);

        await _repository.CreateAsync(entity, cancellationToken);

        return new CreateTaskCommandResult();
    }
}
