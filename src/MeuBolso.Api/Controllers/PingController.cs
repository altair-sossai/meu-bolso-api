using MeuBolso.Api.Results;
using Microsoft.AspNetCore.Mvc;

namespace MeuBolso.Api.Controllers;

[ApiController]
[Route("ping")]
public class PingController : ControllerBase
{
    private static readonly Guid InstanceId = Guid.NewGuid();

    [HttpGet]
    public PingResult Get()
    {
        return new PingResult(InstanceId);
    }
}