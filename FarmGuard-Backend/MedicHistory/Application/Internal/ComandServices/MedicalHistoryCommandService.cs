using FarmGuard_Backend.MedicHistory.Domain.Model.Aggregates;
using FarmGuard_Backend.MedicHistory.Domain.Model.Commands;
using FarmGuard_Backend.MedicHistory.Domain.Repositories;
using FarmGuard_Backend.MedicHistory.Domain.Services;
using FarmGuard_Backend.Shared.Domain.Repositories;

namespace FarmGuard_Backend.MedicHistory.Application.Internal.ComandServices;

public class MedicalHistoryCommandService(IMedicalHistoryRepository repository,IUnitOfWork unitOfWork) : IMedicalHistoryCommandService
{
    public async Task<MedicalHistory?> Handle(CreateMedicalHistoryCommand command)
    {
        /*Verificar si animal existe*/
        var entity = new MedicalHistory(command.animal);
        await repository.AddAsync(entity);
        await unitOfWork.CompleteAsync();
        return entity;
        
    }

    public async Task<MedicalHistory?> Handle(DeleteMedicalHistoryCommand command)
    {
        var entity = await repository.FindByIdAsync(command.Id);
        if (entity == null) return null;
        repository.Remove(entity);
        await unitOfWork.CompleteAsync();
        return entity;
    }
}

