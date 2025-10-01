using FarmGuard_Backend.MedicHistory.Domain.Model.Commands;
using FarmGuard_Backend.MedicHistory.Interfaces.Rest.resources;

namespace FarmGuard_Backend.MedicHistory.Interfaces.Rest.Transform;

public class CreateDiseaseCommandFromResourceAssembler
{
    public static CreateDiseaseCommand ToCommandFromResource(CreateDiseaseResource resource, int diseaseDiagnosisId)
    {
        return new CreateDiseaseCommand(resource.Name, resource.Code, diseaseDiagnosisId);
    }
   
}
