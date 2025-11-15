using FarmGuard_Backend.Animals.Domain.Model.Commands;
using FarmGuard_Backend.Animals.Interfaces.Rest.resources;

namespace FarmGuard_Backend.Animals.Interfaces.Rest.Transform;

public class CreateAnimalCommandFromResourceAssembler
{
    public static CreateAnimalCommand ToCommandFromResource(CreateAnimalResource resource, int idInventory)
    {
        // Convertir strings a los tipos apropiados con valores por defecto
        long hearRate = 70; // Valor por defecto
        if (!string.IsNullOrWhiteSpace(resource.HearRate))
        {
            long.TryParse(resource.HearRate, out hearRate);
        }

        long temperature = 38; // Valor por defecto
        if (!string.IsNullOrWhiteSpace(resource.Temperature))
        {
            long.TryParse(resource.Temperature, out temperature);
        }

        // Convertir string "true"/"false" a bool
        bool sex = false; // false = hembra por defecto
        if (!string.IsNullOrWhiteSpace(resource.Sex))
        {
            bool.TryParse(resource.Sex, out sex);
        }

        // Parsear fecha ISO 8601
        DateTime birthDate = DateTime.UtcNow;
        if (!string.IsNullOrWhiteSpace(resource.BirthDate))
        {
            DateTime.TryParse(resource.BirthDate, out birthDate);
        }

        return new CreateAnimalCommand(
            resource.Name, 
            resource.Specie,
            resource.UrlIot, 
            resource.File,
            resource.Location, 
            hearRate, 
            temperature,
            idInventory,
            sex,
            birthDate);
    }
}