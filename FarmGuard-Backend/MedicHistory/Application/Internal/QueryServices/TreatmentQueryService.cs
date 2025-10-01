using FarmGuard_Backend.MedicHistory.Domain.Model.Aggregates;
using FarmGuard_Backend.MedicHistory.Domain.Model.Queries;
using FarmGuard_Backend.MedicHistory.Domain.Repositories;
using FarmGuard_Backend.MedicHistory.Domain.Services;

namespace FarmGuard_Backend.MedicHistory.Application.Internal.QueryServices;

public class TreatmentQueryService(ITreatmentRepository treatmentRepository) : ITreatmentQueryService
{

    public async Task<IEnumerable<Treatment>> HandleByMedicalHistoryId(GetTreatmentsByMedicalHistoryId query)
    {
        return await treatmentRepository.FindByMedicalHistoryId(query.MedicalHistoryId);
    }

    public async Task<Treatment?> HandleById(GetTreatmentsById query)
    {
        return await treatmentRepository.FindByIdAsync(query.Id);
    }
}

