using MapsterMapper;
using MediatR;
using TaskTracker.Application.Abstractions.Repository;
using TaskTracker.Application.Filters;

namespace TaskTracker.Application.Queries.Process.GetEntities;

internal sealed class GetProcessEntitiesQueryHandler : IRequestHandler<GetProcessEntitiesQuery, GetProcessEntitiesQueryResult>
{
    private readonly IProcessRepository _repository;
    private readonly IMapper _mapper;

    public GetProcessEntitiesQueryHandler(IProcessRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetProcessEntitiesQueryResult> Handle(GetProcessEntitiesQuery request, CancellationToken cancellationToken)
    {
        var filter = _mapper.Map<ProcessFilter>(request);

        var entities = await _repository.GetEntitiesAsync(filter, cancellationToken);

        var items = _mapper.Map<List<GetProcessEntitiesQueryResultItem>>(entities);

        return new GetProcessEntitiesQueryResult(items);
    }
}
