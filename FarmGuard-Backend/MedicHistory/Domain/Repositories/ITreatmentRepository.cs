using FarmGuard_Backend.MedicHistory.Domain.Model.Aggregates;
using FarmGuard_Backend.Shared.Domain.Repositories;

namespace FarmGuard_Backend.MedicHistory.Domain.Repositories;

public interface ITreatmentRepository : IBaseRepository<Treatment>
{
    Task<IEnumerable<Treatment>> FindByMedicalHistoryId(int medicalHistoryId);
}


