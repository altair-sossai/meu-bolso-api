using MeuBolso.Infraestrutura.Contracts;

namespace MeuBolso.Infraestrutura.Services;

public interface IBaseService<TEntity, TCommand, TUpdateCommand, TKey>
    where TEntity : IHasId<TKey>
    where TCommand : IHasId<TKey>
    where TUpdateCommand : IHasId<TKey>
    where TKey : struct
{
    Task<TEntity?> ObterPorIdAsync(TKey id, CancellationToken cancellationToken);
    Task<TEntity?> AdicionarAsync(TCommand command, CancellationToken cancellationToken);
    Task<TEntity?> UpdateAsync(TUpdateCommand updateCommand, CancellationToken cancellationToken);
    Task DeleteAsync(TKey id, CancellationToken cancellationToken);
}
