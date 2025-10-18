using FarmGuard_Backend.Animals.Domain.Model.Entity;

namespace FarmGuard_Backend.Animals.Domain.Model.Aggregates;

public class FoodDiary
{
    public int Id { get; }
    public DateTime Date { get; private set; }
    
    
    /*Conexion*/
    public Animal Animal { get; private set; }
    public int AnimalId { get; private set; }
    public ICollection<FoodEntry> FoodEntries { get; private set; }
    
    
    public FoodDiary() { }
    
    public FoodDiary(Animal animal, DateTime date)
    {
        Animal = animal;
        Date = date;
    }
}