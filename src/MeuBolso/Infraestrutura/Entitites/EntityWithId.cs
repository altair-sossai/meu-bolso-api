using MeuBolso.Infraestrutura.Contracts;

namespace MeuBolso.Infraestrutura.Entitites;

public abstract class EntityWithId : IHasId
{
    public Guid Id { get; set; } = Guid.NewGuid();
}