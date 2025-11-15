namespace FarmGuard_Backend.Animals.Interfaces.Rest.resources;

public record CreateAnimalResource(
    string Name,
    string Specie,
    string UrlIot,
    IFormFile? File,
    string Location,
    string HearRate,
    string Temperature,
    string Sex,
    string BirthDate
    );
