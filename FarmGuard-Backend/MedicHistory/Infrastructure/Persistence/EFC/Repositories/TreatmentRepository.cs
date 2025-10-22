using FarmGuard_Backend.MedicHistory.Domain.Model.Aggregates;
using FarmGuard_Backend.MedicHistory.Domain.Repositories;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Configuration;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FarmGuard_Backend.MedicHistory.Infrastructure.Persistence.EFC.Repositories;

public class TreatmentRepository(AppDbContext context) : BaseRepository<Treatment>(context), ITreatmentRepository
{
    // Puedes agregar métodos específicos aquí si es necesario
    public async Task<IEnumerable<Treatment>> FindByMedicalHistoryId(int medicalHistoryId)
    {
        return await Context.Set<Treatment>()
            .Where(t => t.MedicalHistoryId == medicalHistoryId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Treatment>> FindByIdSection(int idSection)
    {
        return await Context.Set<Treatment>()
            .Where(t => t.MedicalHistory.Animal.SectionId == idSection)
            .ToListAsync();
    }

    public async Task<IEnumerable<Treatment>> FindBySectionAndDate(int idSection, DateTime startDate, DateTime endDate)
    {
        return await Context.Set<Treatment>()
            .Where(t => t.MedicalHistory.Animal.SectionId == idSection && t.StartDate >= startDate && t.StartDate <= endDate)
            .ToListAsync();
    }
}

