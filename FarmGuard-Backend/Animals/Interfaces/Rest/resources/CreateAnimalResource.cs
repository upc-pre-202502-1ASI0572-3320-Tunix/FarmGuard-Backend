namespace FarmGuard_Backend.Animals.Interfaces.Rest.resources;

public record CreateAnimalResource(
    string name,
    string specie,
    string urlIot,
    IFormFile? file,
    string location,
    long hearRate,
    long temperature,
    bool sex,
    DateTime birthDate
    );
