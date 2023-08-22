using MeuBolso.Modulos.Carteira.Commands;
using MeuBolso.Modulos.Carteira.Entidades;

namespace MeuBolso.Modulos.Carteira.Servicos;

public interface IServicoCarteira
{
    Task<CarteiraEntity?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken);
    Task<CarteiraEntity> AdicionarAsync(CarteiraCommand command, CancellationToken cancellationToken);
    Task<CarteiraEntity?> AtualizarAsync(CarteiraCommand command, CancellationToken cancellationToken);
    Task ExcluirAsync(Guid id, CancellationToken cancellationToken);
}