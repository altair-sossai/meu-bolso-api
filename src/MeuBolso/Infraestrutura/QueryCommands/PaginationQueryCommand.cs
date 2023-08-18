namespace MeuBolso.Infraestrutura.QueryCommands;

public class PaginationQueryCommand<T> : IQueryCommand<T>
{
    private const int DefaultSkip = 0;
    private const int DefaultTake = 5_000;

    public int? Skip { get; set; } = DefaultSkip;
    public int? Take { get; set; } = DefaultTake;

    public virtual IQueryable<T> Apply(IQueryable<T> queryable)
    {
        return queryable
            .Skip(Skip ?? DefaultSkip)
            .Take(Take ?? DefaultTake);
    }
}