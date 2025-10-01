using FarmGuard_Backend.MedicHistory.Domain.Model.Aggregates;
using FarmGuard_Backend.MedicHistory.Domain.Model.Commands;

namespace FarmGuard_Backend.MedicHistory.Domain.Services;

public interface IMedicalHistoryCommandService
{
    Task<MedicalHistory?> Handle(CreateMedicalHistoryCommand command);
    Task<MedicalHistory?> Handle(DeleteMedicalHistoryCommand command);
}

