namespace FarmGuard_Backend.Animals.Interfaces.Rest.resources;

public record CreateFoodEntryResource(string Name, float Quantity, DateTime Time, string Notes);