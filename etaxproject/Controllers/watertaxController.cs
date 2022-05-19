using etaxproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace etaxproject.Controllers
{
    [System.Web.Http.RoutePrefix("Api/Water")]
    public class watertaxController : ApiController
    {
        projecttEntities10 wt = new projecttEntities10();
        [System.Web.Http.Route("Watertax")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult userWater(elec hm)
        {

            var log2 = wt.watertaxes.Where(x => x.UniQueHousNo.Equals(hm.UniQueHousNo)).FirstOrDefault();
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



