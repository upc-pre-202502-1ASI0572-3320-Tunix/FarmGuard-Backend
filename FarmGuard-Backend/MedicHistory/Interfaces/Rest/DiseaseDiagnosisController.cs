using System.Runtime.InteropServices.JavaScript;
using FarmGuard_Backend.MedicHistory.Domain.Model.Commands;
using FarmGuard_Backend.MedicHistory.Domain.Model.Queries;
using FarmGuard_Backend.MedicHistory.Domain.Services;
using FarmGuard_Backend.MedicHistory.Interfaces.Rest.resources;
using Microsoft.AspNetCore.Mvc;

namespace FarmGuard_Backend.MedicHistory.Interfaces.Rest;

[ApiController]
[Route("api/v1/diseasediagnosis")]
public class DiseaseDiagnosisController(IDiseaseDiagnosisCommandService commandService, IDiseaseDiagnosisQueryService queryService) : ControllerBase
{
    [HttpPost("{medicalHistoryId}")]
    public async Task<IActionResult> Add([FromBody] CreateDiseaseDiagnosisResource resource,int medicalHistoryId)
    {
        var command = new CreateDiseaseDiagnosisCommand(
            resource.Severity,
            resource.Notes,
            resource.DiagnosedAt,
            medicalHistoryId
        );
        var result = await commandService.Handle(command);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await queryService.HandleById(new GetDiseaseDiagnosisById(id));
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpGet("by-medicalhistory/{medicalHistoryId}")]
    public async Task<IActionResult> GetByMedicalHistoryId(int medicalHistoryId)
    {
        var result = await queryService.HandleByMedicalHistoryId(new GetDiseaseDiagnosisByMedicalHistoryId(medicalHistoryId));
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await commandService.Handle(new DeleteDiseaseDiagnosisCommand(id));
        return Ok(result);
    }
}




