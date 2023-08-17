using MeuBolso.Infraestrutura.BaseEntity;
using MeuBolso.Modulos.CategoriaMovimentacao.Enum;

namespace MeuBolso.Modulos.CategoriaMovimentacao.Entidades;

public class CategoriaMovimentacaoEntity : EntityWithId
{
    public string? Nome { get; set; }
    public Cores Cor { get; set; }
    public decimal PrevisaoGastoMes { get; set; }
}