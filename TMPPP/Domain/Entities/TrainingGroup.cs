using TMPPP.Domain.Interfaces;

namespace TMPPP.Domain.Entities;

public class TrainingGroup : ITrainingComponent
{
    private readonly List<ITrainingComponent> _children = new();
    public string Name { get; private set; }
    public string Description { get; private set; }

    public TrainingGroup(string name, string description = "")
    {
        Name = name;
        Description = description;
    }

    public void Add(ITrainingComponent component)
    {
        _children.Add(component);
    }

    public void Remove(ITrainingComponent component)
    {
        _children.Remove(component);
    }

    public ITrainingComponent GetChild(int index)
    {
        return _children[index];
    }

    public List<ITrainingComponent> GetChildren()
    {
        return new List<ITrainingComponent>(_children);
    }

    public string GetName() => Name;

    public int GetTotalDuration()
    {
        int total = 0;
        foreach (var child in _children)
        {
            total += child.GetTotalDuration();
        }
        return total;
    }

    public void Execute()
    {
        Console.WriteLine($"\nStarting: {Name}");
        if (!string.IsNullOrEmpty(Description))
        {
            Console.WriteLine($"{Description}");
        }

        foreach (var child in _children)
        {
            child.Execute();
        }

        Console.WriteLine($"Completed: {Name} (Total: {GetTotalDuration()} min)\n");
    }

    public void Display(int depth = 0)
    {
        string indent = new string('-', depth * 2);
        Console.WriteLine($"{indent}{Name} (Total: {GetTotalDuration()} min)");
        
        if (!string.IsNullOrEmpty(Description))
        {
            Console.WriteLine($"{indent} {Description}");
        }

        foreach (var child in _children)
        {
            child.Display(depth + 1);
        }
    }
}
