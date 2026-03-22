using TMPPP.Domain;
using TMPPP.Domain.Entities;

namespace TMPPP.Application.Services;

public class TrainingService
{
    private readonly TrainingPlanRegistry _registry;
    private readonly List<Coach> _authorizedCoaches;

    public TrainingService(List<Coach> registeredCoaches)
    {
        _registry = new TrainingPlanRegistry();
        _authorizedCoaches = registeredCoaches;
    }

    public void CreateOfficialTemplate(Coach coach, string planName)
    {
        if (!_authorizedCoaches.Contains(coach)) return;

        var plan = new TrainingPlan(planName, coach);
        _registry.AddItem(planName, plan);
    }

    public TrainingPlan GetPlan(string name)
    {
        return (TrainingPlan)_registry.GetByName(name);
    }
}