namespace TMPPP.Domain.Entities;

public class ProfessionalAthlete : Athlete
{
    public int Ranking { get; private set; }

    public ProfessionalAthlete(string name, string sportType, int ranking, string medicalStatus,string email)
        : base(name, sportType,medicalStatus,email)
    {
        Ranking = ranking;
    }

    protected ProfessionalAthlete() : base() { }//ef
    public override void Train()
    {
        Console.WriteLine("Professional training session.");
    }

    public override Athlete Clone()
    {
        return new ProfessionalAthlete(this.Name, this.SportType, this.Ranking, this.MedicalStatus,this.Email);
    }
}
