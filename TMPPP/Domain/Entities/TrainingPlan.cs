using TMPPP.Domain.Interfaces;

namespace TMPPP.Domain.Entities;

public class TrainingPlan : IPrototype
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public Coach Coach { get; private set; }

    private readonly List<Exercise> _exercises = new();
    public IReadOnlyCollection<Exercise> Exercises => _exercises.AsReadOnly();

    public TrainingPlan(string name, Coach coach)
    {
        Id = Guid.NewGuid();
        Name = name;
        Coach = coach;
    }

    public void AddExercise(Exercise exercise)
    {
        _exercises.Add(exercise);
    }

    public string GetName() => Name;
    public IPrototype Clone()
    {
        return new TrainingPlan(this.Name, this.Coach);
    }
}