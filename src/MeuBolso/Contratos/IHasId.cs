namespace MeuBolso.Contratos;

public interface IHasId<TId>
    where TId : struct
{
    public TId Id { get; set; }
}

public interface IHasId : IHasId<Guid>
{
}