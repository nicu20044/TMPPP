namespace TMPPP.Domain.Entities;


public abstract class Athlete : User
{
    public string SportType { get; set; }
    public string MedicalStatus { get; set; }
    public decimal SubscriptionBalance { get; set; }


    protected Athlete(string name, string sportType, string medicalStatus,string email)
        : base(name,email)
    {
        SportType = sportType;
        MedicalStatus = medicalStatus;
    }
    protected Athlete() : base() { }//ef
    public abstract void Train();

    public abstract Athlete Clone();
}