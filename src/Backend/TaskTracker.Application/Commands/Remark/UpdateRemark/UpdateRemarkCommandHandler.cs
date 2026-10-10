using MapsterMapper;
using MediatR;
using TaskTracker.Application.Abstractions.Repository;
using TaskTracker.Core.Entities;

namespace TaskTracker.Application.Commands.Remark.UpdateRemark;

internal sealed class UpdateRemarkCommandHandler : IRequestHandler<UpdateRemarkCommand, UpdateRemarkCommandResult>
{
    private readonly IRemarkRepository _repository;
    private readonly IMapper _mapper;

    public UpdateRemarkCommandHandler(IRemarkRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UpdateRemarkCommandResult> Handle(UpdateRemarkCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<RemarkEntity>(request);

        await _repository.UpdateAsync(entity, cancellationToken);

        return new UpdateRemarkCommandResult();
    }
}
