namespace MeuBolso.Infraestrutura.Contracts;

public interface IHasId<TId>
    where TId : struct
{
    public TId Id { get; set; }
}

public interface IHasId : IHasId<Guid>
{
}