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
                Response.Redirect("../login.aspx");
            }
            else
            {
                SelectForm();

                if (!IsPostBack)
                {
                    string br_select = "";
                    if (Session["userDpetid"] != null)
                    {
                        br_select = Session["userDeptid"].ToString();
                    }
                    Branch(br_select);

                    string dateStart = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
                    date_from.Value = dateStart;
                    string dateNow = DateTime.Now.ToString("yyyy-MM-dd");
                    date_to.Value = dateNow;

                    string status = "waiting";
                    string UserStatus = Session["UserStatus"].ToString();
                    if (UserStatus == "admin" || UserStatus == "finance" || UserStatus == "test" || UserStatus == "superuser")
                    {
                        status = "wait";
                    }

                    chang_status.SelectedValue = status;

                    Grid1(br_select, status, dateStart, dateNow);
                }
            }
        }

        public Boolean Grid1(string branch, string status , string dateFrom, string dateTo)
        {
            Boolean bl = false;

            if (branch != "")
            {
                branch = branch.Substring(0, 3);
            }

            string UserStatus = Session["UserStatus"].ToString();

            string empid = Session["UserLogin"].ToString();

            if (UserStatus == "admin" || UserStatus == "finance" || UserStatus == "test" || UserStatus == "superuser")
            {
                empid = "";
            }

            sql = "select *,concat(dr_dept,' ',deptname) as 'departmentname' " +
                "\nfrom v_disbursement " +
                "\nwhere dr_status <> 'cancel' " +
                "\nand dr_dept like '" + branch + "%' ";
            if (status == "waiting") // Wait me
            {
                sql += "\nand dr_status = '" + status + "' ";
                sql += "\nand userid = '" + empid + "' ";
            }
            else
            {
                sql += "\nand status like '%" + status + "%' ";
                sql += "\nand(userid like '%" + empid + "%' or dr_empid like '%" + empid + "%' or other_user like '%" + empid + "%') ";
            }
            sql += "\nand(CONVERT(dr_datetime, date) between '" + dateFrom + "' and '" + dateTo + "') " +
                "\norder by dr_id DESC; ";
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

        public void Branch(string br_select)
        {
            dt = new DataTable();
            dt = CL_Sql.dt_Branch();

            dd_branch.DataSource = dt;
            dd_branch.DataTextField = "branchname";
            dd_branch.DataValueField = "branchname";
            dd_branch.DataBind();
            dd_branch.Items.Insert(0, new ListItem("ALL",""));

            if (br_select != "")
            {
                dd_branch.SelectedValue = br_select.Substring(0, 3);
            }
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
            string file = cl_file.Show("FileUpload/", "id" + txth_id + ",*");

            div_file.Visible = true;

            btn_file.Attributes.Add("style","display: none");

            lbl_show_excel.Text = file;
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            Search();
        }

        public Boolean Search()
        {
            Boolean bl = false;

            string br_select = dd_branch.SelectedValue.ToString();
            string status = chang_status.SelectedValue.ToString();
            string DateFrom = date_from.Value.ToString();
            string DateTo = date_to.Value.ToString();
            if(Grid1(br_select, status, DateFrom, DateTo))
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
                TableCell dr_status = e.Row.Cells[6];
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

        protected void dd_branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        protected void chang_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }
    }
}