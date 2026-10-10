using MapsterMapper;
using MediatR;
using TaskTracker.Application.Abstractions.Repository;

namespace TaskTracker.Application.Queries.Remark.Get;

internal sealed class GetRemarkQueryHandler : IRequestHandler<GetRemarkQuery, GetRemarkQueryResult>
{
    private readonly ITagRepository _repository;
    private readonly IMapper _mapper;

    public GetRemarkQueryHandler(ITagRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetRemarkQueryResult> Handle(GetRemarkQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetAsync(request.Id, cancellationToken);

        var result = _mapper.Map<GetRemarkQueryResult>(entity);

        return result;
    }
}
