using FarmGuard_Backend.Animals.Domain.Model.Aggregates;
using FarmGuard_Backend.Animals.Domain.Model.Commands;
using FarmGuard_Backend.Animals.Domain.Model.Entity;

namespace FarmGuard_Backend.Animals.Domain.Services;

public interface IFoodCommandService
{
    Task<FoodDiary?> Handle(CreateFoodDiaryCommand command);
    Task<FoodDiary?> Handle(DeleteFoodDiaryByIdCommand command);
    Task<FoodDiary?> Handle(PutFoodDiaryByIdCommand command);
    
    Task<FoodEntry?> Handle(CreateFoodEntryCommand command);
    Task<FoodEntry?> Handle(DeleteFoodEntryByIdCommand command);
    Task<FoodEntry?> Handle(PutFoodEntryByIdCommand command);
}