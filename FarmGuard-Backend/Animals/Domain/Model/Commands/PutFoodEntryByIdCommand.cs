namespace FarmGuard_Backend.Animals.Domain.Model.Commands;

public record PutFoodEntryByIdCommand(int id,string name, float quantity, DateTime time, string notes);