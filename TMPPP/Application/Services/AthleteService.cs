using TMPPP.Builders;
using TMPPP.Domain.Entities;
using TMPPP.Domain.Interfaces;
using TMPPP.DTOs;
using TMPPP.Factories;
using TMPPP.Infrastructure.Logging;

namespace TMPPP.Application.Services;

public class AthleteService
{
    private readonly IAthleteRepository _repository;
    private readonly ISportsFactory _factory;
    private readonly AppLogger _logger;



    public AthleteService(IAthleteRepository repository, ISportsFactory factory)
    {
        _repository = repository;
        _factory = factory;
        _logger = AppLogger.GetInstance();
    }

    public Athlete RegisterAthlete(AthleteCreatorDTO dto)
    {
        var builder = new AmateurAthleteBuilder(_factory);
        var director = new AthleteDirector(builder);
        director.Make("pro", dto.Name, dto.SportType,dto.Ranking);
        var athlete = builder.Build();

        _logger.Log($"Pro athlete created via Director: {athlete.Name}");
        _repository.Add(athlete);
        
        _logger.Log($"Athlete saved with ID: {athlete.Id}");
        return athlete;
    }

    public void StartTraining(Guid athleteId)
    {
        var athlete = _repository.GetById(athleteId);

        if (athlete == null)
        {
            _logger.Log($"ERROR: Athlete {athleteId} not found");
            return;
        }

        athlete.Train();

        _logger.Log($"Training started for athlete {athleteId}");
    }
}