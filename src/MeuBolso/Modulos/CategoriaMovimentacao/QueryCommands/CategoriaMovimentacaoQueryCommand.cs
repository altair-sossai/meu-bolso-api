using MeuBolso.Infraestrutura.QueryCommands;
using MeuBolso.Modulos.CategoriaMovimentacao.Entidades;

namespace MeuBolso.Modulos.CategoriaMovimentacao.QueryCommands;

public class CategoriaMovimentacaoQueryCommand : HasIdQueryCommand<CategoriaMovimentacaoEntity>
{
    public string? Query { get; set; }

    public override IQueryable<CategoriaMovimentacaoEntity> Apply(IQueryable<CategoriaMovimentacaoEntity> queryable)
    {
        queryable = base.Apply(queryable);

        if (!string.IsNullOrEmpty(Query))
            queryable = queryable.Where(w => w.Nome!.Contains(Query));

        return queryable.OrderBy(o => o.Nome);
    }
}