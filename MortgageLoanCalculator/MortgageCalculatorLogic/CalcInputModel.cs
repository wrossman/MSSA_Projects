public record MortgageCalculationInput
{
    public decimal PurchasePrice { get; set; }
    public int PaymentsPerYear { get; set; } = 12;
    public int TermLength { get; set; }
    public decimal DownPayment { get; set; }
    public decimal HomeMarketValue { get; set; }
    public decimal CustomerIncome { get; set; }
    public decimal YearlyHOA { get; set; }
    public int LoanTaxes { get; set; } = 2500;
}