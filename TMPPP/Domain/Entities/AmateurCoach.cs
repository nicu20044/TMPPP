namespace TMPPP.Domain.Entities;

public class AmateurCoach : Coach
{
    public string Specialization { get; private set; }
    public int YearsOfExperience { get; private set; }

    public AmateurCoach(string name, string specialization, int yearsOfExperience)
        : base(name, specialization, yearsOfExperience)
    {
        Specialization = specialization;
        YearsOfExperience = yearsOfExperience;
    }
}