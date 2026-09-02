using MapsterMapper;
using MediatR;
using TaskTracker.Application.Abstractions.Repository;
using TaskTracker.Core.Entities;

namespace TaskTracker.Application.Commands.Process.CreateProcess;

internal sealed class CreateProcessCommandHandler : IRequestHandler<CreateProcessCommand, CreateProcessCommandResult>
{
    private readonly IProcessRepository _repository;
    private readonly IMapper _mapper;

    public CreateProcessCommandHandler(IProcessRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CreateProcessCommandResult> Handle(CreateProcessCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<ProcessEntity>(request);

        await _repository.CreateAsync(entity, cancellationToken);

        return new CreateProcessCommandResult();
    }
}
