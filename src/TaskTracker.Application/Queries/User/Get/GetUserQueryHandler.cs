using MapsterMapper;
using MediatR;
using TaskTracker.Application.Abstractions.Repository;

namespace TaskTracker.Application.Queries.User.Get;

internal sealed class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserQueryResult>
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public GetUserQueryHandler(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetUserQueryResult> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetAsync(request.Id, cancellationToken);

        var result = _mapper.Map<GetUserQueryResult>(entity);

        return result;
    }
}
