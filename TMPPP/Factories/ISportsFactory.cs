using TMPPP.Domain.Entities;
using TMPPP.DTOs;

namespace TMPPP.Factories;

public interface ISportsFactory
{
    Athlete CreateAthlete(AthleteCreatorDTO dto);
    Coach CreateCoach(CoachCreatorDTO coachDto);
}