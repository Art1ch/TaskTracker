using MapsterMapper;
using MediatR;
using TaskTracker.Application.Abstractions.Repository;
using TaskTracker.Application.Filters;

namespace TaskTracker.Application.Queries.Remark.GetEntities;

internal sealed class GetRemarkEntitiesQueryHandler : IRequestHandler<GetRemarkEntitiesQuery, GetRemarkEntitiesQueryResult>
{
    private readonly IRemarkRepository _repository;
    private readonly IMapper _mapper;

    public GetRemarkEntitiesQueryHandler(IRemarkRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetRemarkEntitiesQueryResult> Handle(GetRemarkEntitiesQuery request, CancellationToken cancellationToken)
    {
        var filter = _mapper.Map<RemarkFilter>(request);

        var entities = await _repository.GetEntitiesAsync(filter, cancellationToken);

        var items = _mapper.Map<List<GetRemarkEntitiesQueryResultItem>>(entities);

        return new GetRemarkEntitiesQueryResult(items);
    }
}
