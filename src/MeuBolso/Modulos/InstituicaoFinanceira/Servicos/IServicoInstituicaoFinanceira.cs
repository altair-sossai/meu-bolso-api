using MeuBolso.Modulos.InstituicaoFinanceira.Commands;
using MeuBolso.Modulos.InstituicaoFinanceira.Entidades;

namespace MeuBolso.Modulos.InstituicaoFinanceira.Servicos;

public interface IServicoInstituicaoFinanceira
{
    Task<InstituicaoFinanceiraEntity> AdicionarAsync(InstituicaoFinanceiraCommand command, CancellationToken cancellationToken);
    Task<InstituicaoFinanceiraEntity?> AtualizarAsync(InstituicaoFinanceiraCommand command, CancellationToken cancellationToken);
    Task ExcluirAsync(Guid id, CancellationToken cancellationToken);
}