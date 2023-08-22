using MeuBolso.Infraestrutura.Mappings;
using MeuBolso.Modulos.CategoriaMovimentacao.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuBolso.Modulos.CategoriaMovimentacao.Mapping;

public class CategoriaMovimentacaoMapping : HasIdMapping<CategoriaMovimentacaoEntity>
{
    public override void Configure(EntityTypeBuilder<CategoriaMovimentacaoEntity> builder)
    {
        base.Configure(builder);

        builder.ToTable("CategoriaMovimentacao");

        builder.Property(x => x.Nome)
            .HasMaxLength(255);

        builder.Property(x => x.PrevisaoGastoMes)
            .HasColumnType("decimal(18,2)");
    }
}