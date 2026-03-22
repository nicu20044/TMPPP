using TMPPP.Domain.Entities;
using TMPPP.DTOs;

namespace TMPPP.Factories;

public class AmateurSportsFactory : ISportsFactory
{
    public Athlete CreateAthlete(AthleteCreatorDTO dto)
        => new AmateurAthlete(dto.Name, dto.SportType);

    public Coach CreateCoach(CoachCreatorDTO coachDto)
        => new AmateurCoach(coachDto.Name, coachDto.Specialization, coachDto.YearsOfExperience);
}