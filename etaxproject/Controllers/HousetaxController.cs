using etaxproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace etaxproject.Controllers
{
    [System.Web.Http.RoutePrefix("Api/HTax")]
    public class HousetaxController : ApiController
    {
        // GET: Electax
        projecttEntities8 DB = new projecttEntities8();
        [System.Web.Http.Route("InsertHtax")]
        [System.Web.Http.HttpPost]

        public object InsertEtax(htax ht)
        {

            try

            {


                MuniTax EL = new MuniTax();
                if (EL.UniQueHousNo == 0)
                {

                    EL.UniQueHousNo = ht.UniQueHousNo;

                    EL.MunicipaliltyTaxPaymentId = ht.MunicipaliltyTaxPaymentId;

                    EL.PaymentAmount = ht.PaymentAmount;

                    EL.fromdate = ht.fromdate;

                    EL.todate = ht.todate;

                   


                    DB.MuniTaxes.Add(EL);

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