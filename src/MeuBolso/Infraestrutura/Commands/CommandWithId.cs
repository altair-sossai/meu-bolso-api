using MeuBolso.Infraestrutura.Contracts;

namespace MeuBolso.Infraestrutura.Commands;

public abstract class CommandWithId : IHasId
{
    public Guid Id { get; set; } = Guid.NewGuid();
}