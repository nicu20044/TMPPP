using TMPPP_lab1.Domain.Entities;
using TMPPP_lab1.Domain.Interfaces;

namespace TMPPP_lab1.Application.Services;

public class CoachService(
    ICoachRepository coachRepository,
    ITrainingPlanRepository trainingPlanRepository)
{
    public void RegisterCoach(Coach coach)
    {
        coachRepository.Add(coach);
    }

    public TrainingPlan CreateTrainingPlan(Guid coachId, string planName)
    {
        var coach = coachRepository.GetById(coachId);
        var plan = new TrainingPlan(planName, coach);

        trainingPlanRepository.Add(plan);
        return plan;
    }
}
