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
    public partial class Received : System.Web.UI.Page
    {
        string sql = "";
        DataTable dt;
        SQLclass cl_Sql = new SQLclass();

        protected void Page_Load(object sender, EventArgs e)
        {
            string id = "21100001";
            ShowData(id);
        }

        private void ShowData(string id)
        {
            sql = "select r.*,cr.Category_Name,rl.Comment from Request as r " +
                "\nleft join Category_Request as cr on cr.Category_ID = r.category " +
                "\nleft join Request_log as rl on rl.Request_ID = r.Request_ID " +
                "\nwhere r.Request_ID='" + id +"'; ";
            dt = new DataTable();
            dt = cl_Sql.selectStrategy(sql);
            if (dt.Rows.Count > 0)
            {
                txt_category.Value = dt.Rows[0]["Category_Name"].ToString();
                txt_subject.Value = dt.Rows[0]["Subject"].ToString();
                lbl_description.Text = dt.Rows[0]["Comment"].ToString();
            }
        }
    }
}