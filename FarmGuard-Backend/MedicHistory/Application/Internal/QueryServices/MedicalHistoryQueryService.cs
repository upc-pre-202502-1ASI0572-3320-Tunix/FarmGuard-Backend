using FarmGuard_Backend.MedicHistory.Domain.Model.Aggregates;
using FarmGuard_Backend.MedicHistory.Domain.Model.Queries;
using FarmGuard_Backend.MedicHistory.Domain.Repositories;
using FarmGuard_Backend.MedicHistory.Domain.Services;

namespace FarmGuard_Backend.MedicHistory.Application.Internal.QueryServices;

public class MedicalHistoryQueryService(IMedicalHistoryRepository repository) : IMedicalHistoryQueryService
{
    public async Task<MedicalHistory?> HandleByAnimalId(GetMedicalHistoryByAnimalId query)
    {
        // Suponiendo que el repositorio tiene un método para esto
        
        
        

        return await repository.FindByAnimalIdAsync(query.AnimalTag);
    }

    public async Task<MedicalHistory?> HandleById(GetMedicalHistoryById query)
    {
        return await repository.FindByIdAsync(query.Id);
    }
}


