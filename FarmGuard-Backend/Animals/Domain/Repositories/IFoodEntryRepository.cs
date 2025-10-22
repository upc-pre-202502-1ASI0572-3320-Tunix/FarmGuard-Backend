using FarmGuard_Backend.Animals.Domain.Model.Entity;
using FarmGuard_Backend.Shared.Domain.Repositories;

namespace FarmGuard_Backend.Animals.Domain.Repositories;

public interface IFoodEntryRepository:IBaseRepository<FoodEntry>
{
    Task<IEnumerable<FoodEntry>> GetAllByFoodDiaryId(int foodDiaryId);
    Task<FoodEntry> GetByFoodDiaryId(int foodDiaryId);
    
    Task<IEnumerable<FoodEntry>> GetBySectionIdAndDate( int idSection, DateTime startDate, DateTime endDate);
}