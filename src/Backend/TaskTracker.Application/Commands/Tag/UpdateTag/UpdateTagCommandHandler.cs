using MapsterMapper;
using MediatR;
using TaskTracker.Application.Abstractions.Repository;
using TaskTracker.Core.Entities;

namespace TaskTracker.Application.Commands.Tag.UpdateTag;

internal sealed class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand, UpdateTagCommandResult>
{
    private readonly ITagRepository _repository;
    private readonly IMapper _mapper;

    public UpdateTagCommandHandler(ITagRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UpdateTagCommandResult> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<TagEntity>(request);

        await _repository.UpdateAsync(entity, cancellationToken);

        return new UpdateTagCommandResult();
    }
}
