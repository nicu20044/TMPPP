namespace TMPPP_lab1;

public class AmateurAthlete : Athlete
{
    public AmateurAthlete(string name, string sportType)
        : base(name, sportType) {}

    public override void Train()
    {
        Console.WriteLine("Amateur training session.");
    }
}
