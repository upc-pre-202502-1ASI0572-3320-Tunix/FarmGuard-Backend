using FarmGuard_Backend.Animals.Domain.Model.Aggregates;
using FarmGuard_Backend.Shared.Domain.Repositories;

namespace FarmGuard_Backend.Animals.Domain.Repositories;

public interface IFoodDiaryRepository:IBaseRepository<FoodDiary>
{
    Task<FoodDiary> GetByIDAnimal(int id);
    Task<FoodDiary?> GetByIDAnimalAndDate(int id, DateTime date);
    Task<FoodDiary?> GetBySerialNumberAnimal(string SerialNumber);
}