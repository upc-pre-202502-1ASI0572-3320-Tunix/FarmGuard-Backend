using FarmGuard_Backend.MedicHistory.Domain.Model.Commands;
using FarmGuard_Backend.MedicHistory.Interfaces.Rest.resources;

namespace FarmGuard_Backend.MedicHistory.Interfaces.Rest.Transform;

public class CreateVaccineCommandFromResourceAssembler
{
    public static CreateVaccineCommand ToCommandFromResource(CreateVaccineResource resource,int medicalHistoryId)
    {
        return new CreateVaccineCommand(
            resource.Name,
            resource.Manufacturer,
            resource.Schema,
            medicalHistoryId
        );
    }
}
