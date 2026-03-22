using TMPPP.Builders.Interfaces;
using TMPPP.Domain.Entities;
using TMPPP.DTOs;
using TMPPP.Factories;

namespace TMPPP.Builders;

public class AmateurAthleteBuilder : IAthleteBuilder
{
    private AthleteCreatorDTO _dto = new();
    private readonly ISportsFactory _factory;

    public AmateurAthleteBuilder(ISportsFactory factory) => _factory = factory;

    public void Reset() => _dto = new AthleteCreatorDTO();
    public IAthleteBuilder SetName(string name) { _dto.Name = name; return this; }
    public IAthleteBuilder SetSport(string sport) { _dto.SportType = sport; return this; }
    public IAthleteBuilder SetRanking(int? ranking) { return this; }

    public Athlete Build() => _factory.CreateAthlete(_dto);
}