namespace TMPPP_lab1.Domain.Interfaces;

public interface IAthleteRepository
{
    void Add(Athlete athlete);
    Athlete GetById(Guid id);
}