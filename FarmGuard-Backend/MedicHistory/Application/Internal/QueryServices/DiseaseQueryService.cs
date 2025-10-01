using FarmGuard_Backend.MedicHistory.Domain.Model.Entities;
using FarmGuard_Backend.MedicHistory.Domain.Model.Queries;
using FarmGuard_Backend.MedicHistory.Domain.Repositories;
using FarmGuard_Backend.MedicHistory.Domain.Services;

namespace FarmGuard_Backend.MedicHistory.Application.Internal.QueryServices;

public class DiseaseQueryService(IDiseaseRepository diseaseRepository) : IDiseaseQueryService
{

    public async Task<IEnumerable<Disease>> HandleByDiseaseDiagnosisId(GetDiseaseByDiseaseDiagnosisId query)
    {
        return await diseaseRepository.FindByDiseaseDiagnosisIdAsync(query.DiseaseDiagnosisId);
    }

    public async Task<Disease?> HandleById(GetDiseaseById query)
    {
        return await diseaseRepository.FindByIdAsync(query.Id);
    }
}

