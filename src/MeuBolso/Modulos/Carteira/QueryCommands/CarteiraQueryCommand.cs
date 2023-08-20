using MeuBolso.Infraestrutura.QueryCommands;
using MeuBolso.Modulos.Carteira.Entidades;

namespace MeuBolso.Modulos.Carteira.QueryCommands;

public class CarteiraQueryCommand : HasIdQueryCommand<CarteiraEntity>
{
    public string? Query { get; set; }

    public override IQueryable<CarteiraEntity> Apply(IQueryable<CarteiraEntity> queryable)
    {
        queryable = base.Apply(queryable);

        if (!string.IsNullOrEmpty(Query))
            queryable = queryable.Where(w => w.Descricao!.Contains(Query));

        return queryable.OrderBy(o => o.Descricao);
    }
}