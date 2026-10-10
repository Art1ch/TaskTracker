using MapsterMapper;
using MediatR;
using TaskTracker.Application.Abstractions.Repository;

namespace TaskTracker.Application.Queries.Task.Get;

internal sealed class GetTaskQueryHandler : IRequestHandler<GetTaskQuery, GetTaskQueryResult>
{
    private readonly ITaskRepository _repository;
    private readonly IMapper _mapper;

    public GetTaskQueryHandler(ITaskRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetTaskQueryResult> Handle(GetTaskQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetAsync(request.Id, cancellationToken);

        var result = _mapper.Map<GetTaskQueryResult>(entity);

        return result;
    }
}
