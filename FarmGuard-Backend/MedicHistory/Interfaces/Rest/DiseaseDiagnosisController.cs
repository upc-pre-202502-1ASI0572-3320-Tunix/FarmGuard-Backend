using System.Runtime.InteropServices.JavaScript;
using FarmGuard_Backend.MedicHistory.Domain.Model.Commands;
using FarmGuard_Backend.MedicHistory.Domain.Model.Queries;
using FarmGuard_Backend.MedicHistory.Domain.Services;
using FarmGuard_Backend.MedicHistory.Interfaces.Rest.resources;
using Microsoft.AspNetCore.Mvc;

namespace FarmGuard_Backend.MedicHistory.Interfaces.Rest;

[ApiController]
[Route("api/v1/diseasediagnosis")]
public class DiseaseDiagnosisController(
    IDiseaseDiagnosisCommandService commandService, 
    IDiseaseDiagnosisQueryService queryService,
    ILogger<DiseaseDiagnosisController> logger) : ControllerBase
{
    [HttpPost("{medicalHistoryId}")]
    public async Task<IActionResult> Add([FromBody] CreateDiseaseDiagnosisResource resource, int medicalHistoryId)
    {
        try
        {
            // Log para debugging
            logger.LogInformation("POST DiseaseDiagnosis - MedicalHistoryId: {MedicalHistoryId}, Severity: {Severity}, Notes: {Notes}, DiagnosedAt: {DiagnosedAt}", 
                medicalHistoryId, resource?.Severity, resource?.Notes, resource?.DiagnosedAt);

            // Validaciones
            if (resource == null)
            {
                logger.LogWarning("Resource is null");
                return BadRequest(new { error = "El cuerpo de la solicitud es requerido" });
            }

            if (medicalHistoryId <= 0)
            {
                logger.LogWarning("Invalid medicalHistoryId: {MedicalHistoryId}", medicalHistoryId);
                return BadRequest(new { error = "El medicalHistoryId debe ser mayor a 0" });
            }

            if (string.IsNullOrWhiteSpace(resource.Severity))
            {
                logger.LogWarning("Severity is null or empty");
                return BadRequest(new { error = "Severity es requerido" });
            }

            if (string.IsNullOrWhiteSpace(resource.Notes))
            {
                logger.LogWarning("Notes is null or empty");
                return BadRequest(new { error = "Notes es requerido" });
            }

            var command = new CreateDiseaseDiagnosisCommand(
                resource.Severity,
                resource.Notes,
                resource.DiagnosedAt,
                medicalHistoryId
            );
            
            var result = await commandService.Handle(command);
            logger.LogInformation("DiseaseDiagnosis created successfully with ID: {Id}", result);
            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error creating DiseaseDiagnosis for MedicalHistoryId: {MedicalHistoryId}", medicalHistoryId);
            return StatusCode(500, new { error = "Error interno del servidor", details = ex.Message });
        }
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
