using FarmGuard_Backend.MedicHistory.Domain.Model.Entities;
using FarmGuard_Backend.MedicHistory.Domain.Model.Queries;

namespace FarmGuard_Backend.MedicHistory.Domain.Services;

public interface IMedicationQueryService
{
    
    Task<IEnumerable<Medication>> HandleByTreatmentId(GetMedicationsByTreatmentId query);
    Task<Medication?> HandleById(GetMedicationById query);
}
