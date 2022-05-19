using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace etaxproject.Models
{
    public class htax
    {
        public int UniQueHousNo { get; set; }
        public int MunicipaliltyTaxPaymentId { get; set; }
        public string PaymentAmount { get; set; }
        public DateTime fromdate { get; set; }
        public DateTime todate { get; set; }
    }
}