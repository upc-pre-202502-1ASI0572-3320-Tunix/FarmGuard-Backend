namespace FarmGuard_Backend.Animals.Domain.Model.Commands;

public record CreateFoodEntryCommand(string name, float quantity, DateTime time, string notes,int foodDiaryId);