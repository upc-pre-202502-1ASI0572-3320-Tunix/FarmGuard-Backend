using FarmGuard_Backend.Animals.Domain.Model.Queries;
using FarmGuard_Backend.Animals.Domain.Services;
using FarmGuard_Backend.MedicHistory.Domain.Model.Queries;
using FarmGuard_Backend.MedicHistory.Domain.Services;
using FarmGuard_Backend.Shared.Interfaces.Resource;
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
    public async Task<IActionResult> GetTotalAnimalNumber(int idSection)
    {
        var getAllAnimalsQueryByIdInventory = new GetAllAnimalsByIdInventory( idSection);
        var animals = await animalQueryService.Handle(getAllAnimalsQueryByIdInventory);
        var totalAnimals = animals.Count();
        return Ok(new { TotalAnimals = totalAnimals });
    }

    [HttpPost("food/{idSection}")]
    public async Task<IActionResult> GetMeanFoodNumber([FromBody] DateTimeResource resource,int idSection )
    {
        var getFoodQuery = new GetFoodEntryBySectionAndDateQuery(idSection, resource.startDate,resource.endDate);
        var foodRecords = await foodQueryService.Handle(getFoodQuery); // Asumo que devuelve IEnumerable<FoodRecord>

        if (foodRecords == null || !foodRecords.Any())
        {
            return Ok(new { AverageFood = 0 });
        }

        // Asumo que cada 'foodRecord' tiene una propiedad 'QuantityInKg'
        var averageFood = foodRecords.Average(f => f.Quantity); 
        return Ok(new { AverageFood = Math.Round(averageFood, 2) });
    }


    [HttpPost("totalTreatments/{idSection}")]
    public async Task<IActionResult> GetTotalTreatmentsNumber([FromBody] DateTimeResource resource,int idSection )
    {
        var getTreatmentsQuery = new GetTreatmentsBySectionAndDateQuery(idSection, resource.startDate, resource.endDate);
        var treatments = await treatmentQueryService.Handle(getTreatmentsQuery); 

        if (treatments == null || !treatments.Any())
        {
            return Ok(new { Pending = 0, Finalized = 0 });
        }

        // Asumo que el modelo 'Treatment' tiene una propiedad 'Status' (ej: "Pending", "Finalized")
        var pendingTreatments = treatments.Count(t => t.Status == false);
        var finalizedTreatments = treatments.Count(t => t.Status == true);

        return Ok(new { Pending = pendingTreatments, Finalized = finalizedTreatments });
    }

    [HttpPost("totalVaccines/{idSection}")]
    public async Task<IActionResult> GetTotalVaccinesAnimalNumber([FromBody] DateTimeResource resource,int idSection)
    {
        var getAllAnimalsQuery = new GetAllAnimalsByIdInventory(idSection);
        var animals = await animalQueryService.Handle(getAllAnimalsQuery); // Asumo que devuelve IEnumerable<Animal>

        if (animals == null || !animals.Any())
        {
            return Ok(new { VaccinatedCount = 0, NotVaccinatedCount = 0 });
        }

        // 2. Aplicamos tu lógica de negocio
        // "la forma de saber si un animal esta vacunado es al tener alguna vacuna"
    
        // Asumimos que la estructura es: Animal -> MedicalHistory -> ICollection<Vaccine> Vaccines
        int vaccinatedCount = animals.Count(a => 
                a.medicalHistory != null && 
                a.medicalHistory.Vaccines != null && 
                a.medicalHistory.Vaccines.Any() // .Any() es true si hay 1 o más vacunas
        );

        int totalAnimals = animals.Count();
        int notVaccinatedCount = totalAnimals - vaccinatedCount; // El resto no tiene vacunas

        // 3. Devolvemos los CONTEOS. El frontend calculará los porcentajes.
        return Ok(new 
        { 
            VaccinatedCount = vaccinatedCount, 
            NotVaccinatedCount = notVaccinatedCount
        });
    }
    
    [HttpPost("diagnosisAnimal/{idSection}")]
    public async Task<IActionResult> GetTotalDiagnosisAnimalNumber([FromBody] DateTimeResource resource,int idSection)
    {
        // Asumo una query que filtra diagnósticos por sección y rango de fechas
        var getDiagnosisQuery = new GetDiagnosesBySectionAndDateQuery(idSection, resource.startDate, resource.endDate);
        var diagnoses = await diagnosisQueryService.Handle(getDiagnosisQuery); // Asumo IEnumerable<Diagnosis>

        if (diagnoses == null || !diagnoses.Any())
        {
            return Ok(new { Leve = 0, Moderado = 0, Grave = 0 });
        }

        var summary = diagnoses
            .GroupBy(d => d.Severity.ToString()) // <--- ÚNICO CAMBIO AQUÍ
            .ToDictionary(g => g.Key, g => g.Count());

        // El resto de tu código ahora funciona perfectamente
        var result = new {
            Leve = summary.GetValueOrDefault("Leve", 0),
            Moderado = summary.GetValueOrDefault("Moderado", 0),
            Grave = summary.GetValueOrDefault("Grave", 0)
        };

        return Ok(result);
    }
}