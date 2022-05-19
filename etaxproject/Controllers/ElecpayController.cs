using etaxproject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace etaxproject.Controllers
{
    public class ElecpayController : ApiController
    {
        // GET: Elecpay
        public HttpResponseMessage Get(int id)
        {

            DataTable table = new DataTable();
            //string query = "SELECT OwnerName,TelephonNo,Email,ActualHouseNo,HouseRegistrationdate,AreaId,StreetId,PlotId,ElectricityConnstatus,GasConnStatus,WaterConnStatus,C_M_P_Id,BuildingApprovalNo FROM tbl_HousesMaster where UniQueHousNo= '"+ um.UniQueHousNo +"'";
            string query = @"SELECT UniQueHousNo,electricalserviceno,unitsconsumed,fromdate,todate,billamount,meterreading,card,cvv,status FROM dbo.Elecpay where UniQueHousNo=" + id;
            //string query = "SELECT TOP (1000) [UserID],[UserFirstName],[UserMiddleName],[UserLastName],[Address],[EmailId],[HouseNo],[PhoneNo],[DOB],[DOR],[UserName],[Password],[Role] FROM[projectt].[dbo].[tbl_UserMaster]";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["etax"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);

            }
            return Request.CreateResponse(HttpStatusCode.OK, table);


        }

        public string POST(Elecpay et)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"insert into dbo.Elecpay (UniQueHousNo,electricalserviceno,unitsconsumed,fromdate,todate,billamount,meterreading,card,cvv,status) Values('" + et.UniQueHousNo + @"','" + et.electricalserviceno + @"','" + et.unitsconsumed + @"','" + et.fromdate + @"','" + et.todate + @"','" + et.billamount + @"','" + et.meterreading + @"','" + et.card + @"','" + et.cvv + @"','" + et.status + @"')";



                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["etax"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);

                }
                return "Added Successfully";

            }
            catch (Exception)
            {
                return "failed to Add";
            }
        }


    }
}