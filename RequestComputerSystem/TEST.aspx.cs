using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace RequestComputerSystem
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        string sql = "";
        DataTable dt;
        SQLclass cl_Sql = new SQLclass();

        protected void Page_Load(object sender, EventArgs e)
        {
            DataStrategy();
        }

        protected void DataStrategy()
        {
            sql = "select r.receiver_id, (u.Name + ' ' + u.lastname) as 'receiver_name', s.st_id, s.st_name, COUNT(1) as cnt " +
                "\nfrom Request as r " +
                "\nleft join[User] as u on u.UserName = r.receiver_id " +
                "\nleft join status as s on s.st_id = r.status " +
                "\nwhere YEAR(r.CDate) = YEAR(getdate()) " +
                "\nand s.st_id in ('1', '2', '3', '4') " +
                "\nand(r.category not between 27 and 34) " +
                "\ngroup by r.receiver_id, (u.Name + ' ' + u.lastname), s.st_id, s.st_name " +
                "\norder by r.receiver_id, s.st_id; ";
            dt = new DataTable();
            dt = cl_Sql.selectStrategy(sql);
            if (dt.Rows.Count > 0)
            { }
            LV_Request.DataSource = dt;
            LV_Request.DataBind();
        }
    }
}