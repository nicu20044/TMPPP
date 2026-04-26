namespace TMPPP.Decorator
{
    public interface IService
    {
        double CalculateCost();
        string GetInfo();
    }

    public class BaseSubscription : IService
    {
        public double CalculateCost() => 100.0;
        public string GetInfo() => "Abonament Standard";
    }

    public abstract class ExtraService : IService
    {
        protected IService _service;
        public ExtraService(IService s) => _service = s;
        public virtual double CalculateCost() => _service.CalculateCost();
        public virtual string GetInfo() => _service.GetInfo();
    }

    public class MassageDecorator : ExtraService
    {
        public MassageDecorator(IService s) : base(s) { }
        public override double CalculateCost() => base.CalculateCost() + 50.0;
        public override string GetInfo() => base.GetInfo() + " + Masaj Terapeutic";
    }
}
