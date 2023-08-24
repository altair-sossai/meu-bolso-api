using AutoMapper;
using FluentValidation;
using MeuBolso.Infraestrutura.Services;
using MeuBolso.Modulos.Carteira.Commands;
using MeuBolso.Modulos.Carteira.Entidades;
using Microsoft.EntityFrameworkCore;

namespace MeuBolso.Modulos.Carteira.Servicos;

public class ServicoCarteira : BaseService<CarteiraEntity, CarteiraCommand>, IServicoCarteira
{
    public ServicoCarteira(DbContext context, IMapper mapper, IValidator<CarteiraEntity> validator)
        : base(context, mapper, validator)
    {
    }

    public async Task<CarteiraEntity?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await FindAsync(id, cancellationToken);
    }

    public async Task<CarteiraEntity> AdicionarAsync(CarteiraCommand command, CancellationToken cancellationToken)
    {
        return await AddAsync(command, cancellationToken);
    }

    public async Task<CarteiraEntity?> AtualizarAsync(CarteiraCommand command, CancellationToken cancellationToken)
    {
        return await UpdateAsync(command, cancellationToken);
    }

    public async Task ExcluirAsync(Guid id, CancellationToken cancellationToken)
    {
        await DeleteAsync(id, cancellationToken);
    }
}