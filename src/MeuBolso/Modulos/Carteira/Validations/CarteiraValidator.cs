using FluentValidation;
using MeuBolso.Infraestrutura.Validations;
using MeuBolso.Modulos.Carteira.Entidades;

namespace MeuBolso.Modulos.Carteira.Validations;

public class CarteiraValidator : HasIdValidator<CarteiraEntity>
{
    public CarteiraValidator()
    {
        RuleFor(c => c.Descricao)
            .NotEmpty()
            .MaximumLength(255);
    }
}