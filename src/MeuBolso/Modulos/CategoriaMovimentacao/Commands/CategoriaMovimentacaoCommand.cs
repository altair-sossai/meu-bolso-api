using MeuBolso.Infraestrutura.Commands;
using MeuBolso.Modulos.CategoriaMovimentacao.Enum;

namespace MeuBolso.Modulos.CategoriaMovimentacao.Commands;

public class CategoriaMovimentacaoCommand : CommandWithId
{
    public string? Nome { get; set; }
    public Cores Cor { get; set; }
    public decimal PrevisaoGastoMes { get; set; }
}