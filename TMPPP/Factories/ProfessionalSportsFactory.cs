using TMPPP.Domain.Entities;
using TMPPP.DTOs;

namespace TMPPP.Factories;

public class ProfessionalSportsFactory : ISportsFactory
{
    public Athlete CreateAthlete(AthleteCreatorDTO dto)
        => new ProfessionalAthlete(dto.Name, dto.SportType, dto.Ranking);

    public Coach CreateCoach(CoachCreatorDTO coachDto)
        => new ProfessionalCoach(coachDto.Name, coachDto.Specialization, coachDto.YearsOfExperience);
}