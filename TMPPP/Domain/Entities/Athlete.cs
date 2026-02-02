namespace TMPPP_lab1;


public abstract class Athlete : User
{
    public string SportType { get; set; }

    protected Athlete(string name, string sportType)
        : base(name)
    {
        SportType = sportType;
    }

    public abstract void Train();
}