namespace FarmGuard_Backend.Animals.Domain.Model.Commands;

public record PutAnimalCommand(
    string Name,
    string AnimalId,
    string Specie,
    string UrlIot,
    IFormFile? file,
    string Location,
    long HearRate,
    long Temperature
    );