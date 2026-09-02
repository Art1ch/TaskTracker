using MapsterMapper;
using MediatR;
using TaskTracker.Application.Abstractions.Repository;
using TaskTracker.Core.Entities;

namespace TaskTracker.Application.Commands.Remark.CreateRemark;

internal sealed class CreateRemarkCommandHandler : IRequestHandler<CreateRemarkCommand, CreateRemarkCommandResult>
{
    private readonly IRemarkRepository _repository;
    private readonly IMapper _mapper;

    public CreateRemarkCommandHandler(IRemarkRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CreateRemarkCommandResult> Handle(CreateRemarkCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<RemarkEntity>(request);

        await _repository.CreateAsync(entity, cancellationToken);

        return new CreateRemarkCommandResult();
    }
}
