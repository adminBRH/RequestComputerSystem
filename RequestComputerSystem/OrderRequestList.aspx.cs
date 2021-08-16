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
            if (!IsPostBack)
            {
                Status();
                Grid1("Waiting");
            }
        }

        public Boolean Status()
        {
            Boolean bl = false;

            sql = "select 'ALL' as 'Status' union select distinct status from changeorder order by status ";
            dt = new DataTable();
            dt = CL_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
                DD_Status.DataSource = dt;
                DD_Status.DataTextField = "status";
                DD_Status.DataValueField = "status";

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

                DD_Status.DataBind();
            }

            return bl;
        }

        public Boolean Grid1(string status) //Boolean = ใช่ หรือไม่ใช่ คิดไม่ออกนึกถึง boolean ก่อนเสมอ
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

            sql = "Select c.*, CONCAT(u.userpname,' ',u.userfname,' ',u.userlname ) as 'empname', CONCAT(u2.userpname,' ',u2.userfname,' ',u2.userlname ) as 'Approvename' " +
                "\nfrom( " +
                "\n    select rqid, `date`, empid, status " +
                "\n        , IF(Approvelv = '1', Approvelevel1 " +
                "\n            , IF(Approvelv = '2', Approvelevel2 " +
                "\n                , IF(Approvelv = '3', Approvelevel3 " +
                "\n                    , IF(Approvelv = '4', Approvelevel4 " +
                "\n                        , IF(Approvelv = '5', Approvelevel5 " +
                "\n                            , IF(Approvelv = '6', Approvelevel6 " +
                "\n                                , '')))))) as 'ApproveID' " +
                "\n    from changeorder " +
                "\n) as c " +
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
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            return result;
        }

        protected void DD_Status_SelectedIndexChanged(object sender, EventArgs e)
        {
            string status = DD_Status.SelectedValue.ToString();
            Grid1(status);
        }
    }
}