using MeuBolso.Modulos.CategoriaMovimentacao.Entidades;

namespace MeuBolso.Modulos.CategoriaMovimentacao.QueryCommands;

public class CategoriaMovimentacaoQueryCommand
{
    public string? Query { get; set; }

    public IQueryable<CategoriaMovimentacaoEntity> Apply(IQueryable<CategoriaMovimentacaoEntity> queryable)
    {
        if (!string.IsNullOrEmpty(Query))
            queryable = queryable.Where(w => w.Nome!.Contains(Query));

        return queryable.OrderBy(o => o.Nome);
    }
}