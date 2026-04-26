using TMPPP.Domain.Interfaces;

namespace TMPPP.Domain.Entities;

public class TrainingExercise : ITrainingComponent
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int Duration { get; private set; }
    public string Description { get; private set; }
    public int Sets { get; private set; }
    public int Reps { get; private set; }

    public TrainingExercise(string name, int duration, string description = "", int sets = 1, int reps = 1)
    {
        Name = name;
        Duration = duration;
        Description = description;
        Sets = sets;
        Reps = reps;
    }

    public string GetName() => Name;

    public int GetTotalDuration() => Duration;

    public void Execute()
    {
        Console.WriteLine($"Executing: {Name} - {Sets} sets x {Reps} reps ({Duration} min)");
    }

    public void Display(int depth = 0)
    {
        string indent = new string('-', depth * 2);
        Console.WriteLine($"{indent} {Name} ({Duration} min)");
        if (!string.IsNullOrEmpty(Description))
        {
            Console.WriteLine($"{indent} {Description}");
        }
    }
}
