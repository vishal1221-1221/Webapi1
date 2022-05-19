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
    public class waterpayController : ApiController
    {

        public HttpResponseMessage Get(int id)
        {
            
            DataTable table = new DataTable();
            //string query = "SELECT OwnerName,TelephonNo,Email,ActualHouseNo,HouseRegistrationdate,AreaId,StreetId,PlotId,ElectricityConnstatus,GasConnStatus,WaterConnStatus,C_M_P_Id,BuildingApprovalNo FROM tbl_HousesMaster where UniQueHousNo= '"+ um.UniQueHousNo +"'";
            //string query = @"SELECT UniQueHousNo,watertaxid,paymentamount,fromdate,todate FROM dbo.watertax ";
            string query = @"SELECT UniQueHousNo,watertaxid,paymentamount,fromdate,todate,status FROM dbo.Waterpay where UniQueHousNo="+id;
            
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["etax"].ConnectionString))
            using (var cmd = new SqlCommand(query, con)) 
            using (var da = new SqlDataAdapter(cmd)) 
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);

            }
            return Request.CreateResponse(HttpStatusCode.OK, table);


        }
        public string POST(Models.waterpay wt)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"insert into dbo.Waterpay (UniQueHousNo,watertaxid,paymentamount,fromdate,todate,cardno,cvv,status) Values('" + wt.UniQueHousNo + @"','" + wt.watertaxid + @"','" + wt.paymentamount + @"','" + wt.fromdate + @"','" + wt.todate + @"','" + wt.cardno + @"','" + wt.cvv + @"','" + wt.status + @"')";



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