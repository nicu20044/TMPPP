using TMPPP.Domain.Entities;
using TMPPP.Domain.Interfaces;

namespace TMPPP;

public class InMemoryTrainingPlanRepository : ITrainingPlanRepository
{
    private readonly List<TrainingPlan> _plans = new();

    public void Add(TrainingPlan plan)
    {
        _plans.Add(plan);
    }

    public TrainingPlan GetById(Guid id)
    {
        return _plans.First(p => p.Id == id);
    }
    public void Delete(TrainingPlan trainingPlan)
    {
        var existing = _plans.FirstOrDefault(a => a.Id == trainingPlan.Id);
        if (existing != null)
        {
            _plans.Remove(existing);
        }
    }
}