using MeuBolso.Infraestrutura.Commands;

namespace MeuBolso.Modulos.Carteira.Commands;

public class CarteiraCommand : CommandWithId
{
    public string? Descricao { get; set; }
}