using TMPPP.Domain.Entities;
using TMPPP.DTOs;

namespace TMPPP.Factories;

public class ProfessionalAthleteCreator : AthleteCreator
{
    public override Athlete CreateAthlete(AthleteCreatorDTO dto)
    {
        return new ProfessionalAthlete(
            dto.Name,
            dto.SportType,
            dto.Ranking);
    }
}
