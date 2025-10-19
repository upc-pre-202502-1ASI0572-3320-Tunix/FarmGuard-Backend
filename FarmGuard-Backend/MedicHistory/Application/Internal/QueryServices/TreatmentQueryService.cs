using FarmGuard_Backend.Animals.Domain.Model.Queries;
using FarmGuard_Backend.MedicHistory.Domain.Model.Aggregates;
using FarmGuard_Backend.MedicHistory.Domain.Model.Queries;
using FarmGuard_Backend.MedicHistory.Domain.Repositories;
using FarmGuard_Backend.MedicHistory.Domain.Services;

namespace FarmGuard_Backend.MedicHistory.Application.Internal.QueryServices;

public class TreatmentQueryService(ITreatmentRepository treatmentRepository) : ITreatmentQueryService
{

    public async Task<IEnumerable<Treatment>> Handle(GetTreatmentsByMedicalHistoryId query)
    {
        return await treatmentRepository.FindByMedicalHistoryId(query.MedicalHistoryId);
    }

    public async Task<Treatment?> Handle(GetTreatmentsById query)
    {
        return await treatmentRepository.FindByIdAsync(query.Id);
    }
    
    public async Task<IEnumerable<Treatment>> Handle(GetTreatmentsByIdSectionQuery query)
    {
        return await treatmentRepository.FindByIdSection(query.idSection);
    }
}

