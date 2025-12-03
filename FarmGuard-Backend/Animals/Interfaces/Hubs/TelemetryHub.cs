using Microsoft.AspNetCore.SignalR;
namespace FarmGuard_Backend.Animals.Interfaces.Hubs;

public class TelemetryHub: Hub
{
    public override async Task OnConnectedAsync()
    {
        // 1. Obtenemos el valor del campo por el cual quiere filtrar el Frontend
        // El Frontend enviará esto en la URL: ?filtro=GraneroA
        var campoFiltro = Context.GetHttpContext()?.Request.Query["filtro"];

        if (!string.IsNullOrEmpty(campoFiltro))
        {
            // 2. MAGIA: Agregamos esta conexión al grupo con ese nombre exacto
            await Groups.AddToGroupAsync(Context.ConnectionId, campoFiltro);
        }

        await base.OnConnectedAsync();
    }
}