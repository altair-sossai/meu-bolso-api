using MeuBolso.Modulos.CategoriaMovimentacao.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace MeuBolso.Modulos.CategoriaMovimentacao.Entidades
{
    public class CategoriaMovimentacaoEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Nome { get; set; }
        public Cores Cor { get; set; }
        public decimal PrevisaoGastoMes { get; set; }
    }
}
