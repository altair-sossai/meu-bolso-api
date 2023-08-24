using AutoMapper;
using FluentValidation;
using MeuBolso.Context;
using MeuBolso.Infraestrutura.Services;
using MeuBolso.Modulos.InstituicaoFinanceira.Commands;
using MeuBolso.Modulos.InstituicaoFinanceira.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

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

    public async Task ExcluirAsync(Guid Id, CancellationToken cancellationToken)
    {
        await DeleteAsync(Id, cancellationToken);
    }
}