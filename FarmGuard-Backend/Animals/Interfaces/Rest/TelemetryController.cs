using FarmGuard_Backend.Animals.Interfaces.Hubs;
using FarmGuard_Backend.Animals.Interfaces.Hubs.resources;
using FarmGuard_Backend.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace FarmGuard_Backend.Animals.Interfaces.Rest;

[ApiController]
[Route("api/v1/telemetry")]
public class TelemetryController(
    IHubContext<TelemetryHub> _hubContext
    ) : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult> ReceiveTelemetry([FromBody] TelemetryResource data)
    {
        await _hubContext.Clients.Group(data.device_id).SendAsync("ReceiveTelemetry", data);
        return Ok(new { status = "Enviados en tiempo real" });
    }
}
