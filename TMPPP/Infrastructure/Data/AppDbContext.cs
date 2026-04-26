using Microsoft.EntityFrameworkCore;
using TMPPP.Domain.Entities;

namespace TMPPP.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options)
        : DbContext(options)
    {
        // Tabelele bazei de date
        // Gestiune Utilizatori și Ierarhie (User, Athlete, Coach)
        public DbSet<User> Users { get; set; }
        public DbSet<Athlete> Athletes { get; set; }
        public DbSet<Coach> Coaches { get; set; }

        // Componente Antrenament
        public DbSet<TrainingPlan> TrainingPlans { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<TrainingExercise> TrainingExercises { get; set; } // Tabela de legătură sau entitate specifică
    
        // Organizare și Statistici
        public DbSet<TrainingGroup> TrainingGroups { get; set; }
        public DbSet<AthleteStatistics> AthleteStatistics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Athlete>().ToTable("Athletes");
            modelBuilder.Entity<Coach>().ToTable("Coaches");
            
            modelBuilder.Entity<AmateurAthlete>().ToTable("AmateurAthletes");
            modelBuilder.Entity<ProfessionalAthlete>().ToTable("ProfessionalAthletes");
            modelBuilder.Entity<AmateurCoach>().ToTable("AmateurCoaches");
            modelBuilder.Entity<ProfessionalCoach>().ToTable("ProfessionalCoaches");
            
            
            // Configurare adițională pentru bani
            modelBuilder.Entity<Athlete>()
                .Property(a => a.SubscriptionBalance)
                .HasPrecision(18, 2);
            
            modelBuilder.Entity<AthleteStatistics>()
                .HasOne<Athlete>()
                .WithOne()
                .HasForeignKey<AthleteStatistics>(s => s.AthleteId);

            base.OnModelCreating(modelBuilder);
        }
    }
}