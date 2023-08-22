using MeuBolso.Modulos.CategoriaMovimentacao.Entidades;

namespace MeuBolso.Infraestrutura.QueryCommands;

public interface IQueryCommand<T>
{
    IQueryable<T> Apply(IQueryable<T> queryable);
}