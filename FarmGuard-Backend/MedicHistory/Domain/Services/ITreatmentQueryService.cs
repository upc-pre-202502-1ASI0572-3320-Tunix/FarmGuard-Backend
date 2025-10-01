using FarmGuard_Backend.MedicHistory.Domain.Model.Aggregates;
using FarmGuard_Backend.MedicHistory.Domain.Model.Queries;

namespace FarmGuard_Backend.MedicHistory.Domain.Services;

public interface ITreatmentQueryService
{
    
    Task<IEnumerable<Treatment>> HandleByMedicalHistoryId(GetTreatmentsByMedicalHistoryId query);
    Task <Treatment?> HandleById(GetTreatmentsById query);
}
