using MeuBolso.Modulos.CategoriaMovimentacao.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuBolso.Modulos.CategoriaMovimentacao.Mapping;

public class CategoriaMovimentacaoMapping : IEntityTypeConfiguration<CategoriaMovimentacaoEntity>
{
    public void Configure(EntityTypeBuilder<CategoriaMovimentacaoEntity> builder)
    {
        builder.ToTable("CategoriaMovimentacao");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
            .HasMaxLength(255);

        builder.Property(x => x.PrevisaoGastoMes)
            .HasColumnType("decimal(18,2)");
    }
}