namespace MeuBolso.Infraestrutura.BaseCommand
{
    public abstract class CommandWithId
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
