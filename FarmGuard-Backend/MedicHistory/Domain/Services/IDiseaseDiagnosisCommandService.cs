using FarmGuard_Backend.MedicHistory.Domain.Model.Aggregates;
using FarmGuard_Backend.MedicHistory.Domain.Model.Commands;

namespace FarmGuard_Backend.MedicHistory.Domain.Services;

public interface IDiseaseDiagnosisCommandService
{
    Task<DiseaseDiagnosis?> Handle(CreateDiseaseDiagnosisCommand command);
    Task<DiseaseDiagnosis?> Handle(DeleteDiseaseDiagnosisCommand command);
}

