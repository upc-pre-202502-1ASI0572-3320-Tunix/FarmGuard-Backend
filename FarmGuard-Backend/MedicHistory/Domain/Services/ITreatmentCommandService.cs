using FarmGuard_Backend.MedicHistory.Domain.Model.Commands;
using FarmGuard_Backend.MedicHistory.Domain.Model.Aggregates;

namespace FarmGuard_Backend.MedicHistory.Domain.Services;

public interface ITreatmentCommandService
{
    Task<Treatment?> Handle(CreateTreatmentCommand command);
    Task<Treatment?> Handle(DeleteTreatmentCommand command);
}

