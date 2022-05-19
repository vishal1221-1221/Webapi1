using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace etaxproject.Models
{
    public class HousesMaster
    {
        public int UniQueHousNo { get; set; }
        public string OwnerName { get; set; }
        public string TelephoneNo { get; set; }
        public string Email { get; set; }
        public string ActualHouseNo { get; set; }
        public DateTime HouseRegistrationdate { get; set; }
        public int AreaId{ get; set; }
        public int StreetId { get; set; }

        public int PlotId { get; set; }
      
        public int BuildingApprovalNo { get; set; }
    }
}