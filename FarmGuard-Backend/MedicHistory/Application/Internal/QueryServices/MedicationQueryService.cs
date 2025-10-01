using FarmGuard_Backend.MedicHistory.Domain.Model.Entities;
using FarmGuard_Backend.MedicHistory.Domain.Model.Queries;
using FarmGuard_Backend.MedicHistory.Domain.Repositories;
using FarmGuard_Backend.MedicHistory.Domain.Services;

namespace FarmGuard_Backend.MedicHistory.Application.Internal.QueryServices;

public class MedicationQueryService(IMedicationRepository medicationRepository) : IMedicationQueryService
{
    

    public async Task<IEnumerable<Medication>> HandleByTreatmentId(GetMedicationsByTreatmentId query)
    {
        return await medicationRepository.FindByTreatmentId(query.TreatmentId);
    }

    public async Task<Medication?> HandleById(GetMedicationById query)
    {
        return await medicationRepository.FindByIdAsync(query.Id);
    }
}

