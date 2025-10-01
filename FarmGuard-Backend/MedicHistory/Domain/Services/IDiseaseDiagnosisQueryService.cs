using FarmGuard_Backend.MedicHistory.Domain.Model.Aggregates;
using FarmGuard_Backend.MedicHistory.Domain.Model.Queries;

namespace FarmGuard_Backend.MedicHistory.Domain.Services;

public interface IDiseaseDiagnosisQueryService
{
    Task<IEnumerable<DiseaseDiagnosis>> HandleByMedicalHistoryId(GetDiseaseDiagnosisByMedicalHistoryId query);
    Task<DiseaseDiagnosis?> HandleById(GetDiseaseDiagnosisById query);
}

