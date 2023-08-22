using FluentValidation;
using MeuBolso.Infraestrutura.Validations;
using MeuBolso.Modulos.InstituicaoFinanceira.Entidades;

namespace MeuBolso.Modulos.InstituicaoFinanceira.Validations;

public class InstituicaoFinanceiraValidator : HasIdValidator<InstituicaoFinanceiraEntity>
{
    public InstituicaoFinanceiraValidator()
    {
        RuleFor(c => c.Nome)
            .NotEmpty()
            .MaximumLength(255);
    }
}