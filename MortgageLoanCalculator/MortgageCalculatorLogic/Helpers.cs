public class Helpers
{
    public static decimal InputDecimal()
    {
        decimal output;
        while (!decimal.TryParse(Console.ReadLine(), out output)) ;
        return output;
    }
    public static int InputInt()
    {
        int output;
        while (!int.TryParse(Console.ReadLine(), out output)) ;
        return output;
    }
}