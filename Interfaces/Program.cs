using System.Runtime.InteropServices;

public class Program
{
    public static void Main(string[] args)
    {

        List<IGadget> myGadgets = new();
        myGadgets.Add(new LaserPointer("SuperPointer"));
        myGadgets.Add(new Drone("SharpShooterExtreme"));
        myGadgets.Add(new GravityBoots("SillyBoots"));
        myGadgets.Add(new LightSaber());

        string longName = "";
        while (true)
        {
            foreach (GadgetBase item in myGadgets)
            {
                Console.Clear();

                item.Describe();

                if (item.Name.Length > longName.Length)
                    longName = item.Name;

                System.Console.WriteLine("Would you like to activate this gadget? Y/N");
                string readResult = Console.ReadLine() ?? "";

                if (readResult.StartsWith("y", StringComparison.OrdinalIgnoreCase))
                {

                    Console.WriteLine(item.Activate());
                    Thread.Sleep(2000);
                    item.Deactivate();
                    Thread.Sleep(2000);
                }
            }

            Console.Clear();

            System.Console.WriteLine($"{longName} has the longest gadget name...");
        }
    }
}