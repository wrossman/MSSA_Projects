using MortgageCalculatorLogic;
namespace MortgageLoanCalculator;

public class Program
{
    public static void Main(string[] args)
    {
        bool again;
        do
        {
            var mcl = new MortgageCalculations();
            mcl.CalculateMortgage();

            System.Console.WriteLine("Would you like to calculate another loan? Yes / No");
            string readResult = Console.ReadLine() ?? "";
            if (readResult.StartsWith("y", StringComparison.OrdinalIgnoreCase))
                again = true;
            else
                again = false;

        } while (again);
    }
}
