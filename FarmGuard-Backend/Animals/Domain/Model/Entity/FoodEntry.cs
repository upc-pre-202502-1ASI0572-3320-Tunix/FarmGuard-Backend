using FarmGuard_Backend.Animals.Domain.Model.Aggregates;

namespace FarmGuard_Backend.Animals.Domain.Model.Entity;

public class FoodEntry
{
    public int Id { get; }
    public string Name { get; }
    public float Quantity { get; private set; }
    public DateTime Time { get; private set; }
    public string Notes { get; private set; }
    
    /*Conexion*/
    public FoodDiary FoodDiary { get; private set; }
    public int FoodDiaryId { get; private set; }
    
    public FoodEntry() { }

    public FoodEntry(string name, float quantity, DateTime time, string notes, FoodDiary foodDiary)
    {
        Name = name;
        Quantity = quantity;
        Time = time;
        Notes = notes;
        foodDiary = foodDiary;
    }
}