namespace MortgageCalculatorLogic;

public class MortgageCalculations
{
    public void CalculateMortgage()
    {

        MortgageCalculationInput input = GetInput();
        MortgageCalculationOutput output = Calculate(input);

        if (!output.Approved)
        {
            Console.WriteLine("Customer has been denied the loan due to insufficient income.");
            System.Console.WriteLine("Recommend the customer places more money down or look at more affordable options.");
        }
        else
            System.Console.WriteLine("Recommend Approving Customer for loan.");

        System.Console.WriteLine($"Monthly payment = {output.TotalMonthlyPayment:C2}");

    }

    public MortgageCalculationOutput Calculate(MortgageCalculationInput input)
    {
        MortgageCalculationOutput output = new();

        output.MonthlyHOA = input.YearlyHOA / 12;
        output.MonthlyHomeInsurance = 0.0075m * input.HomeMarketValue / 12m;
        output.MonthlyPropTax = 0.0125m * input.HomeMarketValue / 12m;

        if (input.TermLength == 15)
            output.InterestRate = 0.0525m;
        else if (input.TermLength == 30)
            output.InterestRate = 0.0625m;

        output.LoanAmount = input.PurchasePrice - input.DownPayment;

        output.Principal = (input.PurchasePrice - input.DownPayment) * 1.01m + 2500;

        output.DayOneEquityAmount = input.DownPayment - input.PurchasePrice + input.HomeMarketValue;
        // output.DayOneEquityAmount = (input.HomeMarketValue - output.LoanAmount) / input.HomeMarketValue * 100;

        output.DayOneEquityPercentage = output.DayOneEquityAmount / input.HomeMarketValue;

        if (output.DayOneEquityAmount < 0.10m * input.HomeMarketValue)
        {
            output.MonthlyMortgageInsurance = output.Principal * 0.01m / 12;
            output.ReqDownPaymentIncrease = 0.10m * input.HomeMarketValue - output.DayOneEquityAmount;
        }


        decimal numerator =
            output.Principal * output.InterestRate / input.PaymentsPerYear *
            (decimal)Math.Pow((double)(1 + output.InterestRate / input.PaymentsPerYear), input.PaymentsPerYear * input.TermLength);

        decimal denominator =
            (decimal)Math.Pow((double)(1 + output.InterestRate / input.PaymentsPerYear), input.PaymentsPerYear * input.TermLength) - 1;

        output.MonthlyMortgage = numerator / denominator;

        output.TotalMonthlyPayment = output.MonthlyHOA + output.MonthlyMortgageInsurance + output.MonthlyHomeInsurance + output.MonthlyPropTax + output.MonthlyMortgage;

        if (output.TotalMonthlyPayment > .25m * input.CustomerIncome)
            output.Approved = false;
        else
            output.Approved = true;

        return output;
    }

    public MortgageCalculationInput GetInput()
    {
        MortgageCalculationInput input = new();

        System.Console.WriteLine("Please enter the home purchase price.");
        input.PurchasePrice = Helpers.InputDecimal();

        System.Console.WriteLine("Please enter the Term Length as 15 or 30.");
        input.TermLength = Helpers.InputInt();
        while (!(input.TermLength == 15 ^ input.TermLength == 30))
        {
            System.Console.WriteLine("Please enter either 15 or 30");
            input.TermLength = Helpers.InputInt();
        }

        System.Console.WriteLine("Please enter the Down Payment.");
        input.DownPayment = Helpers.InputDecimal();

        System.Console.WriteLine("Please enter the home market value.");
        decimal homeValue = Helpers.InputDecimal();
        while (homeValue <= 0)
        {
            System.Console.WriteLine("Please enter a number greater than 0.");
            homeValue = Helpers.InputDecimal();
        }
        input.HomeMarketValue = homeValue;

        System.Console.WriteLine("Please enter the customer income.");
        input.CustomerIncome = Helpers.InputDecimal();

        System.Console.WriteLine("Please enter the Yearly HOA fee.");
        input.YearlyHOA = Helpers.InputDecimal();

        return input;
    }
}
