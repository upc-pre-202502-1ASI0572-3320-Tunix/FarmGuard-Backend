using FarmGuard_Backend.Animals.Domain.Model.Aggregates;
using FarmGuard_Backend.Animals.Domain.Model.Commands;

namespace FarmGuard_Backend.Animals.Domain.Services;

public interface ISectionCommandService
{
    Task<Section?> Handle(CreateInventoryCommand command);
}