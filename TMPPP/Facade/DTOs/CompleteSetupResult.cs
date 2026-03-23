using TMPPP.Domain.Entities;

namespace TMPPP.Facade.DTOs;

public class CompleteSetupResult
{
    public Athlete Athlete { get; set; }
    public Coach Coach { get; set; }
    public TrainingPlan TrainingPlan { get; set; }
    public DateTime SetupDate { get; set; }

    public CompleteSetupResult()
    {
        SetupDate = DateTime.Now;
    }

    public CompleteSetupResult(Athlete athlete, Coach coach, TrainingPlan plan)
    {
        Athlete = athlete;
        Coach = coach;
        TrainingPlan = plan;
        SetupDate = DateTime.Now;
    }
    
    public bool IsSuccessful => Athlete != null && Coach != null && TrainingPlan != null;
    
    public string GetSummary()
    {
        if (!IsSuccessful)
            return "Setup incomplete or failed";

        return $"Training program setup completed:\n" +
               $"  - Athlete: {Athlete.Name} ({Athlete.SportType})\n" +
               $"  - Coach: {Coach.Name} ({Coach.YearsOfExperience} years experience)\n" +
               $"  - Training Plan: {TrainingPlan.Name}\n" +
               $"  - Setup Date: {SetupDate:yyyy-mm-dd HH:mm:ss}";
    }
}