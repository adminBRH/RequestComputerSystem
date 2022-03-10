using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Text;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace RequestComputerSystem
{
    public partial class RequestList : System.Web.UI.Page
    {
        string sql = "";
        DataTable dt;
        SQLclass cl_Sql = new SQLclass();

        string UserStatus = "";
        string UserLogin = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLogin"] != null)
            {
                UserStatus = Session["UserStatus"].ToString();
                UserLogin = Session["UserLogin"].ToString();

                if (!IsPostBack)
                {
                    Systems();
                    string sr = ddl_status.SelectedValue.Trim();
                    string sy = ddl_system.SelectedValue.Trim();
                    string date = "";
                    Grid1(sr, sy, date);
                }
                else
                {

                }

            }
            else
            {
                Response.Redirect("Default");
            }
        }

        //protected void ddl_status_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string sr = ddl_status.SelectedValue.Trim();
        //    string date = txtdate.Value.ToString().Trim();
        //    Grid1(sr, date);
        //}

        protected void Systems()
        {
            sql = "select * from systems where sysactive='Y' order by sysname; ";
            dt = new DataTable();
            dt = cl_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {}
            ddl_system.DataSource = dt;
            ddl_system.DataTextField = "sysname";
            ddl_system.DataValueField = "sysid";
            ddl_system.DataBind();
            ddl_system.Items.Insert(0, new ListItem("All Systems", ""));
        }

        public Boolean Grid1(string sr, string sy, string da)
        {
            Boolean bl = false;
            
            string apStatus = sr;
            string apSystem = "= '" + sy + "' ";
            if (sy == "")
            {
                apSystem = "like '%%' ";
            }
            string date = da;

            sql = "select r.rqid, rs.rqsid, a.apid, CONCAT('[',r.rqid,'.',rs.rqsid,']') as 'ReqID', r.rqdateadd, CONCAT(r.rqpname,' ',r.rqfname,' ',r.rqlname) as 'UserReqName' " +
                ", r.rqpost, r.rqdepartment as 'UserReqDept', d.deptname as 'UserReqDeptName' " +
                ", s.sysname, a.apstatus, a.aplevel, a.aplname, r.userid ,a.userid as 'apuserapprove', a.apuserapprove1, a.apuserapprove2, a.apdate " +
                "from brh_it_request.requestsystems as rs " +
                "left join brh_it_request.request as r on r.rqid = rs.rqid " +
                "left join brh_it_request.systems as s on s.sysid = rs.sysid " +
                "left join brh_it_request.department as d on d.deptid = r.rqdepartment " +
                "left join( " +
                "    select a.*,al.aplname from brh_it_request.approve as a " +
                "    left join(select rqsid, MAX(aplevel) as 'aplevelMAX','Y' as 'LastStatus' from brh_it_request.approve group by rqsid) as a2 " +
                "        on a2.rqsid = a.rqsid and a2.aplevelMAX = a.aplevel " +
                "    left join brh_it_request.approvelevel as al on al.apllevel=a.aplevel " +
                "    where a2.LastStatus = 'Y' " +
                ") a on a.rqsid = rs.rqsid " +
                "where apstatus like '%" + apStatus + "%' " +
                "and rs.sysid " + apSystem +
                "and r.rqdateadd like '%" + date + "%' ";

                if (UserStatus == "admin" || UserStatus == "it")
                {
                    
                }
                else
                {
                    sql += "and (r.userid = '" + UserLogin + "' or a.userid = '" + UserLogin + "' or a.apuserapprove1 = '" + UserLogin + "') ";
                }

                if (apStatus == "Wait")
                {
                    sql += "order by rs.rqid";
                }
                else
                {
                    sql += "order by rs.rqid desc";
                }

            dt = new DataTable();
            dt = cl_Sql.select(sql);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            if (GridView1.PageCount > 0)
            {
                bl = true;
            }
            else
            {
                bl = false;
            }

            return bl;
        } 

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string CommN = e.CommandName.ToString();
            if (CommN == "approve")
            {
                string rqsid = e.CommandArgument.ToString();
                Response.Redirect("ApproveEvent.aspx?id=" + rqsid);
            }
            else if (CommN == "Page")
            { }
            else
            {
                Response.Redirect("RequestList.aspx");
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell DateCell = e.Row.Cells[0];
                TableCell IDCell = e.Row.Cells[1];
                TableCell SystemCell = e.Row.Cells[2];
                TableCell NameCell = e.Row.Cells[3];
                TableCell DeptCell = e.Row.Cells[4];
                TableCell Alert = e.Row.Cells[5];
                Alert.Visible = false;
                TableCell StatusCell = e.Row.Cells[6];
                TableCell ActionCell = e.Row.Cells[7];
                TableCell apv = e.Row.Cells[9];
                apv.Visible = false;

                if (StatusCell.Text == "CloseJob")
                {
                    StatusCell.CssClass = "fas fa-star fa-5 text-success";
                }
                else if (StatusCell.Text == "Acknowledge")
                {
                    StatusCell.CssClass = "fas fa-eye text-success";
                }
                else if (StatusCell.Text == "Finish")
                {
                    StatusCell.CssClass = "fas fa-paperclip fa-8 text-success";
                }
                else if (StatusCell.Text == "Approved")
                {
                    StatusCell.CssClass = "fas fa-check text-success";
                }
                else if (StatusCell.Text == "Wait")
                {
                    apv.Visible = true;

                    StatusCell.CssClass = "fas fa-clock text-warning";
                    double DateDiff = (DateTime.Now - Convert.ToDateTime(DateCell.Text)).TotalDays;
                    if (DateDiff > 7)
                    {
                        Alert.Visible = true;
                        StatusCell.Visible = false;
                    }
                }
                else if (StatusCell.Text == "Cancel")
                {
                    apv.Visible = true;
                    StatusCell.CssClass = "fas fa-times text-danger";
                }
                else { }

            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            string sr = ddl_status.SelectedValue.Trim();
            string sy = ddl_system.SelectedValue.Trim();
            string date = txtdate.Value.ToString().Trim();
            Grid1(sr, sy, date);
        }

        protected void bt_search_Click(object sender, EventArgs e)
        {
            string sr = ddl_status.SelectedValue.Trim();
            string sy = ddl_system.SelectedValue.Trim();
            string date = txtdate.Value.ToString().Trim();
            Grid1(sr, sy, date);
        }
    }
}