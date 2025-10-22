using FarmGuard_Backend.MedicHistory.Domain.Model.Entities;
using FarmGuard_Backend.MedicHistory.Domain.Repositories;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Configuration;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FarmGuard_Backend.MedicHistory.Infrastructure.Persistence.EFC.Repositories;

public class MedicationRepository(AppDbContext context) : BaseRepository<Medication>(context), IMedicationRepository
{
    public async Task<IEnumerable<Medication>> FindByTreatmentId(int treatmentId)
    {
        return await Context.Set<Medication>()
            .Where(m => m.TreatmentId == treatmentId)
            .ToListAsync();
    }
}


