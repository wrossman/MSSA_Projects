public class Drone : GadgetBase
{
    public double _remainingPower { get; set; } = 100;
    public Drone(string name) : base(name)
    {
    }
    public override string Activate()
    {
        if (_remainingPower >= 100)
        {
            _remainingPower -= 100;
            return "My drone is flying!";
        }
        else
        {
            return "Out of power!";
        }
    }
    public override void Deactivate()
    {
        System.Console.WriteLine("Drone returning to base...");
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