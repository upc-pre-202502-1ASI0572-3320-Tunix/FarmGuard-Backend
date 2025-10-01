using FarmGuard_Backend.MedicHistory.Domain.Model.Aggregates;
using FarmGuard_Backend.MedicHistory.Domain.Model.Entities;
using FarmGuard_Backend.Shared.Domain.Repositories;

namespace FarmGuard_Backend.MedicHistory.Domain.Repositories;

public interface IMedicationRepository : IBaseRepository<Medication>
{
    Task<IEnumerable<Medication>> FindByTreatmentId(int treatmentId);
}

