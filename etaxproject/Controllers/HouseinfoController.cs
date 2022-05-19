using etaxproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace etaxproject.Controllers
{
    [System.Web.Http.RoutePrefix("Api/home")]
    public class HouseinfoController : ApiController
    {
        projecttEntities3 udb = new projecttEntities3();
        [System.Web.Http.Route("Home")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult userHome(UserID hm)
        {

            var log1 = udb.tbl_UserMaster.Where(x => x.UniQueHousNo.Equals(hm.UniQueHousNo)).FirstOrDefault();
            if (log1 == null)
            {
                return Ok(new { Status = "Invalid", Message = "Invalid User" });
            }
            else
            {
                return Ok(new { Status = "Success", Message = "Login Success",housedetail=log1});
            }
        }


    }
}