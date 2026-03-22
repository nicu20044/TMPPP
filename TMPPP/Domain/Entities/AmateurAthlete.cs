namespace TMPPP.Domain.Entities;

public class AmateurAthlete : Athlete
{
    public string SportType { get; set; }
    public AmateurAthlete(string name, string sportType)
        : base(name, sportType) {}

    public override void Train()
    {
        Console.WriteLine("Amateur training session.");
    }

    public override Athlete Clone()
    {
        return new AmateurAthlete(this.Name, this.SportType);
    }
}
