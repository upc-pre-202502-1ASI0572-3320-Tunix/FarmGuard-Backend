using FarmGuard_Backend.Animals.Domain.Model.Aggregates;
using FarmGuard_Backend.Animals.Domain.Model.Commands;
using FarmGuard_Backend.Animals.Domain.Model.Entity;
using FarmGuard_Backend.Animals.Domain.Model.Queries;

namespace FarmGuard_Backend.Animals.Domain.Services;

public interface IFoodQueryService
{
    Task<IEnumerable<FoodEntry>> Handle(GetAllFoodEntryByIdFoodDiary diary);
    Task<FoodEntry?> Handle(GetFoodEntryByIdQuery query);
    Task<FoodEntry?> Handle(GetFoodEntryByIdFoodDiaryQuery query);

    Task<FoodDiary?> Handle(GetFoodDiaryByIdAnimalAndDateQuery query);
    Task<FoodDiary?> Handle(GetFoodDiaryByIdAnimalQuery query);
    Task<FoodDiary?> Handle(GetFoodDiaryByIdQuery query);
    Task<FoodDiary?> Handle(GetFoodDiaryBySerialNumberdAnimalQuery query);
    
    Task<IEnumerable<FoodEntry>>Handle(GetFoodEntryBySectionAndDateQuery query);
    
    
}