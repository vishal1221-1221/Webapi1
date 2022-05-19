using etaxproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
// for serialize and deserialize  
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using etaxproject.Interface;

namespace etaxproject.Controllers

{


    
    
    [System.Web.Http.RoutePrefix("Api/login")]
    public class LoginnController : ApiController
    {
        /*Interface1 ln;
        public LoginnController()
        {

        }
        public LoginnController(Interface1 interface1)
        {
            ln = interface1;
        }*/


       // login ln = new login();
        projecttEntities3 DB = new projecttEntities3();
        [System.Web.Http.Route("Login")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult userLogin(Login login)
        {

            //var log = ln.Login(login.UserName, login.Password);
            var log = DB.tbl_UserMaster.Where(x => x.UserName.Equals(login.UserName) && x.Password.Equals(login.Password)).FirstOrDefault();
            if (log == null)
            {
                return Ok(new { Status = "Invalid", Message = "Invalid User" });
            }
            else
            {



                return Ok(new { Status = "Success", Message = "Login Success", UserDetails = log });
            }
        }


        [System.Web.Http.Route("InsertEmployee")]
        [System.Web.Http.HttpPost]

        public object InsertEmployee(UserMaster um)
        {

            try

            {


                tbl_UserMaster EL = new tbl_UserMaster();
                if (EL.UserID == 0)
                {



                    EL.UserFirstName = um.UserFirstName;

                    EL.UserMiddleName = um.UserMiddleName;

                    EL.UserLastName = um.UserLastName;

                    EL.Address = um.Address;

                    EL.EmailId = um.EmailId;
                    EL.UniQueHousNo = um.UniQueHousNo;
                    EL.PhoneNo = um.PhoneNo;
                    EL.DOB = um.DOB;
                    EL.DOR = um.DOR;
                    EL.UserName = um.UserName;
                    EL.Password = um.Password;
                    EL.Role = um.Role;

                    DB.tbl_UserMaster.Add(EL);

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
    
