namespace TMPPP.Domain.Interfaces;

public interface ITrainingComponent
{
    string GetName();
    int GetTotalDuration();
    void Execute();
    void Display(int depth = 0);
}
