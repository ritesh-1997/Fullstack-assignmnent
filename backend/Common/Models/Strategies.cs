using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Common.Models
{
    public class Strategy
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public List<Fund> Funds { get; set; }
    }

    public class Fund
    {
        public string Name { get; set; }
        public double Percentage { get; set; }
        public double Value { get; set; }
    }

}