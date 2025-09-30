using FarmGuard_Backend.Animals.Domain.Model.Aggregates;
using FarmGuard_Backend.Animals.Domain.Model.Commands;
using FarmGuard_Backend.Animals.Domain.Services;

namespace FarmGuard_Backend.Animals.Interfaces.Acl.Services;

public class SectionContextFacade(ISectionCommandService sectionCommandService,ISectionQueryService sectionQueryService):IInventoryContextFacade
{
    
    public async Task<int> CreateInventory(string name,int idProfile)
    {
        var createInventory = new CreateInventoryCommand(name,idProfile);
        var inventory = await sectionCommandService.Handle(createInventory);
        
        return inventory?.Id ?? 0;
    }
}