using TMPPP.Domain.Entities;

namespace TMPPP.Domain.Interfaces;

public interface IAthleteRepository
{
    void Add(Athlete athlete);
    Athlete GetById(Guid id);
}