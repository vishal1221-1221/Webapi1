using etaxproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace etaxproject.Controllers
{
    [System.Web.Http.RoutePrefix("Api/Elec")]
    public class ElectricController : ApiController
    {
        projecttEntities6 ec = new projecttEntities6();
        [System.Web.Http.Route("Electrical")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult userElec(elec hm)
        {

            var log2 = ec.Elecreadings.Where(x => x.UniQueHousNo.Equals(hm.UniQueHousNo)).FirstOrDefault();
            if (log2 == null)
            {
                return Ok(new { Status = "Invalid", Message = "Invalid User" });
            }
            else
            {
                return Ok(new { Status = "Success", Message = "Login Success", housedetail = log2 });
            }
        }
    }
}


    
