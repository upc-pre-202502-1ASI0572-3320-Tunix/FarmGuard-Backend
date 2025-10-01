using FarmGuard_Backend.MedicHistory.Domain.Model.Commands;
using FarmGuard_Backend.MedicHistory.Domain.Model.Entities;
using FarmGuard_Backend.MedicHistory.Domain.Repositories;
using FarmGuard_Backend.MedicHistory.Domain.Services;
using FarmGuard_Backend.Shared.Domain.Repositories;

namespace FarmGuard_Backend.MedicHistory.Application.Internal.ComandServices;

public class MedicationCommandService(IMedicationRepository medicationRepository,IUnitOfWork unitOfWork) : IMedicationCommandService
{
    public async Task<Medication?> Handle(CreateMedicationCommand command)
    {
        var medication = new Medication(
            command.Name, 
            command.ActiveIngredient,
            command.DoseDefault, 
            command.RouteOfAdministration, 
            command.TreatmentId);
        await medicationRepository.AddAsync(medication);
        await unitOfWork.CompleteAsync();
        return medication;
    }

    public async Task<Medication?> Handle(DeleteMedicationCommand command)
    {
        var medication = await medicationRepository.FindByIdAsync(command.Id);
        if (medication == null) return null;
        medicationRepository.Remove(medication);
        await unitOfWork.CompleteAsync();
        return medication;
    }
}

