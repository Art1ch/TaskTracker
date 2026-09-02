using MapsterMapper;
using MediatR;
using TaskTracker.Application.Abstractions.Repository;
using TaskTracker.Application.Filters;

namespace TaskTracker.Application.Queries.User.GetEntities;

internal sealed class GetUserEntitiesQueryHandler : IRequestHandler<GetUserEntitiesQuery, GetUserEntitiesQueryResult>
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public GetUserEntitiesQueryHandler(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetUserEntitiesQueryResult> Handle(GetUserEntitiesQuery request, CancellationToken cancellationToken)
    {
        var filter = _mapper.Map<UserFilter>(request);

        var entities = await _repository.GetEntitiesAsync(filter, cancellationToken);

        var items = _mapper.Map<List<GetUserEntitiesQueryResultItem>>(entities);

        return new GetUserEntitiesQueryResult(items);
    }
}
