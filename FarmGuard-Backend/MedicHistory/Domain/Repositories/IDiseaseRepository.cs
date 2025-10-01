using FarmGuard_Backend.MedicHistory.Domain.Model.Entities;
using FarmGuard_Backend.Shared.Domain.Repositories;

namespace FarmGuard_Backend.MedicHistory.Domain.Repositories;

public interface IDiseaseRepository : IBaseRepository<Disease>
{
    Task<IEnumerable<Disease>> FindByDiseaseDiagnosisIdAsync(int diseaseDiagnosisId);
}

