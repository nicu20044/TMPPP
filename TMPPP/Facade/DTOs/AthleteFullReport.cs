using TMPPP.Domain.Entities;

namespace TMPPP.Facade.DTOs;

public class AthleteFullReport
{
    public Guid AthleteId { get; set; }
    public string AthleteName { get; set; }
    public string Sport { get; set; }
    public AthleteStatistics Statistics { get; set; }
    public Dictionary<string, double> PerformanceMetrics { get; set; }
    public DateTime ReportGeneratedAt { get; set; }

    public AthleteFullReport()
    {
        ReportGeneratedAt = DateTime.Now;
        PerformanceMetrics = new Dictionary<string, double>();
    }


    public void DisplayAthleteReport()
    {
        Console.WriteLine("\n" + new string('=', 60));
        Console.WriteLine($"ATHLETE PERFORMANCE REPORT");
        Console.WriteLine(new string('=', 60));
        Console.WriteLine($"Name: {AthleteName}");
        Console.WriteLine($"Sport: {Sport}");
        Console.WriteLine($"ID: {AthleteId}");
        Console.WriteLine($"\nPerformance Overview:");
        Console.WriteLine($"  Overall Score: {Statistics.OverallPerformance:F2}");
        Console.WriteLine($"  Training Hours: {Statistics.TotalTrainingHours}");
        Console.WriteLine($"  Sessions Completed: {Statistics.SessionsCompleted}");
        Console.WriteLine($"\nDetailed Metrics:");
        foreach (var metric in PerformanceMetrics)
        {
            Console.WriteLine($"  {metric.Key}: {metric.Value:F2}");
        }
        Console.WriteLine($"\nGenerated: {ReportGeneratedAt:yyyy-MM-dd HH:mm:ss}");
        Console.WriteLine(new string('=', 60) + "\n");
    }
}