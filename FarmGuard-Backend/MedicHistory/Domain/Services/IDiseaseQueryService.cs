using FarmGuard_Backend.MedicHistory.Domain.Model.Entities;
using FarmGuard_Backend.MedicHistory.Domain.Model.Queries;

namespace FarmGuard_Backend.MedicHistory.Domain.Services;

public interface IDiseaseQueryService
{
    Task<IEnumerable<Disease>> HandleByDiseaseDiagnosisId(GetDiseaseByDiseaseDiagnosisId query);
    Task<Disease?> HandleById(GetDiseaseById query);
}
