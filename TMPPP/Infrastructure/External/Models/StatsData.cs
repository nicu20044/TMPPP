namespace TMPPP.Infrastructure.External.Models;

public class StatsData
{
    public string Identifier { get; set; }
    public double PerformanceScore { get; set; }
    public int TrainingHours { get; set; }
    public int CompletedSessions { get; set; }
    public string Period { get; set; }
}
