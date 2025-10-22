using FarmGuard_Backend.MedicHistory.Domain.Model.Aggregates;
using FarmGuard_Backend.MedicHistory.Domain.Repositories;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Configuration;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FarmGuard_Backend.MedicHistory.Infrastructure.Persistence.EFC.Repositories;

public class DiseaseDiagnosisRepository(AppDbContext context) : BaseRepository<DiseaseDiagnosis>(context), IDiseaseDiagnosisRepository
{
    // Puedes agregar métodos específicos aquí si es necesario
    public async Task<IEnumerable<DiseaseDiagnosis>> FindByMedicalHistoryIdAsync(int medicalHistoryId)
    {

        return await Context.Set<DiseaseDiagnosis>()
            .Where(dd => dd.MedicalHistoryId == medicalHistoryId)
            .ToListAsync();

    }

    public async Task<IEnumerable<DiseaseDiagnosis>> FindByIdSectionAndDateAsync(int idSection, DateTime startDate, DateTime endDate)
    {
        return await Context.Set<DiseaseDiagnosis>()
            .Where(dd => dd.MedicalHistory.Animal.SectionId == idSection && dd.DiagnosedAt >= startDate &&  dd.DiagnosedAt <= endDate)
            .ToListAsync();
    }
}