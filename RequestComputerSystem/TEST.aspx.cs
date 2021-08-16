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

        }

        protected void btn_search_ServerClick(object sender, EventArgs e)
        {
            string name = txt_name.Value.ToString().Trim();
            sql = "select * from Patient ";
            dt = new DataTable();
            dt = cl_Sql.selectBconnect(sql);
            if (dt.Rows.Count > 0)
            {
                string alert = dt.Rows.Count.ToString() + " - ";
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["Forename"].ToString() == name)
                    {
                        string UID = dr["UID"].ToString();

                        alert = alert + dr["Forename"].ToString() + " " + dr["Surname"].ToString() + " / " + UID + " / ";
                        
                        sql = "select dbo.fGetPatientID(" + UID + ", dbo.fGetReferenceValueUID(N'NATID', N'PITYP')) AS NationalID ";
                        DataTable dt2 = new DataTable();
                        dt2 = cl_Sql.selectBconnect(sql);
                        if (dt2.Rows.Count > 0)
                        {
                            alert = alert + dt2.Rows[0]["NationalID"].ToString() + "<br />";
                        }
                        //break;
                    }
                }
                lbl_alert.Text = alert;
            }
        }
    }
}