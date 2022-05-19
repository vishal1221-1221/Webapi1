using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace microservice2.Database.Entity
{
    public class AdminModel
    {
 
        public string UserFirstName { get; set; }
        public string UserMiddleName { get; set; }
        public string UserLastName { get; set; }
        public string Address { get; set; }
        public string EmailId { get; set; }
        public string UniQueHousNo { get; set; }
        public string PhoneNo { get; set; }
      


        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

    }
}
