using TMPPP.Domain.Entities;

namespace TMPPP.Bridge
{
    public class HighPerformanceCenter : ITrainingVenue
    {
        public string GetRequirements() => "Echipament profesional, Monitorizare cardiaca.";
        public double GetIntensityMultiplier() => 1.5;
    }

    public class LocalPark : ITrainingVenue
    {
        public string GetRequirements() => "Haine lejere, GPS activat.";
        public double GetIntensityMultiplier() => 0.8;
    }

    // Abstraction
    public abstract class WorkoutSession
    {
        protected ITrainingVenue _venue;
        protected TrainingPlan _plan;

        public WorkoutSession(TrainingPlan plan, ITrainingVenue venue)
        {
            _plan = plan;
            _venue = venue;
        }

        public abstract string Execute();
    }

    public class EnduranceSession : WorkoutSession
    {
        public EnduranceSession(TrainingPlan p, ITrainingVenue v) : base(p, v)
        {
        }

        public override string Execute() =>
            $"Executie Plan: {_plan.Name}. Cerinte: {_venue.GetRequirements()}. Multiplicator intensitate: {_venue.GetIntensityMultiplier()}";
    }
}