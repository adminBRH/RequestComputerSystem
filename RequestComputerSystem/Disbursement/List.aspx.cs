using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using System.IO;

namespace RequestComputerSystem.Disbursement
{
    public partial class List : System.Web.UI.Page
    {
        string sql = "";
        DataTable dt;
        SQLclass CL_Sql = new SQLclass();
        DisbursementClass cl_pv = new DisbursementClass();
        Files cl_file = new Files();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                SelectForm();

                if (!IsPostBack)
                {
                    Grid1("waiting", "", "");
                }
            }
        }

        public Boolean Grid1(string status , string dateFrom, string dateTo)
        {
            Boolean bl = false;

            string UserStatus = Session["UserStatus"].ToString();

            string empid = Session["UserLogin"].ToString();
            string crid = cl_pv.CRID(empid, status);

            sql = "SELECT f.df_name, dr.*,CONCAT(userpname,' ',userfname,' ',userlname) as 'fullname',d.deptname " +
                "\nFROM disbursement_request as dr " +
                "\nleft join `user` as u on u.username = dr.dr_empid " +
                "\nleft join department as d on d.deptid = dr.dr_dept " +
                "\nleft join disbursement_form as f on f.df_id = dr.dr_formid " +
                "\nwhere dr_status like '%" + status + "%' ";
                if (UserStatus == "admin" || UserStatus == "test")
                {

                }
                else
                {
                    sql = sql + "\nand dr_id in (" + crid + ") ";
                }
                if (dateFrom != "") {
                    sql = sql + "\nand (CONVERT(dr_datetime,date) between '" + dateFrom + "' and '" + dateTo + "') ";
                }
            sql = sql + "\nORDER BY dr_id DESC ";

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

        protected void btn_file_Click(object sender, EventArgs e)
        {
            string txth_id = txtH_id.Value.ToString();
            string file = cl_file.Show("FileUpload/", txth_id);

            div_file.Visible = true;

            btn_file.Attributes.Add("style","display: none");

            lbl_show_excel.Text = file;
        }

        protected void chang_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            Search();
        }

        public Boolean Search()
        {
            Boolean bl = false;

            string status = chang_status.SelectedValue.ToString();
            string DateFrom = date_from.Value.ToString();
            string DateTo = date_to.Value.ToString();
            if(Grid1(status, DateFrom, DateTo))
            {
                bl = true;
            }

            return bl;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string username = Session["UserLogin"].ToString();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell dr_status = e.Row.Cells[5];
                string DrStatus = dr_status.Text.Trim();

                if (DrStatus == "waiting")
                {
                    dr_status.CssClass = "col-12 btn btn-warning mx-auto my-auto";
                }
                else if (DrStatus == "reject")
                {
                    dr_status.CssClass = "col-12 btn btn-danger mx-auto my-auto";
                }
                else if (DrStatus == "approve")
                {
                    dr_status.CssClass = "col-12 btn btn-success mx-auto my-auto";
                }
                else
                {
                    dr_status.CssClass = "btn btn-light mx-auto my-auto";
                }
            }
        }
    }
}