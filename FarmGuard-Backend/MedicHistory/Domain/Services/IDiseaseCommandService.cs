using FarmGuard_Backend.MedicHistory.Domain.Model.Commands;
using FarmGuard_Backend.MedicHistory.Domain.Model.Entities;

namespace FarmGuard_Backend.MedicHistory.Domain.Services;

public interface IDiseaseCommandService
{
    Task<Disease?> Handle(CreateDiseaseCommand command);
    Task<Disease?> Handle(DeleteDiseaseCommand command);
}

