using FarmGuard_Backend.MedicHistory.Domain.Model.Aggregates;
using FarmGuard_Backend.MedicHistory.Domain.Model.Entities;
using FarmGuard_Backend.MedicHistory.Domain.Repositories;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Configuration;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FarmGuard_Backend.MedicHistory.Infrastructure.Persistence.EFC.Repositories;

public class DiseaseRepository(AppDbContext context) : BaseRepository<Disease>(context), IDiseaseRepository
{
    public async Task<IEnumerable<Disease>> FindByDiseaseDiagnosisIdAsync(int diseaseDiagnosisId)
    {
        return await Context.Set<Disease>()
            .Where(d => d.DiseaseDiagnosisId == diseaseDiagnosisId)
            .ToListAsync();
    }
}

