using FarmGuard_Backend.MedicHistory.Domain.Model.Aggregates;
using FarmGuard_Backend.Shared.Domain.Repositories;

namespace FarmGuard_Backend.MedicHistory.Domain.Repositories;

public interface IMedicalHistoryRepository : IBaseRepository<MedicalHistory>
{
    public  Task<MedicalHistory?> FindByAnimalIdAsync(int animalId);
}

