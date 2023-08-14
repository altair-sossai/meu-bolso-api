namespace MeuBolso.Api.Results;

public class PingResult
{
    public PingResult(Guid instanceId)
    {
        InstanceId = instanceId;
    }

    public Guid InstanceId { get; }
    public DateTime Now { get; } = DateTime.UtcNow;
}