using MeuBolso.Modulos.Carteira.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuBolso.Modulos.Carteira.Mapping;

// Classe responsável por mapear a entidade CarteiraEntity para o banco de dados.
public class CarteiraMapping : IEntityTypeConfiguration<CarteiraEntity>
{
    public void Configure(EntityTypeBuilder<CarteiraEntity> builder)
    {
        // Define o nome da tabela no banco de dados como "Carteiras".
        builder.ToTable("Carteiras");

        // Define a chave primária da tabela como o campo Id da entidade CarteiraEntity.
        builder.HasKey(c => c.Id);

        // Configuração do mapeamento para o campo "Descricao".
        builder.Property(c => c.Descricao)
            .HasMaxLength(255); // Limita o tamanho máximo da descrição a 255 caracteres.

        // Configuração do mapeamento para o campo "Saldo".
        builder.Property(c => c.Saldo)
            .HasColumnType("decimal(18,2)"); // Define o tipo do campo como decimal(18,2), ou seja, um número decimal com 18 dígitos no total e 2 casas decimais.
    }
}