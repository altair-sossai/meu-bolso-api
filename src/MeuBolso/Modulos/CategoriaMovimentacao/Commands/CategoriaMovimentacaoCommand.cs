using System.Drawing;

namespace MeuBolso.Modulos.CategoriaMovimentacao.Commands
{
    public class CategoriaMovimentacaoCommand
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Nome { get; set; }
        public Color? Cores { get; set; }
        public decimal PrevisaoGastoMes { get; set; }
    }
}
