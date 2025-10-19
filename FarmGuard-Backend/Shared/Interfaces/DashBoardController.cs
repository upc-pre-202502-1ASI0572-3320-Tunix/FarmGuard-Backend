using FarmGuard_Backend.Animals.Domain.Model.Queries;
using FarmGuard_Backend.Animals.Domain.Services;
using FarmGuard_Backend.MedicHistory.Domain.Model.Queries;
using FarmGuard_Backend.MedicHistory.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace FarmGuard_Backend.Shared.Interfaces;

[ApiController]
[Route("api/v1/dashBoard")]
public class DashBoardController(
    ITreatmentQueryService treatmentQueryService,
    IAnimalQueryService animalQueryService,
    IFoodQueryService foodQueryService,
    IVaccineQueryService vaccineQueryService,
    IDiseaseDiagnosisQueryService diagnosisQueryService):ControllerBase
{
    [HttpGet("animals/{idSection}")]
    public async Task<IActionResult> GetTotalAnimalNumber(int idSection, DateTime startDate,  DateTime endDate)
    {
        var getAllAnimalsQueryByIdInventory = new GetAllAnimalsByIdInventory( idSection);
        var animals = await animalQueryService.Handle(getAllAnimalsQueryByIdInventory);
        var totalAnimals = animals.Count();
        return Ok(new { TotalAnimals = totalAnimals });
    }

    [HttpGet("food/{idSection}")]
    public async Task<IActionResult> GetMeanFoodNumber(int idSection, DateTime startDate,  DateTime endDate)
    {
        return Ok();
    }


    [HttpGet("totalTreatments/{idSection}")]
    public async Task<IActionResult> GetTotalTreatmentsNumber(int idSection, DateTime startDate,  DateTime endDate)
    {
        var getTreatmentsByIdSectionQuery = new GetTreatmentsByIdSectionQuery(idSection);
        var treatments = await treatmentQueryService.Handle(getTreatmentsByIdSectionQuery);
        var totalTreatments = treatments.Count();
        return Ok(new { TotalTreatments = totalTreatments });
    }

    [HttpGet("totalVaccines/{idSection}")]
    public async Task<IActionResult> GetTotalVaccinesAnimalNumber(int idSection, DateTime startDate,  DateTime endDate)
    {
        var getVaccinesByIdSectionQuery = new GetAllVaccinesByIdSectionQuery(idSection);
        var vaccines = await vaccineQueryService.Handle(getVaccinesByIdSectionQuery);
        var totalVaccines = vaccines.Count();
        return Ok(new { TotalVaccines = totalVaccines });
    }
    
    [HttpGet("diagnosisAnimal/{idSection}")]
    public async Task<IActionResult> GetTotalDiagnosisAnimalNumber(int idSection, DateTime startDate, DateTime endDate)
    {
        return Ok();
    }
}