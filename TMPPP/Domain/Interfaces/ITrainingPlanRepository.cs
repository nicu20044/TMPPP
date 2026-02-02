using TMPPP_lab1.Domain.Entities;

namespace TMPPP_lab1.Domain.Interfaces;

public interface ITrainingPlanRepository
{
    void Add(TrainingPlan plan);
    TrainingPlan GetById(Guid id);
}