using System.Drawing;

namespace MeuBolso.Modulos.CategoriaMovimentacao.Entidades
{
    public class CategoriaMovimentacaoEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Nome { get; set; }
        public Color? Cores { get; set; }
        public decimal PrevisaoGastoMes { get; set; }
    }
}
