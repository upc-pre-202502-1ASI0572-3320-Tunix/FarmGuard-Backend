using FarmGuard_Backend.MedicHistory.Domain.Model.Entities;
using FarmGuard_Backend.MedicHistory.Domain.Model.Queries;

namespace FarmGuard_Backend.MedicHistory.Domain.Services;

public interface IVaccineQueryService
{
    Task<IEnumerable<Vaccine>> Handle(GetVaccinesByMedicalHistoryId query);
    Task <Vaccine?> Handle(GetVaccinesById query);
    
    Task<IEnumerable<Vaccine>> Handle(GetAllVaccinesByIdSectionQuery query);
    
    Task<IEnumerable<Vaccine>> Handle(GetAllVaccinesBySectionAndDateQuery query);
    
}