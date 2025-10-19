using FarmGuard_Backend.Animals.Domain.Model.Queries;
using FarmGuard_Backend.MedicHistory.Domain.Model.Aggregates;
using FarmGuard_Backend.MedicHistory.Domain.Model.Queries;

namespace FarmGuard_Backend.MedicHistory.Domain.Services;

public interface ITreatmentQueryService
{
    
    Task<IEnumerable<Treatment>> Handle(GetTreatmentsByMedicalHistoryId query);
    Task <Treatment?> Handle(GetTreatmentsById query);

    Task<IEnumerable<Treatment>> Handle(GetTreatmentsByIdSectionQuery query);
    
    Task<IEnumerable<Treatment>> Handle(GetTreatmentsBySectionAndDateQuery query);
}
