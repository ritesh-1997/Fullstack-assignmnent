using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Common.Models
{
    public class UserTBL
    {
        [Key]
        public string phoneNumber { get; set; }
    }
}