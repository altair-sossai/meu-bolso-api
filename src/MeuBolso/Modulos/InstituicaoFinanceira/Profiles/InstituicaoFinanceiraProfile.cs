using AutoMapper;
using MeuBolso.Modulos.InstituicaoFinanceira.Commands;
using MeuBolso.Modulos.InstituicaoFinanceira.Entidades;

namespace MeuBolso.Modulos.InstituicaoFinanceira.Profiles;

public class InstituicaoFinanceiraProfile : Profile
{
    public InstituicaoFinanceiraProfile()
    {
        CreateMap<InstituicaoFinanceiraCommand, InstituicaoFinanceiraEntity>();
    }
}