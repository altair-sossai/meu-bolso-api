using AutoMapper;
using FluentValidation;
using MeuBolso.Context;
using MeuBolso.Infraestrutura.Services;
using MeuBolso.Modulos.CategoriaMovimentacao.Commands;
using MeuBolso.Modulos.CategoriaMovimentacao.Entidades;

namespace MeuBolso.Modulos.CategoriaMovimentacao.Servicos;

public class ServicoCategoriaMovimentacao : BaseService<CategoriaMovimentacaoEntity, CategoriaMovimentacaoCommand, CategoriaMovimentacaoCommand, Guid>
{
    public ServicoCategoriaMovimentacao(AppDbContext context, IMapper mapper, IValidator<CategoriaMovimentacaoEntity> validator) : base(context, mapper, validator)
    {
    }
}