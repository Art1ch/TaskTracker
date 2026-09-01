using MapsterMapper;
using MediatR;
using TaskTracker.Application.Abstractions.Repository;
using TaskTracker.Application.Filters;

namespace TaskTracker.Application.Queries.Task.GetEntities;

internal sealed class GetTaskEntitiesQueryHandler : IRequestHandler<GetTaskEntitiesQuery, GetTaskEntitiesQueryResult>
{
    private readonly ITaskRepository _repository;
    private readonly IMapper _mapper;

    public GetTaskEntitiesQueryHandler(ITaskRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetTaskEntitiesQueryResult> Handle(GetTaskEntitiesQuery request, CancellationToken cancellationToken)
    {
        var filter = _mapper.Map<TaskFilter>(request);

        var entities = await _repository.GetEntitiesAsync(filter, cancellationToken);

        var items = _mapper.Map<List<GetTaskEntitiesQueryResultItem>>(entities);

        return new GetTaskEntitiesQueryResult(items);
    }
}
