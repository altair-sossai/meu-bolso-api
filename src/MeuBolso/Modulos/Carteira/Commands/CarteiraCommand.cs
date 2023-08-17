using MeuBolso.Infraestrutura.BaseCommand;

namespace MeuBolso.Modulos.Carteira.Commands;

public class CarteiraCommand : CommandWithId
{
    public string? Descricao { get; set; }
}