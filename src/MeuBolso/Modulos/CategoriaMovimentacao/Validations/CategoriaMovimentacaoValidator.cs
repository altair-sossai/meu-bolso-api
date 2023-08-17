using FluentValidation;
using MeuBolso.Modulos.CategoriaMovimentacao.Entidades;

namespace MeuBolso.Modulos.CategoriaMovimentacao.Validations;

public class CategoriaMovimentacaoValidator : AbstractValidator<CategoriaMovimentacaoEntity>
{
    public CategoriaMovimentacaoValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty();

        RuleFor(c => c.Nome)
            .NotEmpty()
            .MaximumLength(255);

        RuleFor(r => r.Cor)
            .IsInEnum();
    }
}