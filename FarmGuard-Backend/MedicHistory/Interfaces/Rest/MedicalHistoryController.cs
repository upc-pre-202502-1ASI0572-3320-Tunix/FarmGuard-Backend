using FarmGuard_Backend.MedicHistory.Domain.Model.Commands;
using FarmGuard_Backend.MedicHistory.Domain.Model.Queries;
using FarmGuard_Backend.MedicHistory.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace FarmGuard_Backend.MedicHistory.Interfaces.Rest;

[ApiController]
[Route("api/v1/medicalhistory")]
public class MedicalHistoryController(IMedicalHistoryCommandService commandService, IMedicalHistoryQueryService queryService) : ControllerBase
{
    

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await queryService.HandleById(new GetMedicalHistoryById(id));
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpGet("by-animal/{animalId}")]
    public async Task<IActionResult> GetByAnimalId(int animalId)
    {
        var result = await queryService.HandleByAnimalId(new GetMedicalHistoryByAnimalId(animalId));
        if (result == null)
            return NotFound(new { message = $"No se encontró historial médico para el animal {animalId}" });
        System.Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(result));
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await commandService.Handle(new DeleteMedicalHistoryCommand(id));
        return Ok(result);
    }
}

