using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace etaxproject.Models
{
    public class Elecpay
    {
        public int UniQueHousNo { get; set; }
        public int electricalserviceno { get; set; }
        public int unitsconsumed { get; set; }
        public DateTime fromdate { get; set; }
        public DateTime todate { get; set; }
        public string billamount { get; set; }
        public int meterreading { get; set; }
        public string card { get; set; }
        public string cvv { get; set; }
        public string status { get; set; }


    }
}