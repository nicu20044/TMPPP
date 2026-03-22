using TMPPP.Domain.Entities;
using TMPPP.Domain.Interfaces;

namespace TMPPP;

public class InMemoryAthleteRepository : IAthleteRepository
{
    private readonly List<Athlete> _athletes = new();

    public void Add(Athlete athlete)
    {
        _athletes.Add(athlete);
    }

    public Athlete GetById(Guid id)
    {
        return _athletes.First(a => a.Id == id);
    }

    public void Delete(Athlete athlete)
    {
        var existing = _athletes.FirstOrDefault(a => a.Id == athlete.Id);
        if (existing != null)
        {
            _athletes.Remove(existing);
        }
    }

}