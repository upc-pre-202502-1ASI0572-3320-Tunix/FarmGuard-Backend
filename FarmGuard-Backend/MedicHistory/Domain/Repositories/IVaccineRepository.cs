using FarmGuard_Backend.MedicHistory.Domain.Model.Entities;
using FarmGuard_Backend.Shared.Domain.Repositories;

namespace FarmGuard_Backend.MedicHistory.Domain.Repositories;

public interface IVaccineRepository:IBaseRepository<Vaccine>
{
    Task<IEnumerable<Vaccine>> FindByMedicalHistoryIdAsync(int medicalHistoryId);
    Task<IEnumerable<Vaccine>> FindBySectionIdAsync(int idSection);
    Task<IEnumerable<Vaccine>> FindByIdSectionAndDateAsync(int idDiagnosisId, DateTime startDate, DateTime endDate);
}