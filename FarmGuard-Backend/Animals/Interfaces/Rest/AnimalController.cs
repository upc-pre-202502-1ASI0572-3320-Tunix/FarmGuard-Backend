using FarmGuard_Backend.Animals.Domain.Model.Commands;
using FarmGuard_Backend.Animals.Domain.Model.Queries;
using FarmGuard_Backend.Animals.Domain.Services;
using FarmGuard_Backend.Animals.Interfaces.Rest.resources;
using FarmGuard_Backend.Animals.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;

namespace FarmGuard_Backend.Animals.Interfaces.Rest;

[ApiController]
[Route("api/v1/animals")]
public class AnimalController(
    IAnimalCommandService animalCommandService, 
    IAnimalQueryService animalQueryService,
    ILogger<AnimalController> logger):ControllerBase
{
    [HttpPost("{idInventory}")]
    [RequestFormLimits(MultipartBodyLengthLimit = 5_000_000)]
    public async Task<IActionResult> CreateAnimal([FromForm] CreateAnimalResource resource, int idInventory)
    {
        try
        {
            logger.LogInformation("=== CREATE ANIMAL REQUEST ===");
            logger.LogInformation("IdInventory: {IdInventory}", idInventory);
            logger.LogInformation("Name: {Name}", resource.Name);
            logger.LogInformation("Specie: {Specie}", resource.Specie);
            logger.LogInformation("UrlIot: {UrlIot}", resource.UrlIot);
            logger.LogInformation("Location: {Location}", resource.Location);
            logger.LogInformation("HearRate: {HearRate}", resource.HearRate);
            logger.LogInformation("Temperature: {Temperature}", resource.Temperature);
            logger.LogInformation("Sex: {Sex}", resource.Sex);
            logger.LogInformation("BirthDate: {BirthDate}", resource.BirthDate);
            logger.LogInformation("File: {HasFile}", resource.File != null ? "Yes" : "No");
            
            var createAnimalCommand = CreateAnimalCommandFromResourceAssembler.ToCommandFromResource(resource, idInventory);
            var animal = await animalCommandService.Handle(createAnimalCommand);
            
            if (animal == null)
            {
                logger.LogWarning("Animal creation returned null");
                return BadRequest(new { message = "Failed to create animal" });
            }

            var resourceResult = AnimalResourceFromEntityAssembler.ToResourceFromEntity(animal);
            logger.LogInformation("Animal created successfully with ID: {AnimalId}", animal.Id);
            return Ok(resourceResult);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error creating animal: {Message}", e.Message);
            logger.LogError("Stack trace: {StackTrace}", e.StackTrace);
            return BadRequest(new { message = "An error has occurred: " + e.Message, stackTrace = e.StackTrace });
        }
    }

    [HttpGet("{serialNumberId}")]
    public async Task<IActionResult> GetAnimalByIdAnimal(string serialNumberId)
    {
        var animal = await animalQueryService.Handle(new GetAnimalBySerialNumberId(serialNumberId));
        if(animal == null) return NotFound();
        var resource = AnimalResourceFromEntityAssembler.ToResourceFromEntity(animal);
        return Ok(resource);
    }

    [HttpPut("{idSerialAnimal}")]
    [RequestFormLimits(MultipartBodyLengthLimit = 5_000_000)]
    public async Task<IActionResult> PutAnimalById(string idSerialAnimal,[FromForm] UpdateAnimalResource resource)
    {
        var updateAnimalCommand = new PutAnimalCommand(
            resource.Name,
            idSerialAnimal,
            resource.Specie.ToString(),
            resource.UrlIot,
            resource.file,
            resource.Location,
            resource.HearRate,
            resource.Temperature);
        var animal = await animalCommandService.Handle(updateAnimalCommand);
        
        return Ok(animal);
    }

    [HttpDelete("{idAnimal}")]
    public async Task<IActionResult> DeleteAnimalByAnimalSerialId(string idAnimal)
    {
        var animal = await animalCommandService.Handle(new DeleteAnimalByIdAnimalCommand(idAnimal));
        return Ok(animal);
    }

    [HttpGet("inventory/{idInventory}")]
    public async Task<IActionResult> GetAllAnimalsByInventory(int idInventory)
    {
        var animals = await animalQueryService.Handle(new GetAllAnimalsByIdInventory(idInventory));
        var resource = animals.Select(AnimalResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resource);
        /*
        var vaccines = await vaccineQueryService.Handle(new GetVaccinesByIdAnimal(serialAnimalId));
        var resources = vaccines.Select(VaccineResourceFromEntityAssembler.ToEntityFromResource);
        return Ok(resources);*/
    }

    [HttpGet("id/{idAnimal}")]
    public async Task<IActionResult> GetAnimalById(int idAnimal)
    {
        var animal = await animalQueryService.Handle(new GetAnimalByIdQuery(idAnimal));
        if(animal == null) return NotFound();
        var resource = AnimalResourceFromEntityAssembler.ToResourceFromEntity(animal);
        return Ok(resource);
    }

}
