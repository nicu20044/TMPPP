namespace TMPPP_lab1.Domain.Entities;

public class Coach : User
{
    public string Specialization { get; private set; }
    public int YearsOfExperience { get; private set; }

    public Coach(string name, string specialization, int yearsOfExperience)
        : base(name)
    {
        Specialization = specialization;
        YearsOfExperience = yearsOfExperience;
    }
}