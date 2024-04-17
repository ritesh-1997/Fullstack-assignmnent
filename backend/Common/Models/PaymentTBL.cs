using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Common.Models
{
    public class PaymentTBL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int transactionId { get; set; }
        public double amount { get; set; }
        public DateTime createdDate { get; set; } = DateTime.UtcNow;
        public DateTime updatedDate { get; set; } = DateTime.UtcNow;
        public bool status { get; set; }
        public string paymentid { get; set; }
        public string phoneNumber { get; set; }
        public string strategyName { get; set; }
        public string utr { get; set; }
        public bool isTried { get; set; } = false;


    }
}