using etaxproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace etaxproject.Controllers
{
    [System.Web.Http.RoutePrefix("Api/Wtax")]
    public class waterController : ApiController
    {
        // GET: Electax
        projecttEntities10 DB = new projecttEntities10();
        [System.Web.Http.Route("Insertwatertax")]
        [System.Web.Http.HttpPost]

        public object InsertEtax(Wtax wt)
        {

            try

            {
                

                watertax EL = new watertax();
                if (EL.UniQueHousNo == 0)
                {



                    EL.UniQueHousNo = wt.UniQueHousNo;
                    EL.watertaxid = wt.watertaxid;

                    EL.paymentamount = wt.paymentamount;

                    EL.fromdate = wt.fromdate;

                    EL.todate = wt.todate;




                    DB.watertaxes.Add(EL);

                    DB.SaveChanges();

                    return new Response

                    { Status = "Success", Message = "Record SuccessFully Saved." };

                }
            }

            catch (Exception)

            {


                throw;

            }

            return new Response

            { Status = "Error", Message = "Invalid Data." };

        }
    }
}