using MeuBolso.Infraestrutura.QueryCommands;
using MeuBolso.Modulos.Carteira.Entidades;

namespace MeuBolso.Modulos.Carteira.QueryCommands;

public class CarteiraQueryCommand : PaginationQueryCommand<CarteiraEntity>
{
    public Guid? Id { get; set; }
    public HashSet<Guid>? Ids { get; set; }
    public HashSet<Guid>? IgnoreIds { get; set; }
    public string? Query { get; set; }

    public override IQueryable<CarteiraEntity> Apply(IQueryable<CarteiraEntity> queryable)
    {
        queryable = base.Apply(queryable);

        if (Id.HasValue)
            queryable = queryable.Where(w => w.Id == Id.Value);

        if (Ids != null && Ids.Any())
            queryable = queryable.Where(w => Ids.Contains(w.Id));

        if (IgnoreIds != null && IgnoreIds.Any())
            queryable = queryable.Where(w => !IgnoreIds.Contains(w.Id));

        if (!string.IsNullOrEmpty(Query))
            queryable = queryable.Where(w => w.Descricao!.Contains(Query));

        return queryable
            .OrderBy(o => o.Descricao);
    }
}