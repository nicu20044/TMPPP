using TMPPP_lab1.Domain.Entities;

namespace TMPPP_lab1.Domain.Interfaces;

public interface ICoachRepository
{
    void Add(Coach coach);
    Coach GetById(Guid id);
}