namespace TMPPP.Domain.Entities;

public class ProfessionalCoach : Coach
{
    public string Specialization { get; private set; }
    public int YearsOfExperience { get; private set; }

    public ProfessionalCoach(string name, string specialization, int yearsOfExperience)
        : base(name, specialization, yearsOfExperience)
    {
        Specialization = specialization;
        YearsOfExperience = yearsOfExperience;
    }
}