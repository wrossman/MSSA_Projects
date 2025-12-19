public class LaserPointer : GadgetBase
{
    public double _remainingPower { get; set; } = 100;
    public LaserPointer(string name) : base(name)
    {
    }
    public override string Activate()
    {
        if (_remainingPower >= 100)
        {
            _remainingPower -= 100;
            return "I am blasting you with my laser!";
        }
        else
        {
            return "Out of power!";
        }
    }
    public override void Deactivate()
    {
        System.Console.WriteLine("Powering down my laser...");
    }
    public override void Describe()
    {
        System.Console.WriteLine("LASER BEAMS!");
    }

    public override double RemainingPower()
    {
        return _remainingPower;
    }
}