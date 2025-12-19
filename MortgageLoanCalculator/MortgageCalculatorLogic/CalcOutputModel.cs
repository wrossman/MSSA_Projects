public record MortgageCalculationOutput
{
    public decimal InterestRate { get; set; }
    public decimal MonthlyMortgage { get; set; }
    public decimal LoanAmount { get; set; }
    public decimal Principal { get; set; }
    public decimal DayOneEquityAmount { get; set; }
    public decimal DayOneEquityPercentage { get; set; }
    public decimal MonthlyMortgageInsurance { get; set; }
    public decimal ReqDownPaymentIncrease { get; set; }
    public decimal MonthlyHOA { get; set; }
    public decimal MonthlyHomeInsurance { get; set; }
    public decimal MonthlyPropTax { get; set; }
    public decimal TotalMonthlyPayment { get; set; }
    public bool Approved { get; set; }
}