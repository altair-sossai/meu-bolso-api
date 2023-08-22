using FluentValidation;
using MeuBolso.Infraestrutura.Contracts;

namespace MeuBolso.Infraestrutura.Validations;

public abstract class HasIdValidator<T, TKey> : AbstractValidator<T>
    where T : IHasId<TKey>
    where TKey : struct
{
    protected HasIdValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty();
    }
}

public abstract class HasIdValidator<T> : HasIdValidator<T, Guid>
    where T : IHasId<Guid>
{
}