namespace TMPPP.Domain.Entities;

public abstract class Coach: User
{
    public string Specialization { get; private set; }
    public int YearsOfExperience { get; private set; }

    public Coach(string name, string specialization, int yearsOfExperience, string email)
        : base(name,email)
    {
        Specialization = specialization;
        YearsOfExperience = yearsOfExperience;
    }
}