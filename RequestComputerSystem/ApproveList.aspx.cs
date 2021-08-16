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
    public partial class ApproveList : System.Web.UI.Page
    {
        string sql = "";
        DataTable dt;
        SQLclass cl_Sql = new SQLclass();

        string UserStatus = "";
        string UserLogin = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["UserLogin"] = "111222";

            if (Session["UserLogin"] != null)
            {
                UserStatus = Session["UserStatus"].ToString();

                
                if (!IsPostBack)
                {
                    string sr = ddl_status.SelectedValue.Trim();
                    Grid1(sr);

                    //string PageNum = "";
                    //PageNum = GridView1.PageIndex.ToString();
                    //Response.Write("<script>alert('" + PageNum + "');</script>");

                    //string PageCnt = "";
                    //PageCnt = GridView1.PageCount.ToString();
                    //Response.Write("<script>alert('" + PageCnt + "');</script>");
                }
                else
                {
                    
                }

            }
            else
            {
                
            }
        }

        protected void ddl_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sr = ddl_status.SelectedValue.Trim();
            Grid1(sr);
        }

        public Boolean Grid1(string sr)
        {
            Boolean bl;
            UserLogin = Session["UserLogin"].ToString();

            string apStatus = sr;

            sql = "select a.apid, rs.rqid, a.rqsid, concat('[',rs.rqid,'] (',a.rqsid,'.',a.aplevel,')') as 'RequestID', a.apdate, concat('Resuest ',s.sysname) as 'sysname', r.rqrequestuser, concat(r.rqpname,' ',r.rqfname,' ',r.rqlname) as 'UserFullName' " +
                ", d.deptname, a.apstatus, al.aplname " +
                "from brh_it_request.approve as a " +
                "left join (select * from brh_it_request.approvelevel where aplgroup=1) as al on a.aplevel=al.apllevel " +
                "left join brh_it_request.requestsystems as rs on a.rqsid = rs.rqsid " +
                "left join brh_it_request.request as r on r.rqid = rs.rqid " +
                "left join brh_it_request.systems as s on rs.sysid = s.sysid " +
                "left join brh_it_request.`user` as u on a.aprequestuser = u.username " +
                "left join brh_it_request.department as d on r.rqdepartment = d.deptid " +
                "where ";
                if (apStatus == "All")
                {
                    sql += "apstatus like '%%' ";
                }
                else
                {
                    sql += "apstatus = '" + apStatus + "' ";
                }

                string OderBy = "";
                if (UserStatus == "admin" || UserStatus == "it") 
                {
                    if (apStatus == "Wait")
                    {
                        OderBy = "order by rs.rqid, a.rqsid, a.apid";
                    }
                }
                else
                {
                    if (apStatus == "Wait")
                    {
                        sql += "and (a.userid = '" + UserLogin + "' or a.apuserapprove1 = '" + UserLogin + "' or a.apuserapprove2 = '" + UserLogin + "') ";
                        OderBy = "order by rs.rqid, a.rqsid, a.apid";
                    }
                    else
                    {
                        if(apStatus == "All") 
                        { 
                            sql += "and (a.userid = '" + UserLogin + "' or a.apuserapprove1 = '" + UserLogin + "') ";
                        }
                        else
                        {
                            sql += "and a.userid = '" + UserLogin + "' ";
                        }
                    }
                }
                if (OderBy == "")
                {
                    sql += "order by rs.rqid desc, a.rqsid, a.apid desc";
                }
                else
                {
                    sql += OderBy;
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
            if (CommN == "Edit")
            {
                string rqsid = e.CommandArgument.ToString();
                Response.Redirect("ApproveEvent.aspx?id=" + rqsid);
            }
            else if (CommN == "Page")
            {

            }
            else
            {
                Response.Redirect("ApproveList.aspx");
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
                TableCell Event = e.Row.Cells[9];
                Event.Visible = false;

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
                    Event.Visible = true;

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
                    Event.Visible = true;
                    StatusCell.CssClass = "fas fa-times text-danger";
                }
                else { }

            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            string sr = ddl_status.SelectedValue.Trim();
            Grid1(sr);
        }

    }
}