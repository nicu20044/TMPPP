using TMPPP.Application.Services;
using TMPPP.Domain.Entities;
using TMPPP.Domain.Interfaces;
using TMPPP.DTOs;
using TMPPP.Facade.DTOs;
using TMPPP.Infrastructure.Logging;

namespace TMPPP.Facade;

public class SportsManagementFacade
{
    private readonly AthleteService _athleteService;
    private readonly IAthleteRepository _athleteRepository;
    private readonly CoachService _coachService;
    private readonly TrainingService _trainingService;
    private readonly IAthleteStatsProvider _statsProvider;
    private readonly AppLogger _logger;

    public SportsManagementFacade(
        AthleteService athleteService,
        CoachService coachService,
        TrainingService trainingService,
        IAthleteStatsProvider statsProvider,
        IAthleteRepository athleteRepository)
    {
        _athleteService = athleteService;
        _coachService = coachService;
        _trainingService = trainingService;
        _statsProvider = statsProvider;
        _athleteRepository = athleteRepository;
        _logger = AppLogger.GetInstance();
    }

    /// <summary>
    /// Simplified operation: Register a new athlete
    /// Orchestrates behind the scenes: validation, creation, saving, logging
    /// </summary>
    /// <param name="name">Athlete's full name</param>
    /// <param name="sport">Sport type (e.g., Tennis, Football)</param>
    /// <param name="ranking">Current ranking position</param>
    /// <returns>Created athlete entity</returns>
    public Athlete RegisterNewAthlete(string name, string sport, int ranking)
    {
        _logger.Log($"[FACADE] Starting athlete registration: {name}");

        var dto = new AthleteCreatorDTO
        {
            Name = name,
            SportType = sport,
            Ranking = ranking
        };

        var athlete = _athleteService.RegisterAthlete(dto);

        _logger.Log($"[FACADE] Athlete {athlete.Name} registered successfully");

        return athlete;
    }

    /// <summary>
    /// Simplified operation: Create a coach and training plan in a single operation
    /// </summary>
    /// <param name="coachName">Coach's full name</param>
    /// <param name="specialization">Area of expertise</param>
    /// <param name="experience">Years of coaching experience</param>
    /// <param name="planName">Name for the training plan</param>
    /// <returns>Tuple containing created coach and training plan</returns>
    public (Coach coach, TrainingPlan plan) SetupCoachWithPlan(
        string coachName,
        string specialization,
        int experience,
        string planName)
    {
        _logger.Log($"[FACADE] Setting up coach {coachName} with training plan {planName}");

        var coachDto = new CoachCreatorDTO
        {
            Name = coachName,
            Specialization = specialization,
            YearsOfExperience = experience
        };

        var coach = _coachService.RegisterCoach(coachDto);

        var plan = _coachService.CreateTrainingPlan(coach.Id, planName);

        _logger.Log($"[FACADE] Coach and plan setup completed successfully");

        return (coach, plan);
    }

    /// <summary>
    /// Complex operation simplified: Get complete athlete report
    /// Combines data from repository, external statistics, and training plans
    /// </summary>
    /// <param name="athlete">Athlete entity</param>
    /// <returns>Complete performance report with aggregated data</returns>
    public AthleteFullReport GetAthleteFullReport(Athlete athlete)
    {
        _logger.Log($"[FACADE] Generating full report for athlete {athlete.Name} ID:{athlete.Id}");

        var statistics = _statsProvider.GetStatistics(athlete);
        var metrics = _statsProvider.GetPerformanceMetrics(athlete);

        var report = new AthleteFullReport
        {
            AthleteId = athlete.Id,
            AthleteName = athlete.Name,
            Sport = athlete.SportType,
            Statistics = statistics,
            PerformanceMetrics = metrics,
            ReportGeneratedAt = DateTime.Now
        };

        _logger.Log($"[FACADE] Full report generated successfully");

        return report;
    }

    /// <summary>
    /// Start training session with full logging and stats tracking
    /// Fetches athlete details for meaningful logging
    /// </summary>
    /// <param name="athleteId">Unique identifier of the athlete</param>
    public void StartTrainingSession(Guid athleteId)
    {
        var athlete = _athleteRepository.GetById(athleteId);

        if (athlete == null)
        {
            _logger.Log($"[FACADE] ERROR: Athlete with ID {athleteId} not found");
            throw new ArgumentException($"Athlete with ID {athleteId} not found");
        }

        _logger.Log(
            $"[FACADE] Initiating training session for '{athlete.Name}' ({athlete.SportType}, ID: {athleteId})");

        _athleteService.StartTraining(athleteId);

        _logger.Log($"[FACADE] Training session for '{athlete.Name}' ID: {athleteId} completed successfully");
    }

    /// <summary>
    /// Complex operation: Complete training program setup
    /// Creates athlete, coach, training plan, and associates them
    /// </summary>
    /// <param name="athleteName">Athlete's full name</param>
    /// <param name="athleteSport">Sport type</param>
    /// <param name="athleteRanking">Current ranking</param>
    /// <param name="coachName">Coach's full name</param>
    /// <param name="coachSpecialization">Coach's area of expertise</param>
    /// <param name="coachExperience">Years of experience</param>
    /// <param name="programName">Name for the training program</param>
    /// <returns>Complete setup result with all created entities</returns>
    public CompleteSetupResult SetupCompleteTrainingProgram(
        string athleteName,
        string athleteSport,
        int athleteRanking,
        string coachName,
        string coachSpecialization,
        int coachExperience,
        string programName)
    {
        _logger.Log($"[FACADE] Setting up complete training program: {programName}");

        var athlete = RegisterNewAthlete(athleteName, athleteSport, athleteRanking);

        var (coach, plan) = SetupCoachWithPlan(
            coachName,
            coachSpecialization,
            coachExperience,
            programName
        );

        _logger.Log($"[FACADE] Complete training program setup finished");

        return new CompleteSetupResult
        {
            Athlete = athlete,
            Coach = coach,
            TrainingPlan = plan,
            SetupDate = DateTime.Now
        };
    }
}