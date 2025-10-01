using FarmGuard_Backend.MedicHistory.Domain.Model.Commands;
using FarmGuard_Backend.MedicHistory.Domain.Model.Entities;
using FarmGuard_Backend.MedicHistory.Domain.Repositories;
using FarmGuard_Backend.MedicHistory.Domain.Services;
using FarmGuard_Backend.Shared.Domain.Repositories;

namespace FarmGuard_Backend.MedicHistory.Application.Internal.ComandServices;

public class DiseaseCommandService(IDiseaseRepository diseaseRepository,IUnitOfWork unitOfWork) : IDiseaseCommandService
{
    public async Task<Disease?> Handle(CreateDiseaseCommand command)
    {
        var disease = new Disease(command.Name,command.Code,command.DiseaseDiagnosisId);
        await diseaseRepository.AddAsync(disease);
        await unitOfWork.CompleteAsync();
        return disease;
    }

    public async Task<Disease?> Handle(DeleteDiseaseCommand command)
    {
        var disease = await diseaseRepository.FindByIdAsync(command.Id);
        if (disease == null) return null;
        diseaseRepository.Remove(disease);
        await unitOfWork.CompleteAsync();
        return disease;
    }
}

