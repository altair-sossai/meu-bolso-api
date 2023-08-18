using System.Linq;

namespace MeuBolso.Infraestrutura.QueryCommands
{
    public class HasIdQueryCommand <T> : PaginationQueryCommand<T>
    {
        public Guid? Id { get; set; }
        public HashSet<Guid>? Ids { get; set; }
        public HashSet<Guid>? IgnoreIds { get; set; }
       

        public override IQueryable<T> Apply(IQueryable<T> queryable)
        {
            base.Apply(queryable);

            if (Id.HasValue)
                queryable = queryable.Where(Id == Id.Value);

            if (Ids != null && Ids.Any())
                queryable = queryable.Where(Ids.Contains(Id));

            if (IgnoreIds != null && IgnoreIds.Any())
                queryable = queryable.Where(IgnoreIds.Contains(Id));

            return queryable;
        }
    }
}