using TMPPP.Domain.Entities;

namespace TMPPP.Domain.Interfaces;

public interface ITrainingPlanRepository
{
    void Add(TrainingPlan plan);
    TrainingPlan GetById(Guid id);
}