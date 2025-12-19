public class GravityBoots : GadgetBase
{
    public double _remainingPower { get; set; } = 100;
    public GravityBoots(string name) : base(name)
    {
    }
    public override string Activate()
    {
        if (_remainingPower >= 100)
        {
            _remainingPower -= 100;
            return "Watch me dangle from my gravity boots!";
        }
        else
        {
            return "Out of power!";
        }
    }
    public override void Deactivate()
    {
        System.Console.WriteLine("Thats enough of that...");
    }
    public override void Describe()
    {
        base.Describe();
    }

    public override double RemainingPower()
    {
        return _remainingPower;
    }
}