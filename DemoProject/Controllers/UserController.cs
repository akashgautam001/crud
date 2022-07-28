using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using DemoProject.Models;
using System.IO;

namespace DemoProject.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        DbManager db = new DbManager();
        public ActionResult index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string txtname,string txtemail,string txtcountry,string txtstate,string txtdistick, HttpPostedFileBase pic)
        {
           string query="insert into tbl_Csdall_Data_add values('"+txtname+"','"+txtemail+"','"+txtcountry+"','"+txtstate+"','"+txtdistick+"','"+ pic.FileName + "')";
            db.InsertUpdateDelete(query);
            string fupic = Path.Combine(Server.MapPath("/Content/PIc"), pic.FileName);
            pic.SaveAs(fupic);
            Response.Write("<script>alert('Registion Succesfully')</script>");
            return View();
        }
        

        public JsonResult BindState(string County)
        {
            string op = "<option value=''>--select--State--</option>";
            string query = "select * from Tbl_State where fk_country_code='" + County + "'";
            DataTable dt = db.Display_All_Records(query);
            for(int i=0;i<dt.Rows.Count;i++)
            {
                op += "<option value="+dt.Rows[i]["State_code"] +">"+dt.Rows[i]["State_name"] +"</option>";
            }
            return Json(op, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BindDistick(string Distick)
        {
            string op = "<option value=''>--select--State--</option>";
            string query = "select * from Tbl_distick where fk_State_code='" + Distick + "'";
            DataTable dt = db.Display_All_Records(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                op += "<option value=" + dt.Rows[i]["distick_code"] + ">" + dt.Rows[i]["distick_name"] + "</option>";
            }
            return Json(op, JsonRequestBehavior.AllowGet);
        }

        public ActionResult delete(string del)
        {
            string queryy = "delete from  tbl_Csdall_Data_add where email='" + del + "'";
            db.InsertUpdateDelete(queryy);
            Response.Write("<script>alert('Are You Want to Delete')</script>");
            return RedirectToAction("index", "User");
           // return View("index","User");
        }
    }
}