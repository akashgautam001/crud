using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using DemoProject.Models;

namespace DemoProject.Models
{
    public class DbManager
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
       public DbManager ()
        {
            con = new SqlConnection(@"Data Source=DESKTOP-4BRGBG3\LOCAL;Initial Catalog=Demo;Integrated Security=True");
        }
        public bool InsertUpdateDelete(String commond)
        {
            cmd = new SqlCommand(commond, con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int n = cmd.ExecuteNonQuery();
            if (n > 0)
                return true;
            else
                return false;
        }
        public DataTable Display_All_Records(String Commond)
        {
            cmd = new SqlCommand(Commond, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            sa.Fill(dt);
            return dt;
        }
        public int GetCount(String commond)
        {
            cmd = new SqlCommand(commond, con);
            int n = (Int32)cmd.ExecuteScalar();
            if (n > 0)
            {
                return n;
            }
            return n;
        }


    }
}