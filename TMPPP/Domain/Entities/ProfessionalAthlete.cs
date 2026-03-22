namespace TMPPP.Domain.Entities;

public class ProfessionalAthlete : Athlete
{
    public string SportType { get; set; }
    public int Ranking { get; private set; }

    public ProfessionalAthlete(string name, string sportType, int ranking)
        : base(name, sportType)
    {
        Ranking = ranking;
    }

    public override void Train()
    {
        Console.WriteLine("Professional training session.");
    }

    public override Athlete Clone()
    {
        return new ProfessionalAthlete(this.Name, this.SportType, this.Ranking);
    }
}
