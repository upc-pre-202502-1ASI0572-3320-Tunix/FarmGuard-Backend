using FarmGuard_Backend.Animals.Domain.Model.Aggregates;
using FarmGuard_Backend.Animals.Domain.Model.Commands;
using FarmGuard_Backend.Animals.Domain.Model.Entity;
using FarmGuard_Backend.Animals.Domain.Model.Queries;
using FarmGuard_Backend.Animals.Domain.Repositories;
using FarmGuard_Backend.Animals.Domain.Services;
using FarmGuard_Backend.Shared.Domain.Repositories;

namespace FarmGuard_Backend.Animals.Application.Internal.ComandServices;

public class FoodCommandService(IFoodDiaryRepository diaryRepository,IFoodEntryRepository foodEntryRepository,IUnitOfWork unitOfWork): IFoodCommandService
{
    public Task<FoodDiary?> Handle(CreateFoodDiaryCommand command)
    {
        /*Los diarios se crean al crear un animal*/
        throw new NotImplementedException();
    }

    public Task<FoodDiary?> Handle(DeleteFoodDiaryByIdCommand command)
    {
        /*Un diario no se puede eliminar*/
        throw new NotImplementedException();
    }

    public Task<FoodDiary?> Handle(PutFoodDiaryByIdCommand command)
    {
        /*Posible actualizacion*/
        throw new NotImplementedException();
    }

    public async Task<FoodEntry?> Handle(CreateFoodEntryCommand command)
    {
        var foodDiary = await diaryRepository.FindByIdAsync(command.foodDiaryId);
        if (foodDiary is null) throw new Exception("Food diary not found");
        
        var foodEntry = new FoodEntry(command.name,command.quantity,command.time,command.notes, foodDiary);
        
        await foodEntryRepository.AddAsync(foodEntry);
        await unitOfWork.CompleteAsync();
        return foodEntry;
    }

    public async Task<FoodEntry?> Handle(DeleteFoodEntryByIdCommand command)
    {
        var foodEntry = await foodEntryRepository.FindByIdAsync(command.id);
        if (foodEntry is null) throw new Exception("Food entry not found");
        
        foodEntryRepository.Remove(foodEntry);
        await unitOfWork.CompleteAsync();
        return foodEntry;
    }

    public async Task<FoodEntry?> Handle(PutFoodEntryByIdCommand command)
    {
        var foodEntry = await foodEntryRepository.FindByIdAsync(command.id);
        if (foodEntry is null) throw new Exception("Food entry not found");
        
        foodEntry.UpdateName(command.name);
        foodEntry.UpdateQuantity(command.quantity);
        foodEntry.UpdateTime(command.time);
        foodEntry.UpdateNotes(command.notes);
        
        foodEntryRepository.Update(foodEntry);
        await unitOfWork.CompleteAsync();
        
        return foodEntry;
        
    }
}