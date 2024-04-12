namespace backend.Common.Models;

public class InvestmentRequest
{
    public string Fund { get; set; }
    public decimal Amount { get; set; }
    public string PaymentId { get; set; }
}


public class InvestmentResponse
{
    public bool Success { get; set; }
    public InvestmentData Data { get; set; }
}

public class InvestmentData
{
    public string Id { get; set; }
    public string Fund { get; set; }
    public decimal Amount { get; set; }
    public int Units { get; set; }
    public decimal PricePerUnit { get; set; }
    public string Status { get; set; }
    public string PaymentId { get; set; }
    public string SubmittedAt { get; set; }
    public string SucceededAt { get; set; }
    public string FailedAt { get; set; }
}

public class FundValue
{
    public string Name { get; set; }
    public decimal MarketValue { get; set; }
}


public class InvestmentDetails
{
    public string Id { get; set; }
    public string Fund { get; set; }
    public decimal Amount { get; set; }
    public decimal Units { get; set; }
    public decimal PricePerUnit { get; set; }
    public string Status { get; set; }
    public string PaymentId { get; set; }
    public DateTime SubmittedAt { get; set; }
    public DateTime SucceededAt { get; set; }
    public DateTime? FailedAt { get; set; } // Nullable DateTime to handle potential null value for failedAt
}
