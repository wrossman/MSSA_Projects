public abstract class GadgetBase : IGadget
{
    public string Name { get; set; } = "";
    public string Status { get; set; } = "";
    public GadgetBase(string name)
    {
        Name = name;
    }
    public GadgetBase(string name, string status)
    {
        Name = name;
        Status = status;
    }

    public virtual string Activate()
    {
        Status = "Activated";
        return $"{Name} has been activiated.";
    }

    public virtual void Deactivate()
    {
        Status = "Deactivated";
        System.Console.WriteLine($"{Name} has been deactivated.");
    }
    public virtual void Describe()
    {
        System.Console.WriteLine($"This is my {Name} gadget.");
    }
    public abstract double RemainingPower();
}