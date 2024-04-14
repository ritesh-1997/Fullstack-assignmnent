using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Common.Models;

public class MutualFundOrderTBL
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int orderid { get; set; }
    public string orderGuid { get; set; }
    public string fundName { get; set; }
    public string paymentid { get; set; }
    public double amount { get; set; }
    public double units { get; set; }
    public bool status { get; set; }
    public double pricePerUnit { get; set; }
    public DateTime? succeededAt { get; set; }
    public DateTime? failedAt { get; set; }

    public DateTime createdDate { get; set; } = DateTime.UtcNow;
    public DateTime updatedDate { get; set; } = DateTime.UtcNow;

}