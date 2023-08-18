namespace MeuBolso.Infraestrutura.QueryCommands;

public interface IQueryCommand<T>
{
    IQueryable<T> Apply(IQueryable<T> queryable);
}