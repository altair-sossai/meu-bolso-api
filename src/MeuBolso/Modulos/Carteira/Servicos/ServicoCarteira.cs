using AutoMapper;
using FluentValidation;
using MeuBolso.Context;
using MeuBolso.Infraestrutura.Services;
using MeuBolso.Modulos.Carteira.Commands;
using MeuBolso.Modulos.Carteira.Entidades;

namespace MeuBolso.Modulos.Carteira.Servicos;

public class ServicoCarteira : BaseService<CarteiraEntity, CarteiraCommand, CarteiraCommand, Guid>
{
    public ServicoCarteira(AppDbContext context, IMapper mapper, IValidator<CarteiraEntity> validator) : base(context, mapper, validator)
    {
    }
}