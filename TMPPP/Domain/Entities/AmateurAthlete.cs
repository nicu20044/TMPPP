namespace TMPPP.Domain.Entities;

public class AmateurAthlete : Athlete
{
    public AmateurAthlete(string name, string sportType, string medicalStatus,string email)
        : base(name, sportType, medicalStatus, email)
    {}

    private AmateurAthlete(string sportType) : base()
    {
        SportType = sportType;
    }//ef
    public override void Train()
    {
        Console.WriteLine("Amateur training session.");
    }

    public override Athlete Clone()
    {
        return new AmateurAthlete(this.Name, this.SportType, this.MedicalStatus,this.Email);
    }
}
