using TMPPP_lab1.Domain.Interfaces;

namespace TMPPP_lab1.Application.Services;

public class AthleteService
{
    private readonly IAthleteRepository _repository;

    public AthleteService(IAthleteRepository repository)
    {
        _repository = repository;
    }

    public void RegisterAthlete(Athlete athlete)
    {
        _repository.Add(athlete);
    }

    public void StartTraining(Guid athleteId)
    {
        var athlete = _repository.GetById(athleteId);
        athlete.Train();
    }
}