using FluentValidation;
using MeuBolso.Modulos.InstituicaoFinanceira.Entidades;

namespace MeuBolso.Modulos.InstituicaoFinanceira.Validations
{
    public class InstituicaoFinanceiraValidator : AbstractValidator<InstituicaoFinanceiraEntity>
    {
        public InstituicaoFinanceiraValidator()
        {
            RuleFor(c => c.Id).NotEmpty();

            RuleFor(c => c.Nome).NotEmpty().MaximumLength(255);
        }
    }
}
