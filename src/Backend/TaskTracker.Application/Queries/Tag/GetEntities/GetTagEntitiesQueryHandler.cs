using MapsterMapper;
using MediatR;
using TaskTracker.Application.Abstractions.Repository;
using TaskTracker.Application.Filters;

namespace TaskTracker.Application.Queries.Tag.GetEntities;

internal sealed class GetTagEntitiesQueryHandler : IRequestHandler<GetTagEntitiesQuery, GetTagEntitiesQueryResult>
{
    private readonly ITagRepository _repository;
    private readonly IMapper _mapper;

    public GetTagEntitiesQueryHandler(ITagRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetTagEntitiesQueryResult> Handle(GetTagEntitiesQuery request, CancellationToken cancellationToken)
    {
        var filter = _mapper.Map<TagFilter>(request);

        var repositoryResult = await _repository.GetEntitiesAsync(filter, cancellationToken);

        var queryResult = _mapper.Map<GetTagEntitiesQueryResult>(repositoryResult);

        return queryResult;
    }
}
