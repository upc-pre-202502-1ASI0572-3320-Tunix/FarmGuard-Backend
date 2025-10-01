using FarmGuard_Backend.MedicHistory.Domain.Model.Commands;
using FarmGuard_Backend.MedicHistory.Domain.Model.Queries;
using FarmGuard_Backend.MedicHistory.Domain.Services;
using FarmGuard_Backend.MedicHistory.Interfaces.Rest.resources;
using FarmGuard_Backend.MedicHistory.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;

namespace FarmGuard_Backend.MedicHistory.Interfaces.Rest;

[ApiController]
[Route("api/v1/treatments")]
public class TreatmentController(ITreatmentCommandService treatmentCommandService, ITreatmentQueryService treatmentQueryService) : ControllerBase
{
    [HttpPost("{medicalHistoryId}")]
    public async Task<IActionResult> AddTreatment([FromBody] CreateTreatmentResource resource,int medicalHistoryId)
    {
        var createTreatmentCommand = CreateTreatmentCommandFromResourceAssembler.ToCommandFromResource(resource, medicalHistoryId);
        var treatment = await treatmentCommandService.Handle(createTreatmentCommand);
        return Ok(treatment);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTreatmentById(int id)
    {
        var treatment = await treatmentQueryService.HandleById(new GetTreatmentsById(id));
        if (treatment == null) return NotFound();
        var resource = TreatmentResourceFromEntityAssembler.ToEntityFromResource(treatment);
        return Ok(resource);
    }
    
    [HttpGet("by-medicalhistory/{medicalHistoryId}")]
    public async Task<IActionResult> GetByMedicalHistoryId(int medicalHistoryId)
    {
        var result =
            await treatmentQueryService.HandleByMedicalHistoryId(new GetTreatmentsByMedicalHistoryId(medicalHistoryId));
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTreatmentById(int id)
    {
        var result = await treatmentCommandService.Handle(new DeleteTreatmentCommand(id));
        return Ok(result);
    }
}
