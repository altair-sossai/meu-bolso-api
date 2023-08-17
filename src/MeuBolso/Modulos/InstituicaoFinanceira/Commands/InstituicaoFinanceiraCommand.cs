namespace MeuBolso.Modulos.InstituicaoFinanceira.Commands
{
    public class InstituicaoFinanceiraCommand
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Nome { get; set; }
    }
}
