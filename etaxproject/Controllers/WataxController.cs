﻿using System;
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
    public class WataxController : ApiController
    {


        public HttpResponseMessage Get()
        {

            DataTable table = new DataTable();
            //string query = "SELECT OwnerName,TelephonNo,Email,ActualHouseNo,HouseRegistrationdate,AreaId,StreetId,PlotId,ElectricityConnstatus,GasConnStatus,WaterConnStatus,C_M_P_Id,BuildingApprovalNo FROM tbl_HousesMaster where UniQueHousNo= '"+ um.UniQueHousNo +"'";
            //string query = @"SELECT UniQueHousNo,watertaxid,paymentamount,fromdate,todate FROM dbo.watertax ";
            string query = @"SELECT w.UniQueHousNo,w.watertaxid,w.paymentamount,w.fromdate,w.todate FROM dbo.watertax w inner join dbo.tbl_UserMaster  u on  w.UniQueHousNo=u.UniQueHousNo";
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

        public string PUT(Wtax wt)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"update dbo.watertax set 
                    watertaxid='" + wt.watertaxid + @"',
                    paymentamount='" + wt.paymentamount + @"', 
                     fromdate='" + wt.fromdate + @"',
                    todate='" + wt.todate + @"'
                    where UniQueHousNo = " + wt.UniQueHousNo + @"";





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

        public string POST(Wtax wt)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"insert into dbo.watertax (UniQueHousNo,watertaxid,paymentamount,fromdate,todate) Values('" +wt.UniQueHousNo+ @"','" + wt.watertaxid+ @"','" + wt.paymentamount + @"','" + wt.fromdate + @"','" + wt.todate + @"')";



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

        public string DELETE(int id)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"delete from dbo.watertax where UniQueHousNo= " + id;



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


        /* [System.Web.Http.RoutePrefix("Api/ETax")]
        public class ElectaxController : ApiController
        {
            // GET: Electax
            projecttEntities6 DB = new projecttEntities6();
            [System.Web.Http.Route("InsertElectax")]
            [System.Web.Http.HttpPost]

            public object InsertEtax(Etaxx et)
            {

                try

                {


                    Elecreading EL = new Elecreading();
                    if (EL.UniQueHousNo == 0)
                    {


                        EL.UniQueHousNo = et.UniQueHousNo;
                        EL.electricalserviceno = et.electricalserviceno;

                        EL.unitsconsumed = et.unitsconsumed;

                        EL.fromdate = et.fromdate;

                        EL.todate = et.todate;

                        EL.billamount = et.billamount;
                        EL.meterreading = et.meterreading;


                        DB.Elecreadings.Add(EL);

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
        }*/
    }
}