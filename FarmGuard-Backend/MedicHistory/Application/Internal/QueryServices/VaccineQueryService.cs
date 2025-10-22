using FarmGuard_Backend.MedicHistory.Application.Internal.OutboundServices;
using FarmGuard_Backend.MedicHistory.Domain.Model.Entities;
using FarmGuard_Backend.MedicHistory.Domain.Model.Queries;
using FarmGuard_Backend.MedicHistory.Domain.Repositories;
using FarmGuard_Backend.MedicHistory.Domain.Services;
using FarmGuard_Backend.Shared.Domain.Repositories;

namespace FarmGuard_Backend.MedicHistory.Application.Internal.QueryServices;

public class VaccineQueryService(IVaccineRepository vaccineRepository,IUnitOfWork unitOfWork,ExternalAnimalService externalAnimalService):IVaccineQueryService
{
    public async Task<IEnumerable<Vaccine>> Handle(GetVaccinesByMedicalHistoryId query)
    {
        return await vaccineRepository.FindByMedicalHistoryIdAsync(query.MedicalHistoryId);
    }

    public async Task<Vaccine?> Handle(GetVaccinesById query)
    {
        return await vaccineRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Vaccine>> Handle(GetAllVaccinesByIdSectionQuery query)
    {
        return await  vaccineRepository.FindBySectionIdAsync(query.idSection);
    }

    public async Task<IEnumerable<Vaccine>> Handle(GetAllVaccinesBySectionAndDateQuery query)
    {
       return await vaccineRepository.FindByIdSectionAndDateAsync(query.idSection, query.startDate, query.endDate);
    }
}