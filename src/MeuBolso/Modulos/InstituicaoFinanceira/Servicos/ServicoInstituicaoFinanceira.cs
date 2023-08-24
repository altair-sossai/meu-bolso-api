using AutoMapper;
using FluentValidation;
using MeuBolso.Infraestrutura.Services;
using MeuBolso.Modulos.InstituicaoFinanceira.Commands;
using MeuBolso.Modulos.InstituicaoFinanceira.Entidades;
using Microsoft.EntityFrameworkCore;

namespace MeuBolso.Modulos.InstituicaoFinanceira.Servicos;

public class ServicoInstituicaoFinanceira : BaseService<InstituicaoFinanceiraEntity, InstituicaoFinanceiraCommand, InstituicaoFinanceiraCommand, Guid>, IServicoInstituicaoFinanceira
{
    public ServicoInstituicaoFinanceira(DbContext context, IMapper mapper, IValidator<InstituicaoFinanceiraEntity> validator) : base(context, mapper, validator)
    {
    }

    public async Task<InstituicaoFinanceiraEntity?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await FindAsync(id, cancellationToken);
    }

    public async Task<InstituicaoFinanceiraEntity> AdicionarAsync(InstituicaoFinanceiraCommand command, CancellationToken cancellationToken)
    {
        return await AddAsync(command, cancellationToken);
    }

    public async Task<InstituicaoFinanceiraEntity?> AtualizarAsync(InstituicaoFinanceiraCommand command, CancellationToken cancellationToken)
    {
        return await UpdateAsync(command, cancellationToken);
    }

    public async Task ExcluirAsync(Guid id, CancellationToken cancellationToken)
    {
        await DeleteAsync(id, cancellationToken);
    }
}