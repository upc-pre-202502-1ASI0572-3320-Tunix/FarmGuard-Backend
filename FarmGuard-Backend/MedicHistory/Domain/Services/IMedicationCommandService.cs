using FarmGuard_Backend.MedicHistory.Domain.Model.Commands;
using FarmGuard_Backend.MedicHistory.Domain.Model.Entities;

namespace FarmGuard_Backend.MedicHistory.Domain.Services;

public interface IMedicationCommandService
{
    Task<Medication?> Handle(CreateMedicationCommand command);
    Task<Medication?> Handle(DeleteMedicationCommand command);
}

