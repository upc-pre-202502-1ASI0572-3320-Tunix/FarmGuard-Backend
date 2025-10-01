using FarmGuard_Backend.MedicHistory.Domain.Model.Aggregates;
using FarmGuard_Backend.MedicHistory.Domain.Model.Commands;
using FarmGuard_Backend.MedicHistory.Domain.Repositories;
using FarmGuard_Backend.MedicHistory.Domain.Services;
using FarmGuard_Backend.Shared.Domain.Repositories;

namespace FarmGuard_Backend.MedicHistory.Application.Internal.ComandServices;

public class TreatmentCommandService(ITreatmentRepository treatmentRepository,IUnitOfWork unitOfWork) : ITreatmentCommandService
{
    public async Task<Treatment?> Handle(CreateTreatmentCommand command)
    {
        var treatment = new Treatment(
            command.Title, 
            command.Notes, 
            command.StartDate, 
            command.Status, 
            command.MedicalHistoryId);
        await treatmentRepository.AddAsync(treatment);
        await unitOfWork.CompleteAsync();
        return treatment;
    }

    public async Task<Treatment?> Handle(DeleteTreatmentCommand command)
    {
        var treatment = await treatmentRepository.FindByIdAsync(command.Id);
        if (treatment == null) return null;
        treatmentRepository.Remove(treatment);
        await unitOfWork.CompleteAsync();
        return treatment;
    }
}

