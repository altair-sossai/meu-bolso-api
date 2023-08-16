using AutoMapper;
using MeuBolso.Modulos.CategoriaMovimentacao.Commands;
using MeuBolso.Modulos.CategoriaMovimentacao.Entidades;

namespace MeuBolso.Modulos.CategoriaMovimentacao.Profiles
{
    public class CategoriaMovimentacaoProfile : Profile
    {
        public CategoriaMovimentacaoProfile()
        {
            CreateMap<CategoriaMovimentacaoCommand, CategoriaMovimentacaoEntity>();
        }
    }
}
