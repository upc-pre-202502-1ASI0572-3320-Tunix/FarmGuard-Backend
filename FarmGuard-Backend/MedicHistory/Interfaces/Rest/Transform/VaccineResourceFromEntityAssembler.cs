using FarmGuard_Backend.MedicHistory.Domain.Model.Entities;
using FarmGuard_Backend.MedicHistory.Interfaces.Rest.resources;

namespace FarmGuard_Backend.MedicHistory.Interfaces.Rest.Transform;

public class VaccineResourceFromEntityAssembler
{
    public static VaccineResource ToEntityFromResource(Vaccine vaccine)
    {
        // Ajuste: Vaccine ya no tiene Description ni Date
        return new VaccineResource(vaccine.Id, vaccine.Name,vaccine.Manufacturer, vaccine.Schema);
    }
}