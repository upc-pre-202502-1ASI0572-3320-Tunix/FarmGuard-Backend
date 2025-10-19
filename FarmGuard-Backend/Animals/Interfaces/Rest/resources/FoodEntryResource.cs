namespace FarmGuard_Backend.Animals.Interfaces.Rest.resources;

public record FoodEntryResource(string Name, float Quantity, DateTime Time, string Notes, int Id, int FoodDiaryId);