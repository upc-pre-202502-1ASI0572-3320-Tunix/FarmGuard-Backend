using FarmGuard_Backend.MedicHistory.Domain.Model.Commands;
using FarmGuard_Backend.MedicHistory.Domain.Model.Queries;
using FarmGuard_Backend.MedicHistory.Domain.Services;
using FarmGuard_Backend.MedicHistory.Interfaces.Rest.resources;
using FarmGuard_Backend.MedicHistory.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;

namespace FarmGuard_Backend.MedicHistory.Interfaces.Rest;

[ApiController]
[Route("api/v1/diseases")]
public class DiseaseController(IDiseaseCommandService diseaseCommandService, IDiseaseQueryService diseaseQueryService) : ControllerBase
{
    [HttpPost("{diseaseDiagnosisId}")]
    public async Task<IActionResult> AddDisease([FromBody] CreateDiseaseResource resource, int diseaseDiagnosisId)
    {
        var createDiseaseCommand = CreateDiseaseCommandFromResourceAssembler.ToCommandFromResource(resource,diseaseDiagnosisId);
        var disease = await diseaseCommandService.Handle(createDiseaseCommand);
        return Ok(disease);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDiseaseById(int id)
    {
        var disease = await diseaseQueryService.HandleById(new GetDiseaseById(id));
        if (disease == null) return NotFound();
        var resource = DiseaseResourceFromEntityAssembler.ToEntityFromResource(disease);
        return Ok(resource);
    }
    
    [HttpGet("by-diseasediagnosis/{id}")]
    public async Task<IActionResult> GetDiseaseByDiseaseDiagnosisId(int id)
    {
        var disease = await diseaseQueryService.HandleByDiseaseDiagnosisId(new GetDiseaseByDiseaseDiagnosisId(id));

        var resource = disease.Select(DiseaseResourceFromEntityAssembler.ToEntityFromResource);
        return Ok(resource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDiseaseById(int id)
    {
        var result = await diseaseCommandService.Handle(new DeleteDiseaseCommand(id));
        return Ok(result);
    }
}