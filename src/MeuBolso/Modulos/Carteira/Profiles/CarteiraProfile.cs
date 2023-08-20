using AutoMapper;
using MeuBolso.Modulos.Carteira.Commands;
using MeuBolso.Modulos.Carteira.Entidades;

namespace MeuBolso.Modulos.Carteira.Profiles;

public class CarteiraProfile : Profile
{
    public CarteiraProfile()
    {
        CreateMap<CarteiraCommand, CarteiraEntity>();
    }
}