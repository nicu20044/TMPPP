using System.ComponentModel.DataAnnotations;

namespace TMPPP.Domain.Entities;

public class AthleteStatistics
{
    [Key]
    public Guid AthleteId { get; set; }
    public string AthleteName { get; set; }
    public double OverallPerformance { get; set; }
    public int TotalTrainingHours { get; set; }
    public int SessionsCompleted { get; set; }
    public DateTime LastUpdated { get; set; }
}
