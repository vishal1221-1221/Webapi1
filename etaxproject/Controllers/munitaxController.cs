using etaxproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace etaxproject.Controllers
{
    [System.Web.Http.RoutePrefix("Api/Muni")]
    public class munitaxController : ApiController
    {
        projecttEntities8 udb = new projecttEntities8();
        [System.Web.Http.Route("MuniTax")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult userMuni(UserID hm)
        {

            var log1 = udb.MuniTaxes.Where(x => x.UniQueHousNo.Equals(hm.UniQueHousNo)).FirstOrDefault();
            if (log1 == null)
            {
                return Ok(new { Status = "Invalid", Message = "Invalid User" });
            }
            else
            {
                return Ok(new { Status = "Success", Message = "Login Success", housedetail = log1 });
            }
        }


    }
}