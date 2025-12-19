public class LightSaber : GadgetBase
{
    public string Color { get; set; }
    public LightSaber(string name, string color, string status) : base(name, status)
    {
        Color = color;
    }
    public override double RemainingPower()
    {
        return 100.0;
    }
}