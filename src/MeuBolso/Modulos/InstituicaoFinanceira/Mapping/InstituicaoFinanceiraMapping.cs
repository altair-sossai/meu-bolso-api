using MeuBolso.Modulos.InstituicaoFinanceira.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuBolso.Modulos.InstituicaoFinanceira.Mapping
{
    public class InstituicaoFinanceiraMapping : IEntityTypeConfiguration<InstituicaoFinanceiraEntity>
    {
        public void Configure(EntityTypeBuilder<InstituicaoFinanceiraEntity> builder)
        {
            builder.ToTable("InstituicaoFinanceira");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).HasMaxLength(255);
        }
    }
}
