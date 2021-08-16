using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace RequestComputerSystem.Disbursement
{
    public partial class List : System.Web.UI.Page
    {
        string sql = "";
        DataTable dt;
        SQLclass CL_Sql = new SQLclass();

        protected void Page_Load(object sender, EventArgs e)
        {
            Grid1();

            SelectForm();
        }

        public Boolean Grid1()
        {
            Boolean bl = false;

            sql = "select * from ( " +
                "    select 'Request' as 'type',d_id as 'id',d_datetime,d_empid,d_status,d_deptcode,d_formid from disbursement " +
                "    Union " +
                "    select 'Cancel' as 'type',cd_id as 'id',cd_datetime,cd_empid,cd_status,cd_deptid,cd_formid from cancel_disbursement " +
                ") a " +
                "order by id ";
            dt = new DataTable();
            dt = CL_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
                bl = true;
            }
            

            GridView1.DataSource = dt;
            GridView1.DataBind();

            return bl;
        }

        public Boolean SelectForm()
        {
            Boolean bl = false;

            if (Request.QueryString["id"] != null && Request.QueryString["form"] != null)
            {
                string id = Request.QueryString["id"].ToString();
                string formid = Request.QueryString["form"].ToString();

                if (formid == "1")
                {
                    Response.Redirect("RecordDisbursementMoney.aspx?id=" + id);
                }
                else if (formid == "2")
                {
                    Response.Redirect("DoctorTravelExpenses.aspx?id=" + id);
                }
                else if (formid == "3")
                {
                    Response.Redirect("Repayment.aspx?id=" + id);
                }
                else if (formid == "4")
                {
                    Response.Redirect("CostCancel.aspx?id=" + id);
                }
                else { }
            }

            return bl;
        }
    }
}