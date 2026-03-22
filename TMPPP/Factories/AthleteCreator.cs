using TMPPP.Domain.Entities;
using TMPPP.DTOs;

namespace TMPPP.Factories;

public abstract class AthleteCreator
{
    public void SomeOperation(AthleteCreatorDTO dto)
    {
        var athlete = CreateAthlete(dto);
        athlete.Train();
    }
    public abstract Athlete CreateAthlete(AthleteCreatorDTO dto);
}