using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace etaxproject.Models
{
    public class Wtax
    {
        public int UniQueHousNo { get; set; }
        public int watertaxid { get; set; }
        public string paymentamount { get; set; }
        public DateTime fromdate { get; set; }
        public DateTime todate { get; set; }
    }
}