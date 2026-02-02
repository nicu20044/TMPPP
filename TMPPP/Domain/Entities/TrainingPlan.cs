namespace TMPPP_lab1.Domain.Entities;

public class TrainingPlan
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
}