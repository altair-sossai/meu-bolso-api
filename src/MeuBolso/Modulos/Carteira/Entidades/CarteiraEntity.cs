namespace MeuBolso.Modulos.Carteira.Entidades;

public class CarteiraEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Descricao { get; set; }
    public decimal Saldo { get; set; }
}