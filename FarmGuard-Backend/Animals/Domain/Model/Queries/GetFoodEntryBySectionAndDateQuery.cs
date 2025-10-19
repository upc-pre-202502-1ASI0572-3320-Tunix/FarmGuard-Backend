namespace FarmGuard_Backend.Animals.Domain.Model.Queries;

public record GetFoodEntryBySectionAndDateQuery(int idSection, DateTime startDate,  DateTime endDate);