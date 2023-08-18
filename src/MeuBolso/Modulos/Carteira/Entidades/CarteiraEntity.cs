using MeuBolso.Infraestrutura.Entitites;

namespace MeuBolso.Modulos.Carteira.Entidades;

public class CarteiraEntity : EntityWithId
{
    public string? Descricao { get; set; }
    public decimal Saldo { get; set; }
}