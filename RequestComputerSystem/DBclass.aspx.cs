using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using MySql.Data.MySqlClient;

namespace RequestComputerSystem
{
    public partial class DBclass : System.Web.UI.Page
    {
        SQLclass cl_Sql = new SQLclass();
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            //// SQL connection
            //string sql1 = "Select * from [user]";
            //DataTable dt = new DataTable();
            //DBClass cl_Sqlget = new DBClass();
            //dt = cl_Sqlget.SqlGet(sql1);

            //GridView1.DataSource = dt;
            //GridView1.DataBind();

            // mySQL connection
            string sql1 = "select * from brh_it_request.`user`";
            dt = cl_Sql.select(sql1);

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string user = Input1.Value.ToString();
            string sql2 = "select * from brh_it_request.`user` where username like '%" + user + "%' ";
            dt = cl_Sql.select(sql2);

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            
        }
    }
}