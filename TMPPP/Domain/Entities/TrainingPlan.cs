using TMPPP.Domain.Interfaces;

namespace TMPPP.Domain.Entities;

public class TrainingPlan : IPrototype
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Coach Coach { get; private set; }

    private readonly List<Exercise> _exercises = new();
    public IReadOnlyCollection<Exercise> Exercises => _exercises.AsReadOnly();

    private TrainingPlan() 
    { 
        // EF are nevoie de acesta pentru a instanția obiectul la citirea din SQL
    }
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