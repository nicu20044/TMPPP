using TMPPP.Domain.Entities;
using TMPPP.Domain.Interfaces;
using TMPPP.Infrastructure.External;
using TMPPP.Infrastructure.External.Models;

namespace TMPPP.Adapters;

public class ExternalStatsAdapter : IAthleteStatsProvider
{
    private readonly ExternalStatsService _externalService;

    public ExternalStatsAdapter(ExternalStatsService externalService)
    {
        _externalService = externalService;
    }

    public AthleteStatistics GetStatistics(Athlete athlete)
    {
        // conversion for external api
        string athleteIdentifier = $"{athlete.Name}_{athlete.Id}";
        string dateRange = "last_30_days";
        
        StatsData externalData = _externalService.FetchAthletePerformance(
            athleteIdentifier, 
            dateRange
        );

        return new AthleteStatistics
        {
            AthleteId = athlete.Id,
            AthleteName = athlete.Name,
            OverallPerformance = externalData.PerformanceScore,
            TotalTrainingHours = externalData.TrainingHours,
            SessionsCompleted = externalData.CompletedSessions,
            LastUpdated = DateTime.Now
        };
    }

    public Dictionary<string, double> GetPerformanceMetrics(Athlete athlete)
    {
        string athleteIdentifier = $"{athlete.Name}_{athlete.Id}";

        List<MetricEntry> externalMetrics = _externalService.GetDetailedMetrics(athleteIdentifier);

        var metrics = new Dictionary<string, double>();
        
        foreach (var metric in externalMetrics)
        {
            metrics[metric.MetricName] = metric.Value;
        }

        return metrics;
    }
}
