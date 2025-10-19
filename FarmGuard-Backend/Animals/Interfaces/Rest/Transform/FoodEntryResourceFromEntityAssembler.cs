using FarmGuard_Backend.Animals.Domain.Model.Entity;
using FarmGuard_Backend.Animals.Interfaces.Rest.resources;

namespace FarmGuard_Backend.Animals.Interfaces.Rest.Transform;

public class FoodEntryResourceFromEntityAssembler
{
    public static FoodEntryResource ToResourceFromEntity(FoodEntry entity)
    {
        return new FoodEntryResource(
            entity.Name,
            entity.Quantity,
            entity.Time,
            entity.Notes,
            entity.Id,
            entity.FoodDiaryId);
    }
}