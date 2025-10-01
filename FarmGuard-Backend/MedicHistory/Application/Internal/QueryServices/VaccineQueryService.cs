using FarmGuard_Backend.MedicHistory.Application.Internal.OutboundServices;
using FarmGuard_Backend.MedicHistory.Domain.Model.Entities;
using FarmGuard_Backend.MedicHistory.Domain.Model.Queries;
using FarmGuard_Backend.MedicHistory.Domain.Repositories;
using FarmGuard_Backend.MedicHistory.Domain.Services;
using FarmGuard_Backend.Shared.Domain.Repositories;

namespace FarmGuard_Backend.MedicHistory.Application.Internal.QueryServices;

public class VaccineQueryService(IVaccineRepository vaccineRepository,IUnitOfWork unitOfWork,ExternalAnimalService externalAnimalService):IVaccineQueryService
{
    public async Task<IEnumerable<Vaccine>> HandleByMedicalHistoryId(GetVaccinesByMedicalHistoryId query)
    {
        return await vaccineRepository.FindByMedicalHistoryIdAsync(query.MedicalHistoryId);
    }

    public async Task<Vaccine?> HandleById(GetVaccinesById query)
    {
        return await vaccineRepository.FindByIdAsync(query.Id);
    }
}