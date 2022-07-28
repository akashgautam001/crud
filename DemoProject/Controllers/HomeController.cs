using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using DemoProject.Models;

namespace DemoProject.Controllers
{
    public class HomeController : Controller
    {
        DbManager db = new DbManager();
        public ActionResult Index()
        {    
            
            return View();
        }   

        public JsonResult BindCodeState(string country)
        {
            string op = "<option value='' >-Select--State --</option>";
            string query = "select * From Tbl_State where fk_country_code='" + country + "'";
            DataTable dt = db.Display_All_Records(query);
            for(int i=0;i<dt.Rows.Count;i++)
            {
                op+= "<option value="+dt.Rows[i]["State_code"] +">"+dt.Rows[i]["State_name"] +"</option>";
            }
            return Json(op, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BindDistick(string Distick)



        {
            string op = "<option value='' >-Select--State --</option>";
            string query = "select * From Tbl_distick where fk_State_code='" + Distick + "'";
            DataTable dt = db.Display_All_Records(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                op += "<option value=" + dt.Rows[i]["distick_code"] + ">" + dt.Rows[i]["distick_name"] + "</option>";
            }
            return Json(op, JsonRequestBehavior.AllowGet);
        }

    }
}