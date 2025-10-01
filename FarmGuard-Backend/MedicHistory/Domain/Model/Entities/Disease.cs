using FarmGuard_Backend.MedicHistory.Domain.Model.Aggregates;

namespace FarmGuard_Backend.MedicHistory.Domain.Model.Entities;

public class Disease
{
    public int Id { get; private set;}
    public string Name { get; private set; }
    public string Code { get; private set; }
    
    
    public int DiseaseDiagnosisId { get; private set; }
    public DiseaseDiagnosis DiseaseDiagnosis { get; private set; }
    
    public Disease(){}
    public Disease(string name, string code, int diseaseDiagnosisId)
    {
        Name = name;
        Code = code;
        DiseaseDiagnosisId = diseaseDiagnosisId;
    }
}