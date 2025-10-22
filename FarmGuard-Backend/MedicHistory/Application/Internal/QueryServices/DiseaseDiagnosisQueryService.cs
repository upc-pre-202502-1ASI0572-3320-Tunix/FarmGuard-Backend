using FarmGuard_Backend.MedicHistory.Domain.Model.Aggregates;
using FarmGuard_Backend.MedicHistory.Domain.Model.Queries;
using FarmGuard_Backend.MedicHistory.Domain.Repositories;
using FarmGuard_Backend.MedicHistory.Domain.Services;

namespace FarmGuard_Backend.MedicHistory.Application.Internal.QueryServices;

public class DiseaseDiagnosisQueryService(IDiseaseDiagnosisRepository repository) : IDiseaseDiagnosisQueryService
{
    public async Task<IEnumerable<DiseaseDiagnosis>> HandleByMedicalHistoryId(GetDiseaseDiagnosisByMedicalHistoryId query)
    {
        // Suponiendo que el repositorio tiene un método para esto
        return await repository.FindByMedicalHistoryIdAsync(query.MedicalHistoryId);
    }

    public async Task<DiseaseDiagnosis?> HandleById(GetDiseaseDiagnosisById query)
    {
        return await repository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<DiseaseDiagnosis>> Handle(GetDiagnosesBySectionAndDateQuery query)
    {
        return await repository.FindByIdSectionAndDateAsync(query.idSection, query.startDate, query.endDate);
    }
}