using TMPPP.Domain.Entities;
using TMPPP.Domain.Interfaces;
using TMPPP.DTOs;
using TMPPP.Factories;
using TMPPP.Infrastructure.Logging;

namespace TMPPP.Application.Services;

public class CoachService
{
    private readonly ICoachRepository _coachRepository;
    private readonly ITrainingPlanRepository _trainingPlanRepository;
    private readonly ISportsFactory _factory;
    private readonly AppLogger _logger;

    public CoachService(
        ICoachRepository coachRepository,
        ITrainingPlanRepository trainingPlanRepository,
        ISportsFactory factory
    )
    {
        _coachRepository = coachRepository;
        _trainingPlanRepository = trainingPlanRepository;
        _factory = factory;
        _logger = AppLogger.GetInstance();
    }

    public Coach RegisterCoach(CoachCreatorDTO dto)
    {
        var coach = _factory.CreateCoach(dto);
        _logger.Log($"Coach created: {dto.Name}");
        _coachRepository.Add(coach);
        _logger.Log($"Coach saved with ID: {coach.Id}");
        return coach;
    }

    public TrainingPlan CreateTrainingPlan(Guid coachId, string planName)
    {
        var coach = _coachRepository.GetById(coachId);

        if (coach == null)
        {
            _logger.Log($"ERROR: Coach {coachId} not found");
             throw new Exception($"Coach {coachId} not found");
        }

        var plan = new TrainingPlan(planName, coach);

        _logger.Log($"Training plan '{planName}' created for coach {coachId}");

        _trainingPlanRepository.Add(plan);

        return plan;
    }
}