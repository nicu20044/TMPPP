using TMPPP.Domain.Entities;

namespace TMPPP.Domain.Interfaces;

public interface ICoachRepository
{
    void Add(Coach coach);
    Coach GetById(Guid id);
}