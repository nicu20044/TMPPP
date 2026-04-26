using TMPPP.Domain.Entities;

namespace TMPPP.Builders.Interfaces;

public interface IAthleteBuilder
{
    void Reset();
    IAthleteBuilder SetName(string name);
    IAthleteBuilder SetSport(string sport);
    IAthleteBuilder SetRanking(int ranking);
    IAthleteBuilder SetEmail(string email);

    IAthleteBuilder SetMedicalStatus(string medicalStatus);
    Athlete Build();
}