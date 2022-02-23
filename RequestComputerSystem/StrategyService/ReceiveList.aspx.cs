using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace RequestComputerSystem.StrategyService
{
    public partial class ReceiveList : System.Web.UI.Page
    {
        string sql = "";
        DataTable dt;
        SQLclass cl_Sql = new SQLclass();

        protected void Page_Load(object sender, EventArgs e)
        {
            string userid = "562805";
            JobList(userid);
        }

        private void JobList(string userid)
        {
            sql = "select * from Request where receiver_id='" + userid + "'; ";
            dt = new DataTable();
            dt = cl_Sql.selectStrategy(sql);
            if (dt.Rows.Count > 0)
            {

            }

            LV_job.DataSource = dt;
            LV_job.DataBind();
        }
    }
}