using MeuBolso.Infraestrutura.Mappings;
using MeuBolso.Modulos.Carteira.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuBolso.Modulos.Carteira.Mapping;

public class CarteiraMapping : HasIdMapping<CarteiraEntity>
{
    public override void Configure(EntityTypeBuilder<CarteiraEntity> builder)
    {
        base.Configure(builder);

        builder.ToTable("Carteiras");

        builder.Property(c => c.Descricao)
            .HasMaxLength(255);

        builder.Property(c => c.Saldo)
            .HasColumnType("decimal(18,2)");
    }
}