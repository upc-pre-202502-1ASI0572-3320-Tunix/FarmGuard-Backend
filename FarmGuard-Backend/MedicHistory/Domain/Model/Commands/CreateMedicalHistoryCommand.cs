using FarmGuard_Backend.Animals.Domain.Model.Aggregates;

namespace FarmGuard_Backend.MedicHistory.Domain.Model.Commands;

public record CreateMedicalHistoryCommand(
    Animal animal
);

