using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Common.Models
{
    public class PaymentRequest
    {
        public string AccountNumber { get; set; }
        public string IfscCode { get; set; }
        public int Amount { get; set; }
        public string RedirectUrl { get; set; }
    }

    public class PaymentResponse
    {
        public string PaymentLink { get; set; }
        public bool Success { get; set; }
    }


    public class PaymentIdResponse
    {
        public string Id { get; set; }
        public string AccountNumber { get; set; }
        public string IfscCode { get; set; }
        public decimal Amount { get; set; }
        public string RedirectUrl { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Utr { get; set; }
    }


}