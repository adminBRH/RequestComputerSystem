using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

using System.Diagnostics;
using CrystalDecisions.CrystalReports.Engine;

namespace RequestComputerSystem
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        string sql = "";
        DataTable dt;
        SQLclass cl_Sql = new SQLclass();

        protected void Page_Load(object sender, EventArgs e)
        {
            ReportDocument RpDoc = new ReportDocument();

            sql = "select * from brh_it_request.request ";
            dt = new DataTable();
            dt = cl_Sql.select(sql);
            if (dt.Rows.Count <= 0)
            {
                //RpDoc.Load("ReportRequest.rpt");
                //RpDoc.SetDataSource(dt);
                //RpDoc.Refresh();
                //this.ReportViewer1.ReportRefresh();
            }
        }
    }
}