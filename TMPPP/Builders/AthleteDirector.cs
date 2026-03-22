using TMPPP.Builders.Interfaces;

namespace TMPPP.Builders;

public class AthleteDirector
{
    private IAthleteBuilder _builder;

    public AthleteDirector(IAthleteBuilder builder)
    {
        _builder = builder;
    }

    public void ChangeBuilder(IAthleteBuilder builder) => _builder = builder;

    public void Make(string type, string name, string sport, int rank)
    {
        _builder.Reset();
        
        if (type == "pro")
        {
            _builder.SetName(name);
            _builder.SetSport(sport);
            _builder.SetRanking(rank);
        }
        else 
        {
            _builder.SetName(name);
            _builder.SetSport(sport);
        }
    }
}