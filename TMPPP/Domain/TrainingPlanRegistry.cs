using TMPPP.Domain.Interfaces;

namespace TMPPP.Domain;

public class TrainingPlanRegistry
{
    private readonly Dictionary<string, IPrototype> _items = new();

    public void AddItem(string id, IPrototype p)
    {
        _items[id] = p;
    }

    public IPrototype GetById(string id)
    {
        return _items[id].Clone();
    }

    public IPrototype GetByName(string name)
    {
        foreach (var item in _items.Values)
        {
            if (item.GetName() == name)
            {
                return item.Clone();
            }
        }
        return null;
    }
}