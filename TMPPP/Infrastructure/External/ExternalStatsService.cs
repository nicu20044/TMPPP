using TMPPP.Infrastructure.External.Models;

namespace TMPPP.Infrastructure.External;


public class ExternalStatsService
{
    public StatsData FetchAthletePerformance(string athleteIdentifier, string dateRange)
    {
        // API call sim
        Console.WriteLine($"[External API] Fetching stats for {athleteIdentifier} in range {dateRange}");
        
        return new StatsData
        {
            Identifier = athleteIdentifier,
            PerformanceScore = 85.5,
            TrainingHours = 120,
            CompletedSessions = 24,
            Period = dateRange
        };
    }

    public List<MetricEntry> GetDetailedMetrics(string athleteIdentifier)
    {
        Console.WriteLine($"[External API] Fetching detailed metrics for {athleteIdentifier}");
        
        return new List<MetricEntry>
        {
            new MetricEntry { MetricName = "Speed", Value = 25.5, Unit = "km/h" },
            new MetricEntry { MetricName = "Endurance", Value = 78.0, Unit = "%" },
            new MetricEntry { MetricName = "Strength", Value = 92.0, Unit = "kg" }
        };
    }
}


