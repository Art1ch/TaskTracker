using MapsterMapper;
using MediatR;
using TaskTracker.Application.Abstractions.Repository;
using TaskTracker.Core.Entities;

namespace TaskTracker.Application.Commands.Tag.CreateTag;

internal sealed record CreateTagCommandHandler : IRequestHandler<CreateTagCommand, CreateTagCommandResult>
{
    private readonly ITagRepository _repository;
    private readonly IMapper _mapper;

    public CreateTagCommandHandler(ITagRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CreateTagCommandResult> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<TagEntity>(request);

        await _repository.CreateAsync(entity, cancellationToken);

        return new CreateTagCommandResult();
    }
}
