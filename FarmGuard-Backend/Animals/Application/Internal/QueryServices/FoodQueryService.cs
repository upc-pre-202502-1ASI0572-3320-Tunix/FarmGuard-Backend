using FarmGuard_Backend.Animals.Domain.Model.Aggregates;
using FarmGuard_Backend.Animals.Domain.Model.Entity;
using FarmGuard_Backend.Animals.Domain.Model.Queries;
using FarmGuard_Backend.Animals.Domain.Repositories;
using FarmGuard_Backend.Animals.Domain.Services;
using FarmGuard_Backend.Shared.Domain.Repositories;

namespace FarmGuard_Backend.Animals.Application.Internal.QueryServices;

public class FoodQueryService(IFoodDiaryRepository diaryRepository,IFoodEntryRepository foodEntryRepository,IUnitOfWork unitOfWork): IFoodQueryService
{
    public async Task<IEnumerable<FoodEntry>> Handle(GetAllFoodEntryByIdFoodDiary query)
    {
        return await foodEntryRepository.GetAllByFoodDiaryId(query.IdFoodDiary);
    }

    public async Task<FoodEntry?> Handle(GetFoodEntryByIdQuery query)
    {
        return await foodEntryRepository.FindByIdAsync(query.id);
    }

    public async Task<FoodEntry?> Handle(GetFoodEntryByIdFoodDiaryQuery query)
    {
        return await foodEntryRepository.GetByFoodDiaryId(query.idFoodEntry);
    }

    public async Task<FoodDiary?> Handle(GetFoodDiaryByIdAnimalAndDateQuery query)
    {
        return await diaryRepository.GetByIDAnimalAndDate(query.idAnimal, query.date);
    }

    public async Task<FoodDiary?> Handle(GetFoodDiaryByIdAnimalQuery query)
    {
        return await diaryRepository.GetByIDAnimal(query.idAnimal);
    }

    public async Task<FoodDiary?> Handle(GetFoodDiaryByIdQuery query)
    {
        return await diaryRepository.FindByIdAsync(query.id);
    }

    public async Task<FoodDiary?> Handle(GetFoodDiaryBySerialNumberdAnimalQuery query)
    {
        return await diaryRepository.GetBySerialNumberAnimal(query.SerialNumber);
    }
}