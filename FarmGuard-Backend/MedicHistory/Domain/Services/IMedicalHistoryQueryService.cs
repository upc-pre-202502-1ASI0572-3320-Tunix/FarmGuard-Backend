using FarmGuard_Backend.MedicHistory.Domain.Model.Aggregates;
using FarmGuard_Backend.MedicHistory.Domain.Model.Queries;

namespace FarmGuard_Backend.MedicHistory.Domain.Services;

public interface IMedicalHistoryQueryService
{
    Task<MedicalHistory?> HandleByAnimalId(GetMedicalHistoryByAnimalId query);
    Task<MedicalHistory?> HandleById(GetMedicalHistoryById query);
}




