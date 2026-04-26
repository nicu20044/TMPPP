using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TMPPP.Domain.Entities;
using TMPPP.Infrastructure.Data;

namespace TMPPP.Controllers
{
    public class TrainingPlansController : Controller
    {
        private readonly AppDbContext _context;

        public TrainingPlansController(AppDbContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            var plans = await _context.TrainingPlans.ToListAsync();
            return View(plans);
        }

        [HttpPost]
        public async Task<IActionResult> Clone(Guid id)
        {
            var original = await _context.TrainingPlans.FindAsync(id);
            if (original == null) return NotFound();

            // PATTERN: PROTOTYPE
            // Folosim metoda Clone() definită în entitatea ta
            var clone = (TrainingPlan)original.Clone();
            
            // Ajustăm proprietățile pentru a fi o entitate nouă în DB
            clone.Id = Guid.NewGuid();
            clone.Name += " (Copie)";

            _context.TrainingPlans.Add(clone);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}