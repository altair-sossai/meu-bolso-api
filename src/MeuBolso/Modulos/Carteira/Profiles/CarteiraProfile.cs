using AutoMapper;
using MeuBolso.Modulos.Carteira.Commands;
using MeuBolso.Modulos.Carteira.Entidades;

namespace MeuBolso.Modulos.Carteira.Profiles;

// Classe responsável por definir os mapeamentos entre tipos relacionados à entidade Carteira.
public class CarteiraProfile : Profile
{
    public CarteiraProfile()
    {
        // Cria um mapeamento entre a classe CarteiraCommand e a classe CarteiraEntity.
        CreateMap<CarteiraCommand, CarteiraEntity>();
        // Esse mapeamento permite que os valores de CarteiraCommand sejam copiados para uma instância de CarteiraEntity.
    }
}