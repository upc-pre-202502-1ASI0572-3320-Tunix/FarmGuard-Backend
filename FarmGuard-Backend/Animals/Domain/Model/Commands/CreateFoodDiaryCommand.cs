using FarmGuard_Backend.Animals.Domain.Model.Aggregates;

namespace FarmGuard_Backend.Animals.Domain.Model.Commands;

public record CreateFoodDiaryCommand(DateTime Date, Animal Animal);