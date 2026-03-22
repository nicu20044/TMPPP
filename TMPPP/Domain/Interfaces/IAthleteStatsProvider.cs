using TMPPP.Domain.Entities;

namespace TMPPP.Domain.Interfaces;

public interface IAthleteStatsProvider
{
    AthleteStatistics GetStatistics(Athlete athlete);
    Dictionary<string, double> GetPerformanceMetrics(Athlete athlete);
}

