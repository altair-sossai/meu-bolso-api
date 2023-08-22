using FluentValidation;
using MeuBolso.Infraestrutura.Contracts;
using System.Data;

namespace MeuBolso.Infraestrutura.Validations;
public abstract class HasIdValidator<T, TKey> : AbstractValidator<T>
    where T : IHasId<TKey>
    where TKey : struct
{
    public HasIdValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}

public abstract class HasIdValidator<T> : HasIdValidator<T, Guid>
    where T : IHasId<Guid>
{
}



