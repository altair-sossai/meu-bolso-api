using MeuBolso.Infraestrutura.Mappings;
using MeuBolso.Modulos.InstituicaoFinanceira.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuBolso.Modulos.InstituicaoFinanceira.Mapping;

public class InstituicaoFinanceiraMapping : HasIdMapping<InstituicaoFinanceiraEntity>
{
    public override void Configure(EntityTypeBuilder<InstituicaoFinanceiraEntity> builder)
    {
        base.Configure(builder);

        builder.ToTable("InstituicaoFinanceira");

        builder.Property(c => c.Nome)
            .HasMaxLength(255);
    }
}