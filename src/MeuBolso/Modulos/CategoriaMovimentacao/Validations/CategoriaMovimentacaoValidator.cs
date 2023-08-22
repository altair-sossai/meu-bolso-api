using FluentValidation;
using MeuBolso.Infraestrutura.Validations;
using MeuBolso.Modulos.CategoriaMovimentacao.Entidades;

namespace MeuBolso.Modulos.CategoriaMovimentacao.Validations;

public class CategoriaMovimentacaoValidator : HasIdValidator<CategoriaMovimentacaoEntity>
{
    public CategoriaMovimentacaoValidator()
    {
        RuleFor(c => c.Nome)
            .NotEmpty()
            .MaximumLength(255);

        RuleFor(r => r.Cor)
            .IsInEnum();
    }
}