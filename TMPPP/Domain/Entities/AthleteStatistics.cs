namespace TMPPP.Domain.Entities;

public class AthleteStatistics
{
    public Guid AthleteId { get; set; }
    public string AthleteName { get; set; }
    public double OverallPerformance { get; set; }
    public int TotalTrainingHours { get; set; }
    public int SessionsCompleted { get; set; }
    public DateTime LastUpdated { get; set; }
}
