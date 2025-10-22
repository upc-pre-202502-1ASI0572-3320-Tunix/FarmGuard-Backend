using FarmGuard_Backend.Animals.Domain.Model.Aggregates;
using FarmGuard_Backend.MedicHistory.Domain.Model.Entities;

namespace FarmGuard_Backend.MedicHistory.Domain.Model.Aggregates;

public class MedicalHistory
{
    public int Id { get;private set; }
    
    public int AnimalId { get; private set; }
    public Animal Animal { get;private  set; }
    
    public ICollection<Vaccine> Vaccines { get; private set; }
    public ICollection<Treatment> Treatments { get; private set; }
    public ICollection<DiseaseDiagnosis> DiseaseDiagnoses { get; private set; }
    
    public MedicalHistory(){}
    
    public MedicalHistory(Animal animal)
    {
        Animal = animal;
        Vaccines = new List<Vaccine>();
        Treatments = new List<Treatment>();
        DiseaseDiagnoses = new List<DiseaseDiagnosis>();
    }
    
 

    
}