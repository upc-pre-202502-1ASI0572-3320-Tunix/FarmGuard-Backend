using FarmGuard_Backend.MedicHistory.Domain.Model.Aggregates;
using FarmGuard_Backend.Shared.Domain.Repositories;

namespace FarmGuard_Backend.MedicHistory.Domain.Repositories;

public interface ITreatmentRepository : IBaseRepository<Treatment>
{
    Task<IEnumerable<Treatment>> FindByMedicalHistoryId(int medicalHistoryId);
    
    Task<IEnumerable<Treatment>> FindByIdSection(int idSection);
    
    Task<IEnumerable<Treatment>> FindBySectionAndDate(int idSection, DateTime startDate, DateTime endDate);
}


