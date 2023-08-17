namespace MeuBolso.Modulos.InstituicaoFinanceira.Entidades;

public class InstituicaoFinanceiraEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Nome { get; set; }
}