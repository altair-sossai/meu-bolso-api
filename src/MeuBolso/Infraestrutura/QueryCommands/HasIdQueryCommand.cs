using MeuBolso.Infraestrutura.Contracts;

namespace MeuBolso.Infraestrutura.QueryCommands;

public class HasIdQueryCommand<T, TKey> : IQueryCommand<T>
    where T : IHasId<TKey>
    where TKey : struct
{
    public TKey? Id { get; set; }
    public HashSet<TKey>? Ids { get; set; }
    public HashSet<TKey>? IgnoreIds { get; set; }

    public virtual IQueryable<T> Apply(IQueryable<T> queryable)
    {
        if (Id.HasValue)
            queryable = queryable.Where(w => w.Id.Equals(Id.Value));

        if (Ids != null && Ids.Any())
            queryable = queryable.Where(w => Ids.Contains(w.Id));

        if (IgnoreIds != null && IgnoreIds.Any())
            queryable = queryable.Where(w => !IgnoreIds.Contains(w.Id));

        return queryable;
    }
}

public class HasIdQueryCommand<T> : HasIdQueryCommand<T, Guid>
    where T : IHasId<Guid>
{
}