namespace TMPPP.Domain.Entities;

public class Exercise
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string MuscleGroup { get; set; }
    public string Equipment { get; set; }
    public int Duration { get; private set; }

    public Exercise(string name, int duration, string muscleGroup, string equipment)
    {
        Name = name;
        Duration = duration;
        MuscleGroup = muscleGroup;
        Equipment = equipment;
    }
}