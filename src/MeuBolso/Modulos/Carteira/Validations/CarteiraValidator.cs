using FluentValidation;
using MeuBolso.Modulos.Carteira.Entidades;

namespace MeuBolso.Modulos.Carteira.Validations;

// Classe responsável por definir as regras de validação para a entidade CarteiraEntity.
public class CarteiraValidator : AbstractValidator<CarteiraEntity>
{
    public CarteiraValidator()
    {
        // Define uma regra de validação para o campo Id da entidade CarteiraEntity.
        RuleFor(c => c.Id)
            .NotEmpty(); // O campo Id não pode estar vazio.

        // Define regras de validação para o campo Descricao da entidade CarteiraEntity.
        RuleFor(c => c.Descricao)
            .NotEmpty() // O campo Descricao não pode estar vazio.
            .MaximumLength(255); // Limita o tamanho máximo da descrição a 255 caracteres.
    }
}