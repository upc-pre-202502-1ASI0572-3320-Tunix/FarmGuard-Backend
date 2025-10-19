using FarmGuard_Backend.Animals.Domain.Model.Aggregates;
using FarmGuard_Backend.Animals.Domain.Repositories;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Configuration;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FarmGuard_Backend.Animals.Infrastructure.Persistence.EFC.Repositories;

public class FoodDiaryRepository(AppDbContext context):BaseRepository<FoodDiary>(context),IFoodDiaryRepository 
{
    public async Task<FoodDiary?> GetByIDAnimal(int id)
    {
        
        return await Context.Set<FoodDiary>().
            Where(fd => fd.AnimalId == id)
            .FirstOrDefaultAsync();
    }

    public async Task<FoodDiary?> GetByIDAnimalAndDate(int id, DateTime date)
    {
        return await Context.Set<FoodDiary>().
            Where(fd => fd.AnimalId == id && fd.Date == date)
            .FirstOrDefaultAsync();
    }

    public async Task<FoodDiary?> GetBySerialNumberAnimal(string SerialNumber)
    {
        return await Context.Set<FoodDiary>().
            Where(fd => fd.Animal.SerialNumber.Number == SerialNumber)
            .FirstOrDefaultAsync();
    }
}