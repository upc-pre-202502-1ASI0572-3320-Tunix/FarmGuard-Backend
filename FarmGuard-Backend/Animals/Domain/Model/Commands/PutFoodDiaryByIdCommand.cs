namespace FarmGuard_Backend.Animals.Domain.Model.Commands;

public record PutFoodDiaryByIdCommand(int Id, DateTime Date);