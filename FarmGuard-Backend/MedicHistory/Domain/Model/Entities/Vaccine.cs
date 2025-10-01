using FarmGuard_Backend.Animals.Domain.Model.Aggregates;
using FarmGuard_Backend.MedicHistory.Domain.Model.Aggregates;

namespace FarmGuard_Backend.MedicHistory.Domain.Model.Entities;

public class Vaccine
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Manufacturer { get; private set; }
    public string Schema { get; private set; }

    public int MedicalHistoryId { get; private set; }
    public MedicalHistory MedicalHistory { get; private set; }

    public Vaccine(){}

    public Vaccine( string name, string manufacturer, string schema, int medicalHistoryId)
    {
        Name = name;
        Manufacturer = manufacturer;
        Schema = schema;
        MedicalHistoryId = medicalHistoryId;
    }


}