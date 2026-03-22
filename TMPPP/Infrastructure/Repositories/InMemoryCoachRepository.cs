using TMPPP.Domain.Entities;
using TMPPP.Domain.Interfaces;

namespace TMPPP;

public class InMemoryCoachRepository : ICoachRepository
{
    private readonly List<Coach> _coaches = new();

    public void Add(Coach coach)
    {
        _coaches.Add(coach);
    }

    public Coach GetById(Guid id)
    {
        return _coaches.First(c => c.Id == id);
    }
    public void Delete(Coach coach)
    {
        var existing = _coaches.FirstOrDefault(a => a.Id == coach.Id);
        if (existing != null)
        {
            _coaches.Remove(existing);
        }
    }
    
}