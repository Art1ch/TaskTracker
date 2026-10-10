namespace TaskTracker.Application.Abstractions.Repository;

public interface IRepository<TEntity> where TEntity : class
{
    Task CreateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<TEntity> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
}
