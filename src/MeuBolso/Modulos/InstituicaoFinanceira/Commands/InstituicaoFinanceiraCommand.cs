using MeuBolso.Infraestrutura.Commands;

namespace MeuBolso.Modulos.InstituicaoFinanceira.Commands;

public class InstituicaoFinanceiraCommand : CommandWithId
{
    public string? Nome { get; set; }
}