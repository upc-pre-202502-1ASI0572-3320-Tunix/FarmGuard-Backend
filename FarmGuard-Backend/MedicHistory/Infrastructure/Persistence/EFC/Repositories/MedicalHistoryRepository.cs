using FarmGuard_Backend.MedicHistory.Domain.Model.Aggregates;
using FarmGuard_Backend.MedicHistory.Domain.Repositories;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Configuration;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FarmGuard_Backend.MedicHistory.Infrastructure.Persistence.EFC.Repositories;

public class MedicalHistoryRepository(AppDbContext context) : BaseRepository<MedicalHistory>(context), IMedicalHistoryRepository
{
    public async Task<MedicalHistory?> FindByAnimalIdAsync(int animalId)
    {
        return await Context.Set<MedicalHistory>()
            .FirstOrDefaultAsync(mh => mh.AnimalId == animalId);
    }
}
