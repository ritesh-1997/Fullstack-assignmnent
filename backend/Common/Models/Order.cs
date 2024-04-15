namespace backend.Common.Models;

public class InvestmentRequest
{
    public string Fund { get; set; }
    public double Amount { get; set; }
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
    public int Amount { get; set; }
    public int Units { get; set; }
    public double PricePerUnit { get; set; }
    public string Status { get; set; }
    public string PaymentId { get; set; }
    public string SubmittedAt { get; set; }
    public string SucceededAt { get; set; }
    public string FailedAt { get; set; }
}

public class FundValue
{
    public string Name { get; set; }
    public double marketValue { get; set; }
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

public class HoldingsRequest
{
    public string phoneNumber { get; set; }
    public string strategyName { get; set; }
}

public class UserHolidings
{
    public UserHolidings()
    {
        data = new List<HoldingsResponse>();
    }
    public string phoneNumber { get; set; }
    public List<HoldingsResponse> data { get; set; }
}

public class HoldingsResponse
{
    public HoldingsResponse()
    {
        holdingDetails = new List<HoldingDetails>();
    }
    public string strategyName { get; set; }
    public double investmentAmount { get; set; }
    public double investmentMarketValue { get; set; }
    public List<HoldingDetails> holdingDetails { get; set; }
}

public class HoldingDetails
{
    public string fundName { get; set; }
    public double investmentAmount { get; set; }
    public double marketValue { get; set; }
}