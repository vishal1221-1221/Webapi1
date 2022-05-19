using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
//using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;

using etaxproject.Models;

namespace etaxproject.Controllers
{
    public class AdminController : ApiController
    {
        // GET: Login
        public HttpResponseMessage Get()
        {
         
            DataTable table = new DataTable();
            //string query = "SELECT OwnerName,TelephonNo,Email,ActualHouseNo,HouseRegistrationdate,AreaId,StreetId,PlotId,ElectricityConnstatus,GasConnStatus,WaterConnStatus,C_M_P_Id,BuildingApprovalNo FROM tbl_HousesMaster where UniQueHousNo= '"+ um.UniQueHousNo +"'";
            string query = @"SELECT UserID,UserFirstName,UserMiddleName,UserLastName,Address,EmailId,UniQueHousNo,PhoneNo,DOB,DOR,UserName,Password,Role FROM dbo.tbl_UserMaster";
            //string query = "SELECT TOP (1000) [UserID],[UserFirstName],[UserMiddleName],[UserLastName],[Address],[EmailId],[HouseNo],[PhoneNo],[DOB],[DOR],[UserName],[Password],[Role] FROM[projectt].[dbo].[tbl_UserMaster]";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["etax"].ConnectionString)) 
            using (var cmd = new SqlCommand(query,con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);

            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
            
        
        }
        public string PUT(UserMaster um)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"update dbo.tbl_UserMaster set 
                    UserFirstName='" + um.UserFirstName + @"',
                    UserMiddleName='" + um.UserMiddleName + @"', 
                     UserLastName='" + um.UserLastName + @"',
                    Address='" + um.Address + @"', 
                        EmailId='" + um.EmailId + @"',
                    UniQueHousNo='" + um.UniQueHousNo + @"', 
                     PhoneNo='" + um.PhoneNo + @"',
                    DOB='" + um.DOB + @"', 
                     DOR='" + um.DOR + @"',
                    UserName='" + um.UserName + @"',
                       Password='" + um.Password + @"'
                        where UserID = " + um.UserID + @"";
                                


                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["etax"].ConnectionString))
                    using (var cmd = new SqlCommand(query, con))
                    using (var da = new SqlDataAdapter(cmd))
                    {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);

                    }
                return "updated Success";

            }
            catch (Exception)
            {
                return "failed to update";
            }
        }

        public string DELETE(int id)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"delete from dbo.tbl_UserMaster where UserID= "+ id;



                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["etax"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);

                }
                return "Deleted Successfully";

            }
            catch (Exception)
            {
                return "failed to delete";
            }
        }














    }
}