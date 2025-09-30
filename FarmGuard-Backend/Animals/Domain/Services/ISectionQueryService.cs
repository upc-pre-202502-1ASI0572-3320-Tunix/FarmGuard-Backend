using FarmGuard_Backend.Animals.Domain.Model.Aggregates;
using FarmGuard_Backend.Animals.Domain.Model.Queries;

namespace FarmGuard_Backend.Animals.Domain.Services;

public interface ISectionQueryService
{
    Task<Section?> Handle(GetInventoryByIdQueries query);
}