using FarmGuard_Backend.MedicHistory.Domain.Model.Aggregates;
using FarmGuard_Backend.Shared.Domain.Repositories;

namespace FarmGuard_Backend.MedicHistory.Domain.Repositories;

public interface IDiseaseDiagnosisRepository : IBaseRepository<DiseaseDiagnosis>
{
    public Task<IEnumerable<DiseaseDiagnosis>> FindByMedicalHistoryIdAsync(int medicalHistoryId);
    
    public Task<IEnumerable<DiseaseDiagnosis>> FindByIdSectionAndDateAsync(int idSection, DateTime startDate, DateTime endDate);
}