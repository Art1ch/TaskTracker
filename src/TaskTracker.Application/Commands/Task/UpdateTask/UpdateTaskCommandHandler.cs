using MapsterMapper;
using MediatR;
using TaskTracker.Application.Abstractions.Repository;
using TaskTracker.Core.Entities;

namespace TaskTracker.Application.Commands.Task.UpdateTask;

internal sealed class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, UpdateTaskCommandResult>
{
    private readonly ITaskRepository _repository;
    private readonly IMapper _mapper;

    public UpdateTaskCommandHandler(ITaskRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UpdateTaskCommandResult> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<TaskEntity>(request);

        await _repository.UpdateAsync(entity, cancellationToken);

        return new UpdateTaskCommandResult();
    }
}
