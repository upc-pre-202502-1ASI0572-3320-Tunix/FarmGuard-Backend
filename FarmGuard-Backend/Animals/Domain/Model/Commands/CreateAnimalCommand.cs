namespace FarmGuard_Backend.Animals.Domain.Model.Commands;

public record CreateAnimalCommand(
    string name, 
    string specie, 
    string urlIot, 
    IFormFile? Photo, 
    string location, 
    long hearRate,
    long temperature,
    int inventoryId
    );