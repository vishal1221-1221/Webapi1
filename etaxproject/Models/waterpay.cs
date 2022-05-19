using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace etaxproject.Models
{
    public class waterpay
    {

        public int UniQueHousNo { get; set; }
        public int watertaxid { get; set; }
        public DateTime fromdate { get; set; }
        public DateTime todate { get; set; }
        public string paymentamount { get; set; }
        public string cardno { get; set; }
        public string cvv { get; set; }
        public string status { get; set; }

    }
}