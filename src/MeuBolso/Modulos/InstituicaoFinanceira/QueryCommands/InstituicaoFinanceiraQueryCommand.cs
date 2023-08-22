using MeuBolso.Infraestrutura.QueryCommands;
using MeuBolso.Modulos.InstituicaoFinanceira.Entidades;

namespace MeuBolso.Modulos.InstituicaoFinanceira.QueryCommands;

public class InstituicaoFinanceiraQueryCommand : HasIdQueryCommand<InstituicaoFinanceiraEntity>
{
    public string? Query { get; set; }

    public override IQueryable<InstituicaoFinanceiraEntity> Apply(IQueryable<InstituicaoFinanceiraEntity> queryable)
    {
        queryable = base.Apply(queryable);

        if (!string.IsNullOrEmpty(Query))
            queryable = queryable.Where(w => w.Nome!.Contains(Query));

        return queryable.OrderBy(w => w.Nome);
    }
}