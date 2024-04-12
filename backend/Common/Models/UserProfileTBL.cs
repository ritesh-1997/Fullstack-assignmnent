using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Common.Models
{
    public class UserProfileTBL
    {
        [Key]
        public int profileId{ get; set; }
        public string phoneNumber { get; set; }
    }
}