using MeuBolso.Infraestrutura.Contracts;

namespace MeuBolso.Infraestrutura.Services;

public interface IBaseService<TEntity, in TAddCommand, in TUpdateCommand, in TKey>
    where TEntity : IHasId<TKey>
    where TUpdateCommand : IHasId<TKey>
    where TKey : struct
{
    Task<TEntity?> FindAsync(TKey id, CancellationToken cancellationToken);
    Task<TEntity> AddAsync(TAddCommand command, CancellationToken cancellationToken);
    Task<TEntity?> UpdateAsync(TUpdateCommand updateCommand, CancellationToken cancellationToken);
    Task DeleteAsync(TKey id, CancellationToken cancellationToken);
}

public interface IBaseService<TEntity, in TCommand, in TKey> : IBaseService<TEntity, TCommand, TCommand, TKey>
    where TEntity : IHasId<TKey>
    where TCommand : IHasId<TKey>
    where TKey : struct
{
}

public interface IBaseService<TEntity, in TCommand> : IBaseService<TEntity, TCommand, Guid>
    where TEntity : IHasId<Guid>
    where TCommand : IHasId<Guid>
{
}