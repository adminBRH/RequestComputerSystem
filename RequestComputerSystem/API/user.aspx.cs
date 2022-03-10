using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

using System.Net;

namespace RequestComputerSystem.API
{
    public partial class user : System.Web.UI.Page
    {
        string sql = "";
        DataTable dt;
        SQLclass cl_Sql = new SQLclass();

        protected void Page_Load(object sender, EventArgs e)
        {
            //string JSON = "";
            //sql = "select * from employee LIMIT 100 ";
            //JSON = cl_Sql.brh_hospital(sql);
            //lbl_JSON.Text = JSON;

            ////var json = new WebClient().DownloadString("http://brh.apply-apps.com/API/Bconnect/Patient");
            ////lbl_JSON.Text = json;

            data();
        }

        protected void data()
        {
            string json = "";
            sql = "select * from approve where convert(apdate, date)>=(CURRENT_DATE - INTERVAL 2 day) ";
            dt = new DataTable();
            dt = cl_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
                json = cl_Sql.dtToJson(dt);
                lbl_JSON.Text = json;
            }
        }
    }
}