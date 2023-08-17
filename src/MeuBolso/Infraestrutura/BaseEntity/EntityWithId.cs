namespace MeuBolso.Infraestrutura.BaseEntity
{
    public abstract class EntityWithId
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
