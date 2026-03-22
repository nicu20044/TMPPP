using TMPPP.Domain.Entities;
using TMPPP.DTOs;

namespace TMPPP.Factories;

public class AmateurAthleteCreator : AthleteCreator
{
    public override Athlete CreateAthlete(AthleteCreatorDTO dto)
    {
        return new AmateurAthlete(
            dto.Name,
            dto.SportType);
    }
}
