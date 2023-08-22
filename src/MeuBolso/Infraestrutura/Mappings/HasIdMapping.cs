using MeuBolso.Infraestrutura.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuBolso.Infraestrutura.Mappings;

public abstract class HasIdMapping<T, TKey> : IEntityTypeConfiguration<T>
    where T : class, IHasId<TKey>
    where TKey : struct
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(c => c.Id);
    }
}

public abstract class HasIdMapping<T> : HasIdMapping<T, Guid>
    where T : class, IHasId<Guid>
{
}