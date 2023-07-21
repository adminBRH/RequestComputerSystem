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
                    string dateStart = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
                    string dateEnd = DateTime.Now.Date.ToString("yyyy-MM-dd");
                    date_Start.Value = dateStart;
                    date_End.Value = dateEnd;

                    if (UserStatus == "admin" || UserStatus == "it")
                    {
                        ddl_status.SelectedValue = "";
                    }
                    else
                    {
                        ddl_status.SelectedValue = "Wait me";
                    }

                    Branch();
                    Systems();
                    Search();
                }
            }
            else
            {
                Response.Redirect("Default");
            }
        }

        protected void Branch()
        {
            sql = "select distinct LEFT(deptid,3) as 'branchname' from department where deptactive = 'yes';";
            dt = new DataTable();
            dt = cl_Sql.select(sql);
            if (dt.Rows.Count > 0)
            { }
            dd_branch.DataSource = dt;
            dd_branch.DataTextField = "branchname";
            dd_branch.DataValueField = "branchname";
            dd_branch.DataBind();
            dd_branch.Items.Insert(0, new ListItem("ALL", ""));
        }

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

        public Boolean Grid1(string branch, string sr, string sy, string dateStart, string dateEnd)
        {
            Boolean bl = false;
            
            string apStatus = sr;
            string apSystem = "= '" + sy + "' ";
            if (sy == "")
            {
                apSystem = "like '%%' ";
            }

            string onlyuser = "#";
            string orderby = "order by rs.rqid ";
            if (apStatus == "Wait" || apStatus == "Wait me")
            {
                orderby += "desc ";
                if (apStatus == "Wait me")
                {
                    apStatus = "Wait";
                    onlyuser = "";
                }
            }

            if (UserStatus == "admin" || UserStatus == "it")
            {
                UserLogin = "";
            }

            sql = "Select a.*, r.rqid, concat('[',r.rqid,'.',a.rqsid,']') as 'ReqID', s.sysname, rs.rqsvalue, " +
                "\nconcat(s.sysname,ifnull(concat(' : ',rs.rqsvalue),'')) as 'SystemName', r.rqdateadd, " +
                "\nconcat(ifnull(fu.userpname,''),fu.userfname,' ',fu.userlname) as 'UserReqName', " +
                "\nconcat(ifnull(apu.userpname,''),apu.userfname,' ',apu.userlname) as 'UserApprove', " +
                "\nr.rqdepartment, d.deptname, concat(r.rqdepartment,' ',d.deptname) as 'UserReqDeptName', al.aplname " +
                "\nfrom ( " +
                "\n    select ap.*,if(ap.aplevel=7,'brh_it',ap.apuserapprove1) as 'apUser' from approve as ap " +
                "\n    left join (select rqsid, MAX(apid) as 'apidMAX' from approve group by rqsid) as am on am.rqsid = ap.rqsid " +
                "\n    where ap.apid = am.apidMax " +
                "\n) as a " +
                "\nleft join ( " +
                "\n    select DISTINCT rqsid from approve " +
                "\n    where (userid like '%" + UserLogin + "%' or aprequestuser like '%" + UserLogin + "%' or apuserapprove1 like '%" + UserLogin + "%' or apuserapprove2 like '%" + UserLogin + "%') " +
                "\n) as sh on sh.rqsid = a.rqsid " +
                "\nleft join requestsystems as rs on rs.rqsid = a.rqsid " +
                "\nleft join request as r on r.rqid = rs.rqid " +
                "\nleft join systems as s on s.sysid = rs.sysid " +
                "\nleft join `user` as fu on fu.username = a.aprequestuser " +
                "\nleft join `user` as apu on apu.username = a.apUser " +
                "\nleft join department as d on d.deptid = r.rqdepartment " +
                "\nleft join approvelevel as al on al.aplid = a.aplevel and al.apllevel_sub = a.aplevel_sub " +
                "\nwhere sh.rqsid is not null " +
                "\nand r.rqdepartment like '" + branch + "%' " +
                "\nand rs.sysid " + apSystem + " " +
                "\nand (convert(r.rqdateadd,date) between convert('" + dateStart + "',date) and convert('" + dateEnd + "',date)) " +
                "\nand a.apstatus like '%" + apStatus + "%' " +
                "\n"+ onlyuser + "and a.apUser = '" + UserLogin + "' " +
                "\n" + orderby + "; ";

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

        private void Search()
        {
            string branch = dd_branch.SelectedValue.ToString();
            string status = ddl_status.SelectedValue.Trim();
            string system = ddl_system.SelectedValue.Trim();
            string dateStart = date_Start.Value.ToString().Trim();
            string dateEnd = date_End.Value.ToString().Trim();

            Grid1(branch, status, system, dateStart, dateEnd);
        }

        protected void dd_branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        protected void ddl_system_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        protected void ddl_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        protected void bt_search_Click(object sender, EventArgs e)
        {
            Search();
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
            Search();
        }
    }
}