using FarmGuard_Backend.MedicHistory.Domain.Model.Entities;
using FarmGuard_Backend.MedicHistory.Domain.Repositories;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Configuration;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Configuration.Extensions;
using FarmGuard_Backend.Shared.Infrastructure.Persistance.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FarmGuard_Backend.MedicHistory.Infrastructure.Persistence.EFC.Repositories;

public class VaccineRepository(AppDbContext context) : BaseRepository<Vaccine>(context), IVaccineRepository
{
   public async Task<IEnumerable<Vaccine>> FindByMedicalHistoryIdAsync(int medicalHistoryId)
   {
      return await Context.Set<Vaccine>()
          .Where(v => v.MedicalHistoryId == medicalHistoryId)
          .ToListAsync();
   }

   public async Task<IEnumerable<Vaccine>> FindBySectionIdAsync(int idSection)
   {
       return await Context.Set<Vaccine>()
           .Where(v=> v.MedicalHistory.Animal.SectionId == idSection)
           .ToListAsync();
   }
}