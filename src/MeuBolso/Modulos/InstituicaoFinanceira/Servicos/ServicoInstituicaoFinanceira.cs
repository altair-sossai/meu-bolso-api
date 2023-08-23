using AutoMapper;
using FluentValidation;
using MeuBolso.Context;
using MeuBolso.Infraestrutura.Services;
using MeuBolso.Modulos.InstituicaoFinanceira.Commands;
using MeuBolso.Modulos.InstituicaoFinanceira.Entidades;

namespace MeuBolso.Modulos.InstituicaoFinanceira.Servicos;

public class ServicoInstituicaoFinanceira : BaseService<InstituicaoFinanceiraEntity, InstituicaoFinanceiraCommand, InstituicaoFinanceiraCommand, Guid>
{
    public ServicoInstituicaoFinanceira(AppDbContext context, IMapper mapper, IValidator<InstituicaoFinanceiraEntity> validator) : base(context, mapper, validator)
    {
    }
}