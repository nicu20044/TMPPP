using TMPPP.Builders.Interfaces;
using TMPPP.Domain.Entities;
using TMPPP.DTOs;
using TMPPP.Factories;

namespace TMPPP.Builders;

    public class ProfessionalAthleteBuilder : IAthleteBuilder
    {
        private AthleteCreatorDTO _dto = new();
        private readonly ISportsFactory _factory;

        public ProfessionalAthleteBuilder(ISportsFactory factory) => _factory = factory;

        public void Reset() 
        {
            _dto = new AthleteCreatorDTO();
            _dto.MedicalStatus = "Apt"; 
        }
        public IAthleteBuilder SetName(string name) { _dto.Name = name; return this; }
        public IAthleteBuilder SetSport(string sport) { _dto.SportType = sport; return this; }

        public IAthleteBuilder SetRanking(int ranking) { _dto.Ranking = ranking; return this; }
        
        public IAthleteBuilder SetEmail(string email) {
            _dto.Email = email;
            return this;
        }

        public IAthleteBuilder SetMedicalStatus(string medicalStatus)
        {
            _dto.MedicalStatus = medicalStatus;
            return this;
        }

        public Athlete Build() => _factory.CreateAthlete(_dto);
    }
    