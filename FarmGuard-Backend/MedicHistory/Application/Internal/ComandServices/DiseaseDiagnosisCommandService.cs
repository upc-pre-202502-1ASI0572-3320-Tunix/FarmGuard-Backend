using FarmGuard_Backend.MedicHistory.Domain.Model.Aggregates;
using FarmGuard_Backend.MedicHistory.Domain.Model.Commands;
using FarmGuard_Backend.MedicHistory.Domain.Repositories;
using FarmGuard_Backend.MedicHistory.Domain.Services;
using FarmGuard_Backend.Shared.Domain.Repositories;

namespace FarmGuard_Backend.MedicHistory.Application.Internal.ComandServices;

public class DiseaseDiagnosisCommandService(IDiseaseDiagnosisRepository repository,IUnitOfWork unitOfWork) : IDiseaseDiagnosisCommandService
{
    public async Task<DiseaseDiagnosis?> Handle(CreateDiseaseDiagnosisCommand command)
    {
        var entity = new DiseaseDiagnosis(
            command.severity,
            command.notes,
            command.diagnosedAt,
            command.medicalHistoryId
            );
        await repository.AddAsync(entity);
        await unitOfWork.CompleteAsync();
        return entity;
    }

    public async Task<DiseaseDiagnosis?> Handle(DeleteDiseaseDiagnosisCommand command)
    {
        var entity = await repository.FindByIdAsync(command.Id);
        if (entity == null) return null;
        repository.Remove(entity);
        await unitOfWork.CompleteAsync();
        return entity;
    }
}

