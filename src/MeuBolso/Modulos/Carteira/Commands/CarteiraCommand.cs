namespace MeuBolso.Modulos.Carteira.Commands;

public class CarteiraCommand
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Descricao { get; set; }
}