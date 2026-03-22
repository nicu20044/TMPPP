namespace TMPPP.Domain.Interfaces;

public interface IPrototype
{
    string GetName();
    IPrototype Clone();
}