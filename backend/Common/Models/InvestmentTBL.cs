using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Common.Models
{
    public class InvestmentTBL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int investmentId { get; set; }
        public string phoneNumber { get; set; }
        public int strategyId { get; set; }
        public string investmentName { get; set; }
        public int paymentid { get; set; }
    }
}