using MapsterMapper;
using MediatR;
using TaskTracker.Application.Abstractions.Repository;

namespace TaskTracker.Application.Queries.Tag.Get;

internal sealed class GetTagQueryHandler : IRequestHandler<GetTagQuery, GetTagQueryResult>
{
    private readonly ITagRepository _repository;
    private readonly IMapper _mapper;

    public GetTagQueryHandler(ITagRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetTagQueryResult> Handle(GetTagQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetAsync(request.Id, cancellationToken);

        var result = _mapper.Map<GetTagQueryResult>(entity);

        return result;
    }
}
