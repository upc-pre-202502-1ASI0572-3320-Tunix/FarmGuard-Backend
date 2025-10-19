using FarmGuard_Backend.Animals.Domain.Model.Commands;
using FarmGuard_Backend.Animals.Domain.Model.Entity;
using FarmGuard_Backend.Animals.Domain.Model.Queries;
using FarmGuard_Backend.Animals.Domain.Services;
using FarmGuard_Backend.Animals.Interfaces.Rest.resources;
using FarmGuard_Backend.Animals.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;

namespace FarmGuard_Backend.Animals.Interfaces.Rest;


[ApiController]
[Route("api/v1/foods")]
public class FoodController(IFoodCommandService foodCommandService,IFoodQueryService foodQueryService):ControllerBase
{
    [HttpPost("entry/{idFoodDiary}")]
    public async Task<IActionResult> CreateFoodEntry(int idFoodDiary, [FromBody]CreateFoodEntryResource resource)
    {
        var createFoodEntryCommand = new CreateFoodEntryCommand(
            resource.Name,
            resource.Quantity,
            resource.Time,
            resource.Notes,
            idFoodDiary);
        var foodEntry = await foodCommandService.Handle(createFoodEntryCommand);
        if (foodEntry == null) return BadRequest();
        
        var foodEntryResource = FoodEntryResourceFromEntityAssembler.ToResourceFromEntity(foodEntry);
        return Ok(foodEntryResource);
        
      
    }

    [HttpDelete("entry/{id}")]
    public async Task<IActionResult> DeleteFoodEntry(int id)
    {
        var foodEntry = await foodCommandService.Handle(new DeleteFoodEntryByIdCommand(id));
        return Ok(foodEntry);
    }

    [HttpPut("entry/{id}")]
    public async Task<IActionResult> UpdateFoodEntry(int id,[FromBody] CreateFoodEntryResource resource)
    {
        var updateFoodEntryCommand = new PutFoodEntryByIdCommand(
            id,
            resource.Name,
            resource.Quantity,
            resource.Time,
            resource.Notes);
        
        var foodEntry = await foodCommandService.Handle(updateFoodEntryCommand);
        if (foodEntry == null) return BadRequest();
        return Ok(foodEntry);
    }
    
    [HttpGet("entry/{id}")]
    public async Task<IActionResult> GetFoodEntryById(int id)
    {
        var getFoodEntry = new GetFoodEntryByIdQuery(id);
        var foodEntry = await foodQueryService.Handle(getFoodEntry);
        if (foodEntry == null) return NotFound();
        return Ok(foodEntry);
    }
    
    [HttpGet("entry/all/{idFoodDiary}")]
    public async Task<IActionResult> GetAllFoodEntryByIdFoodDiary(int idFoodDiary)
    {
        var getAllFoodEntry = new GetAllFoodEntryByIdFoodDiary(idFoodDiary);
        var foodEntries = await foodQueryService.Handle(getAllFoodEntry);
        var resources = foodEntries.Select(FoodEntryResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    /*Food Diary*/
    
    [HttpGet("diary/animal/tag/{serialNumber}")]
    public async Task<IActionResult> GetFoodDiaryBySerialNumber(string serialNumber)
    {
        var getFoodDiaryBySerialNumber = new GetFoodDiaryBySerialNumberdAnimalQuery(serialNumber);
        var foodDiary = await foodQueryService.Handle(getFoodDiaryBySerialNumber);
        if (foodDiary == null) return NotFound();
        return Ok(foodDiary);
    }
    
    [HttpGet("diary/animal/{id}")]
    public async Task<IActionResult> GetFoodDiaryByIdAnimal(int id)
    {
        var getFoodDiaryByIdAnimal = new GetFoodDiaryByIdAnimalQuery(id);
        var foodDiary = await foodQueryService.Handle(getFoodDiaryByIdAnimal);
        if (foodDiary == null) return NotFound();
        return Ok(foodDiary);
    }
    
    [HttpGet("diary/{id}")]
    public async Task<IActionResult>GetFoodDiaryById(int id)
    {
        var getFoodDiaryById = new GetFoodDiaryByIdQuery(id);
        var foodDiary = await foodQueryService.Handle(getFoodDiaryById);
        if (foodDiary == null) return NotFound();
        return Ok(foodDiary);
    }





}