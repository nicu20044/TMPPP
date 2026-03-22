namespace TMPPP.Domain.Entities;


public abstract class Athlete : User
{
    public string SportType { get; set; }
    public int? Ranking { get; private set; }


    protected Athlete(string name, string sportType)
        : base(name)
    {
        SportType = sportType;
    }

    public abstract void Train();

    public abstract Athlete Clone();
}