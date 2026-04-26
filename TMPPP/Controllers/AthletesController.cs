using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TMPPP.Domain.Entities;
using TMPPP.Builders;
using TMPPP.Builders.Interfaces;
using TMPPP.DTOs;
using TMPPP.Factories;
using TMPPP.Infrastructure.Data;

namespace TMPPP.Controllers
{
    public class AthletesController : Controller
    {
        private readonly AppDbContext _context;

        public AthletesController(AppDbContext context) => _context = context;

        // Afișează lista (Index)
        public async Task<IActionResult> Index()
        {
            var athletes = await _context.Athletes.ToListAsync();
            return View(athletes);
        }

        // Afișează formularul de creare (Create)
        public IActionResult Create() => View();

        // --- ATHLETES CONTROLLER ---
// 1. Salvare prin FACTORY (Actualizat)
        [HttpPost]
        public async Task<IActionResult> CreateWithFactory(string name, string sportType, string level, int ranking, string medicalStatus, string email)
        {
            var dto = new AthleteCreatorDTO { 
                Name = name, SportType = sportType, Ranking = ranking, MedicalStatus = medicalStatus, Email = email 
            };

            AthleteCreator creator = level == "Professional" ? new ProfessionalAthleteCreator() : new AmateurAthleteCreator();
            Athlete newAthlete = creator.CreateAthlete(dto);

            // Setează proprietățile de bază (User/Athlete)
            // newAthlete.Email = email;
            // newAthlete.Name = name;

            _context.Athletes.Add(newAthlete);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

// 2. Salvare prin BUILDER (Actualizat)
        [HttpPost]
        public async Task<IActionResult> CreateWithBuilder(string name, string sportType, string level, int ranking, string email,string medicalStatus)
        {
            ISportsFactory sportsFactory = level == "Professional" ? new ProfessionalSportsFactory() : new AmateurSportsFactory();
            IAthleteBuilder builder = level == "Professional" ? new ProfessionalAthleteBuilder(sportsFactory) : new AmateurAthleteBuilder(sportsFactory);

            var newAthlete = builder
                .SetName(name)
                .SetSport(sportType)
                .SetEmail(email)
                .SetMedicalStatus(medicalStatus)
                .SetRanking(ranking)
                .Build();

            _context.Athletes.Add(newAthlete);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}