using Shouldly;
using MortgageCalculatorLogic;
using System.Text.Json;
using Xunit.Abstractions;
namespace TestMortgageCalculatorLogic;

public class TestMortgageCalculations
{
    private readonly ITestOutputHelper _output;
    public TestMortgageCalculations(ITestOutputHelper output)
    {
        _output = output;
    }
    [Fact]
    public void MortgageCase1()
    {
        var calc = new MortgageCalculations();

        var input = new MortgageCalculationInput
        {
            CustomerIncome = 250000m,
            PurchasePrice = 350000m,
            HomeMarketValue = 339500m,
            DownPayment = 45000m,
            TermLength = 30,
            PaymentsPerYear = 12,
            YearlyHOA = 500m
        };

        var r = calc.Calculate(input);

        r.LoanAmount.ShouldBe(305000m);
        r.Principal.ShouldBe(310550m);  // loan + origination + 2500
        r.DayOneEquityAmount.ShouldBe(28950m);
        r.DayOneEquityPercentage.ShouldBe(0.0853m, 0.001m);

        r.MonthlyMortgage.ShouldBe(1912.11m, 0.01m);
        r.MonthlyHomeInsurance.ShouldBe(212.1875m, 0.01m);
        r.MonthlyMortgageInsurance.ShouldBe(258.79m, 0.01m);
        r.MonthlyHOA.ShouldBe(41.67m, 0.01m);
        r.MonthlyPropTax.ShouldBe(353.6458333m, 0.01m);
        r.TotalMonthlyPayment.ShouldBe(2778.403333m, 0.01m);

        r.Approved.ShouldBeTrue();
    }
    [Fact]
    public void MortgageCase2()
    {
        var calc = new MortgageCalculations();

        var input = new MortgageCalculationInput
        {
            CustomerIncome = 75000m,
            PurchasePrice = 100000m,
            HomeMarketValue = 105200m,
            DownPayment = 2750m,
            TermLength = 30,
            PaymentsPerYear = 12,
            YearlyHOA = 200m
        };

        var r = calc.Calculate(input);

        r.LoanAmount.ShouldBe(97250m);
        r.Principal.ShouldBe(100722.5m);
        r.DayOneEquityAmount.ShouldBe(4477.5m);
        r.DayOneEquityPercentage.ShouldBe(0.0426m, 0.001m);

        r.MonthlyMortgage.ShouldBe(478.41m, 0.01m);
        r.MonthlyHomeInsurance.ShouldBe(65.75m, 0.01m);
        r.MonthlyMortgageInsurance.ShouldBe(83.94m, 0.01m);
        r.MonthlyHOA.ShouldBe(16.67m, 0.01m);
        r.MonthlyPropTax.ShouldBe(109.5833333m, 0.01m);
        r.TotalMonthlyPayment.ShouldBe(754.3533333m, 0.01m);

        r.Approved.ShouldBeTrue();
    }
    [Fact]
    public void MortgageCase3()
    {
        var calc = new MortgageCalculations();

        var input = new MortgageCalculationInput
        {
            CustomerIncome = 175000m,
            PurchasePrice = 687999m,
            HomeMarketValue = 676500m,
            DownPayment = 50000m,
            TermLength = 30,
            PaymentsPerYear = 12,
            YearlyHOA = 0m
        };

        var r = calc.Calculate(input);

        r.LoanAmount.ShouldBe(637999m);
        r.Principal.ShouldBe(646878.99m);
        r.DayOneEquityAmount.ShouldBe(29621.01m);
        r.DayOneEquityPercentage.ShouldBe(0.04378567627m, 0.001m);

        r.MonthlyMortgage.ShouldBe(3572.09m, 0.01m);
        r.MonthlyHomeInsurance.ShouldBe(422.8125m, 0.01m);
        r.MonthlyMortgageInsurance.ShouldBe(539.07m, 0.01m);
        r.MonthlyHOA.ShouldBe(0m);
        r.MonthlyPropTax.ShouldBe(704.6875m, 0.01m);
        r.TotalMonthlyPayment.ShouldBe(5238.66m, 0.01m);

        r.Approved.ShouldBeFalse();
    }
    [Fact]
    public void MortgageCase4()
    {
        var calc = new MortgageCalculations();

        var input = new MortgageCalculationInput
        {
            CustomerIncome = 100000m,
            PurchasePrice = 200000m,
            HomeMarketValue = 200000m,
            DownPayment = 20000m,
            TermLength = 30,
            PaymentsPerYear = 12,
            YearlyHOA = 150m
        };

        var r = calc.Calculate(input);

        r.LoanAmount.ShouldBe(180000m);
        r.Principal.ShouldBe(184300m);
        r.DayOneEquityAmount.ShouldBe(15700m);
        r.DayOneEquityPercentage.ShouldBe(0.0785m, 0.001m);

        r.MonthlyMortgage.ShouldBe(1104.97m, 0.01m);
        r.MonthlyHomeInsurance.ShouldBe(125m, 0.01m);
        r.MonthlyMortgageInsurance.ShouldBe(153.58m, 0.01m);
        r.MonthlyHOA.ShouldBe(12.5m, 0.01m);
        r.MonthlyPropTax.ShouldBe(208.3333333m, 0.01m);
        r.TotalMonthlyPayment.ShouldBe(1604.383333m, 0.01m);

        r.Approved.ShouldBeTrue();
    }

    [Fact]
    public void Test_30YearLoan_NoPMI_Approved()
    {
        var mcl = new MortgageCalculations();
        var input = new MortgageCalculationInput()
        {
            PurchasePrice = 800_000m,
            DownPayment = 160_000m,
            TermLength = 30,
            HomeMarketValue = 800_000m,
            CustomerIncome = 15_000m,
            YearlyHOA = 0m
        };

        var result = mcl.Calculate(input);

        _output.WriteLine(JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true }));

        result.MonthlyMortgageInsurance.ShouldBe(0m);
        result.Approved.ShouldBeFalse();
        result.TotalMonthlyPayment.ShouldBeGreaterThan(0m);
    }
    [Fact]
    public void Test_PMI_Required_When_Equity_Under_10Percent()
    {
        var mcl = new MortgageCalculations();
        var input = new MortgageCalculationInput()
        {
            PurchasePrice = 400_000m,
            DownPayment = 10_000m,
            TermLength = 30,
            HomeMarketValue = 400_000m,
            CustomerIncome = 8_000m,
            YearlyHOA = 0m
        };

        var result = mcl.Calculate(input);

        result.MonthlyMortgageInsurance.ShouldBeGreaterThan(0m);
        result.DayOneEquityPercentage.ShouldBeLessThan(0.10m);
    }
    [Fact]
    public void Test_DenyLoan_WhenPaymentTooHigh()
    {
        var mcl = new MortgageCalculations();
        var input = new MortgageCalculationInput()
        {
            PurchasePrice = 900_000m,
            DownPayment = 100_000m,
            TermLength = 30,
            HomeMarketValue = 900_000m,
            CustomerIncome = 6_000m,
            YearlyHOA = 1_200m
        };

        var result = mcl.Calculate(input);

        result.Approved.ShouldBeFalse();
        result.TotalMonthlyPayment.ShouldBeGreaterThanOrEqualTo(0.25m * input.CustomerIncome);
    }
    [Fact]
    public void Test_CalculatesHOA_Insurance_Taxes_Correctly()
    {
        var mcl = new MortgageCalculations();
        var input = new MortgageCalculationInput()
        {
            PurchasePrice = 300_000m,
            DownPayment = 60_000m,
            TermLength = 30,
            HomeMarketValue = 300_000m,
            CustomerIncome = 6_000m,
            YearlyHOA = 2_400m
        };

        var result = mcl.Calculate(input);

        result.MonthlyHOA.ShouldBe(200m);
        result.MonthlyHomeInsurance.ShouldBe(0.0075m * 300_000m / 12m);
        result.MonthlyPropTax.ShouldBe(0.0125m * 300_000m / 12m);
        result.MonthlyMortgage.ShouldBeGreaterThan(0m);
    }
    [Fact]
    public void Test_15YearLoan_HasHigherMonthlyPayment()
    {
        var mcl = new MortgageCalculations();

        var input15 = new MortgageCalculationInput()
        {
            PurchasePrice = 500_000m,
            DownPayment = 100_000m,
            TermLength = 15,
            HomeMarketValue = 500_000m,
            CustomerIncome = 12_000m,
            YearlyHOA = 0m
        };

        var input30 = input15 with { TermLength = 30 };

        var result15 = mcl.Calculate(input15);
        var result30 = mcl.Calculate(input30);

        result15.MonthlyMortgage.ShouldBeGreaterThan(result30.MonthlyMortgage);
    }
    [Fact]
    public void Test_EquityCalculation_IsCorrect()
    {
        var mcl = new MortgageCalculations();
        var input = new MortgageCalculationInput()
        {
            PurchasePrice = 600_000m,
            DownPayment = 120_000m,
            TermLength = 30,
            HomeMarketValue = 650_000m,
            CustomerIncome = 10_000m,
            YearlyHOA = 0m
        };

        var result = mcl.Calculate(input);

        var expectedEquity = input.DownPayment - input.PurchasePrice + input.HomeMarketValue;

        result.DayOneEquityAmount.ShouldBe(expectedEquity);
        result.DayOneEquityPercentage.ShouldBe(expectedEquity / input.HomeMarketValue);
    }
    [Fact]
    public void Test_HighHOA_StillComputesTotalPayment()
    {
        var mcl = new MortgageCalculations();
        var input = new MortgageCalculationInput()
        {
            PurchasePrice = 750_000m,
            DownPayment = 150_000m,
            TermLength = 30,
            HomeMarketValue = 750_000m,
            CustomerIncome = 12_000m,
            YearlyHOA = 12_000m
        };

        var result = mcl.Calculate(input);

        result.MonthlyHOA.ShouldBe(1000m);
        result.TotalMonthlyPayment.ShouldBeGreaterThan(1000m);
    }

}
