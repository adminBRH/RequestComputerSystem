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
    public partial class OrderRequestList : System.Web.UI.Page
    {
        string sql = "";
        DataTable dt;
        SQLclass CL_Sql = new SQLclass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLogin"] == null)
            {
                Response.Redirect("Default");
            }

            if (!IsPostBack)
            {
                string br_select = "";
                if (Session["userDeptid"] != null)
                {
                    br_select = Session["userDeptid"].ToString();
                }

                Branch(br_select);
                Status();
                Grid1("","Waiting");
            }
        }

        public void Branch(string br_select)
        {
            dt = new DataTable();
            dt = CL_Sql.dt_Branch();

            DD_branch.DataSource = dt;
            DD_branch.DataTextField = "branchname";
            DD_branch.DataValueField = "branchname";
            DD_branch.DataBind();

            string status = Session["UserStatus"].ToString();
            if (status == "admin" || status == "it")
            {
                DD_branch.Items.Insert(0, new ListItem("ALL", ""));
            }
            else
            {
                if (br_select != "")
                {
                    DD_branch.SelectedValue = br_select.Substring(0, 3);
                }
            }
        }

        public Boolean Status()
        {
            Boolean bl = false;

            sql = "select distinct status from changeorder " +
                "\nwhere status <> 'Cancel' order by status ";
            dt = new DataTable();
            dt = CL_Sql.select(sql);
            if (dt.Rows.Count > 0)
            { }

            DD_Status.DataSource = dt;
            DD_Status.DataTextField = "status";
            DD_Status.DataValueField = "status";
            DD_Status.DataBind();
            DD_Status.Items.Insert(0, new ListItem("ALL", "ALL"));

            sql = "select * from changeorder where status = 'Waiting' LIMIT 1 ";
            DataTable dt2 = new DataTable();
            dt2 = CL_Sql.select(sql);
            if (dt2.Rows.Count > 0)
            {
                DD_Status.SelectedValue = "Waiting";
            }
            else
            {
                DD_Status.SelectedValue = "Finish";
            }

            return bl;
        }

        public Boolean Grid1(string branch, string status) //Boolean = ใช่ หรือไม่ใช่ คิดไม่ออกนึกถึง boolean ก่อนเสมอ
        {
            Boolean result = false;
            string loginid = "";
            string userstatus = "";

            if (status == "ALL")
            {
                status = "";
            }
            if (status == "Waiting")
            {
                sql = "select * from changeorder where status = '" + status + "' LIMIT 1  ";
                dt = new DataTable();
                dt = CL_Sql.select(sql);
                if (dt.Rows.Count > 0)
                {
                    
                }
                else
                {
                    status = "Finish";
                }
            }

            if (Session["UserLogin"] != null) //เรียกใช้ Session Login เพื่อนำมาหาข้อมูลของ User นั้นๆ
            {
                loginid = Session["UserLogin"].ToString();
            }

            sql = "Select c.*,d.deptname, CONCAT(ifnull(u.userpname,''),u.userfname,' ',u.userlname ) as 'empname', CONCAT(ifnull(u2.userpname,''),u2.userfname,' ',u2.userlname ) as 'Approvename' " +
                "\nfrom( " +
                "\n    select rqid, deptid, `date`, empid, status " +
                "\n        , IF(Approvelv = '1', Approvelevel1 " +
                "\n            , IF(Approvelv = '2', Approvelevel2 " +
                "\n                , IF(Approvelv = '3', Approvelevel3 " +
                "\n                    , IF(Approvelv = '4', Approvelevel4 " +
                "\n                        , IF(Approvelv = '5', Approvelevel5 " +
                "\n                            , IF(Approvelv = '6', Approvelevel6 " +
                "\n                                , '')))))) as 'ApproveID' " +
                "\n    from changeorder where deptid like '" + branch + "%' " +
                "\n) as c " +
                "\nleft join department as d on d.deptid = c.deptid " +
                "\nleft join `user` as u on u.username = c.empid " +
                "\nleft join `user` as u2 on u2.username = c.ApproveID " +
                "\nWhere c.status like '%" + status + "%' ";
            if (Session["UserStatus"] != null) // เรียกใช้ เงื่อไขี้เพื่อให้ Admin เห็นข้อมูลทั้งหมด และ User เห็นแค่ของตัวเอง
            {
                userstatus = Session["UserStatus"].ToString();
                if (userstatus == "admin" || userstatus == "it")
                {

                }
                else
                {
                    sql = sql + "\nand (c.empid = '" + loginid + "' or c.ApproveID= '" + loginid + "') ";
                }
            }
            sql = sql + "\nOrder by rqid desc ";
           
            dt = new DataTable(); //ต้อง new data table ใหม่ทุกครั้งเมื่อรับค่า
            dt = CL_Sql.select(sql); 

            if (dt.Rows.Count > 0) //หาข้อมูลว่ามีบรรทัดนั้นหรือไม่
            { }

            GridView1.DataSource = dt;
            GridView1.DataBind();

            return result;
        }

        protected void Search()
        {
            string branch = DD_branch.SelectedValue.ToString();
            string status = DD_Status.SelectedValue.ToString();
            Grid1(branch, status);
        }

        protected void DD_branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();

        }

        protected void DD_Status_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }
    }
}