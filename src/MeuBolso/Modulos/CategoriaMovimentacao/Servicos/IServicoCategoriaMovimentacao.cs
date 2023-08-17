using MeuBolso.Modulos.CategoriaMovimentacao.Commands;
using MeuBolso.Modulos.CategoriaMovimentacao.Entidades;

namespace MeuBolso.Modulos.CategoriaMovimentacao.Servicos;

public interface IServicoCategoriaMovimentacao
{
    Task<CategoriaMovimentacaoEntity> AdicionarAsync(CategoriaMovimentacaoCommand command, CancellationToken cancellationToken);
    Task<CategoriaMovimentacaoEntity?> AtualizarAsync(CategoriaMovimentacaoCommand command, CancellationToken cancellationToken);
    Task ExcluirAsync(Guid id, CancellationToken cancellationToken);
}