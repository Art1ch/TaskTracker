using MapsterMapper;
using MediatR;
using TaskTracker.Application.Abstractions.Repository;
using TaskTracker.Core.Entities;

namespace TaskTracker.Application.Commands.Process.UpdateProcess;

internal sealed class UpdateProcessCommandHandler : IRequestHandler<UpdateProcessCommand, UpdateProcessCommandResult>
{
    private readonly IProcessRepository _repository;
    private readonly IMapper _mapper;

    public UpdateProcessCommandHandler(IProcessRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UpdateProcessCommandResult> Handle(UpdateProcessCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<ProcessEntity>(request);

        await _repository.UpdateAsync(entity, cancellationToken);

        return new UpdateProcessCommandResult();
    }
}
