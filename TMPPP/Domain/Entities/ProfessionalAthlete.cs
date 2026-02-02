namespace TMPPP_lab1;

public class ProfessionalAthlete : Athlete
{
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
}
