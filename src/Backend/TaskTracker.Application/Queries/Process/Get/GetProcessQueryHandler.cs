using MapsterMapper;
using MediatR;
using TaskTracker.Application.Abstractions.Repository;

namespace TaskTracker.Application.Queries.Process.Get;

internal sealed class GetProcessQueryHandler : IRequestHandler<GetProcessQuery, GetProcessQueryResult>
{
    private readonly IProcessRepository _repository;
    private readonly IMapper _mapper;

    public GetProcessQueryHandler(IProcessRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetProcessQueryResult> Handle(GetProcessQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetAsync(request.Id, cancellationToken);

        var result = _mapper.Map<GetProcessQueryResult>(entity);

        return result;
    }
}
