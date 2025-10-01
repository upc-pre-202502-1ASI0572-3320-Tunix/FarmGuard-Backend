using FarmGuard_Backend.MedicHistory.Domain.Model.Entities;
using FarmGuard_Backend.MedicHistory.Interfaces.Rest.resources;

namespace FarmGuard_Backend.MedicHistory.Interfaces.Rest.Transform;

public class DiseaseResourceFromEntityAssembler
{
    public static DiseaseResource ToEntityFromResource(Disease disease)
    {
        return new DiseaseResource(disease.Id, disease.Name, disease.Code);
    }
}
