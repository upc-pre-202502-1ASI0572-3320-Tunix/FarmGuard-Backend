using FarmGuard_Backend.MedicHistory.Application.Internal.QueryServices;
using FarmGuard_Backend.MedicHistory.Domain.Model.Commands;
using FarmGuard_Backend.MedicHistory.Domain.Model.Queries;
using FarmGuard_Backend.MedicHistory.Domain.Services;
using FarmGuard_Backend.MedicHistory.Infrastructure.Persistence.EFC.Repositories;
using FarmGuard_Backend.MedicHistory.Interfaces.Rest.resources;
using FarmGuard_Backend.MedicHistory.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;

namespace FarmGuard_Backend.MedicHistory.Interfaces.Rest;

[ApiController]
[Route("api/v1/vaccines")]
public class VaccineController(IVaccineCommandService vaccineCommandService,IVaccineQueryService vaccineQueryService):ControllerBase
{
    [HttpPost("{medicalHistoryId}")]
    public async Task<IActionResult> AddVaccine([FromBody] CreateVaccineResource resource, int medicalHistoryId)
    {
        var createVaccineCommand = CreateVaccineCommandFromResourceAssembler.ToCommandFromResource(resource, medicalHistoryId);
        var vaccine = await vaccineCommandService.Handle(createVaccineCommand);
        var resourceResult = VaccineResourceFromEntityAssembler.ToEntityFromResource(vaccine);
        
        return Ok(resourceResult);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetVaccineById(int id)
    {
        var vaccine = await vaccineQueryService.Handle(new GetVaccinesById(id));
        if (vaccine == null) return NotFound();
        var resource = VaccineResourceFromEntityAssembler.ToEntityFromResource(vaccine);
        return Ok(resource);
    }
    
    [HttpGet("by-medicalhistory/{medicalHistoryId}")]
    public async Task<IActionResult> GetByMedicalHistoryId(int medicalHistoryId)
    {
        var result =
            await vaccineQueryService.Handle(new GetVaccinesByMedicalHistoryId(medicalHistoryId));
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVaccineById(int id)
    {
        var vaccine = await vaccineCommandService.Handle(new DeleteVaccineCommand(id));
        return Ok(vaccine);
    }
}