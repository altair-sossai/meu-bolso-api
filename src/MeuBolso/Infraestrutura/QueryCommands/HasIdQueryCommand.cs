using MeuBolso.Infraestrutura.Contracts;
using System.Linq;

namespace MeuBolso.Infraestrutura.QueryCommands
{
    public class HasIdQueryCommand <T> : PaginationQueryCommand<T>
        where T:IHasId
    {
        public Guid? Id { get; set; }
        public HashSet<Guid>? Ids { get; set; }
        public HashSet<Guid>? IgnoreIds { get; set; }
       

        public override IQueryable<T> Apply(IQueryable<T> queryable)
        {
            queryable = base.Apply(queryable);

            if (Id.HasValue)
                queryable = queryable.Where(w => w.Id == Id.Value);

            if (Ids != null && Ids.Any())
                queryable = queryable.Where(w => Ids.Contains(w.Id));

            if (IgnoreIds != null && IgnoreIds.Any())
                queryable = queryable.Where(w => IgnoreIds.Contains(w.Id));

            return queryable;
        }
    }
}