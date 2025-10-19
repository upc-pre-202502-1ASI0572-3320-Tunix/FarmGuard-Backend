using FarmGuard_Backend.Animals.Domain.Model.Aggregates;
using FarmGuard_Backend.Animals.Domain.Model.Entity;
using FarmGuard_Backend.Animals.Domain.Repositories;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Configuration;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FarmGuard_Backend.Animals.Infrastructure.Persistence.EFC.Repositories;

public class FoodEntryRepository(AppDbContext context):BaseRepository<FoodEntry>(context),IFoodEntryRepository
{
    public async Task<IEnumerable<FoodEntry>> GetAllByFoodDiaryId(int foodDiaryId)
    {
        return await Context.Set<FoodEntry>().
            Where(fe => fe.FoodDiaryId == foodDiaryId)
            .ToListAsync(); 
    }

    public async Task<FoodEntry?> GetByFoodDiaryId(int foodDiaryId)
    {
        return await Context.Set<FoodEntry>()
            .FirstOrDefaultAsync(fe => fe.FoodDiaryId == foodDiaryId);
    }
}