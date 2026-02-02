namespace TMPPP_lab1.Domain.Entities;

public class Exercise
{
    public string Name { get; private set; }
    public int Duration { get; private set; }

    public Exercise(string name, int duration)
    {
        Name = name;
        Duration = duration;
    }
}