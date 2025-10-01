using FarmGuard_Backend.MedicHistory.Domain.Model.Commands;
using FarmGuard_Backend.MedicHistory.Domain.Model.Queries;
using FarmGuard_Backend.MedicHistory.Domain.Services;
using FarmGuard_Backend.MedicHistory.Interfaces.Rest.resources;
using FarmGuard_Backend.MedicHistory.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;

namespace FarmGuard_Backend.MedicHistory.Interfaces.Rest;

[ApiController]
[Route("api/v1/medications")]
public class MedicationController(IMedicationCommandService medicationCommandService, IMedicationQueryService medicationQueryService) : ControllerBase
{
    [HttpPost("{treatmentId}")]
    public async Task<IActionResult> AddMedication([FromBody] CreateMedicationResource resource, int treatmentId)
    {
        var createMedicationCommand = CreateMedicationCommandFromResourceAssembler.ToCommandFromResource(resource, treatmentId);
        var medication = await medicationCommandService.Handle(createMedicationCommand);
        return Ok(medication);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMedicationById(int id)
    {
        var medication = await medicationQueryService.HandleById(new GetMedicationById(id));
        if (medication == null) return NotFound();
        var resource = MedicationResourceFromEntityAssembler.ToEntityFromResource(medication);
        return Ok(resource);
    }
    
    [HttpGet("by-treatment/{treatmentId}")]
    public async Task<IActionResult> GetByAnimalId(int treatmentId)
    {
        var result = await medicationQueryService.HandleByTreatmentId(new GetMedicationsByTreatmentId(treatmentId));
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMedicationById(int id)
    {
        var result = await medicationCommandService.Handle(new DeleteMedicationCommand(id));
        return Ok(result);
    }
}

