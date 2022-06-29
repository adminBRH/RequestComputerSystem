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
    public partial class ManageHOD : System.Web.UI.Page
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

            Grid1();
        }

        public Boolean Grid1()
        {
            Boolean bl = false;

            sql = "select d.* ,concat(u1.userpname,' ',u1.userfname,' ',u1.userlname) as 'HOD1' " +
                "\n,concat(u2.userpname, ' ', u2.userfname, ' ', u2.userlname) as 'HOD2' " +
                "\nfrom department as d " +
                "\nleft join `user` as u1 on u1.username = d.depthod1 " +
                "\nleft join `user` as u2 on u2.username = d.depthod2 " +
                "\nwhere d.deptactive = 'yes' " +
                "\nOrder by d.deptname ";
            dt = new DataTable();
            dt = CL_Sql.select(sql);
            if (dt.Rows.Count>0)
            {
                bl = true;
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();

            return bl;
        }

        protected void btn_edit_ServerClick(object sender, EventArgs e)
        {
            string status = Session["UserStatus"].ToString();
            if (status == "hr" || status == "admin")
            {
                div_edit.Visible = true;
                lbl_edit_alert.Text = "";

                string deptid = txtH_ID.Value.ToString();
                sql = "select d.* ,concat(u1.userpname,' ',u1.userfname,' ',u1.userlname) as 'HOD1' " +
                    "\n,concat(u2.userpname, ' ', u2.userfname, ' ', u2.userlname) as 'HOD2' " +
                    "\nfrom department as d " +
                    "\nleft join `user` as u1 on u1.username = d.depthod1 " +
                    "\nleft join `user` as u2 on u2.username = d.depthod2 " +
                    "\nwhere deptid = '" + deptid + "' ";
                dt = new DataTable();
                dt = CL_Sql.select(sql);
                if (dt.Rows.Count > 0)
                {
                    lbl_deptname.Text = dt.Rows[0]["deptname"].ToString();
                    txt_hod1id.Value = dt.Rows[0]["depthod1"].ToString();
                    txt_hod1name.Value = dt.Rows[0]["HOD1"].ToString();
                    txt_hod2id.Value = dt.Rows[0]["depthod2"].ToString();
                    txt_hod2name.Value = dt.Rows[0]["HOD2"].ToString();
                    div_edit_btn.Visible = true;
                }
            }
            else
            {
                div_edit_btn.Visible = false;
                lbl_edit_alert.Text = "คุณไม่มีสิทธิ์กระทำการ กรุณาติดต่อ HR เพื่อทำการปรับเปลี่ยน !!";
            }
        }

        protected void btn_update_ServerClick(object sender, EventArgs e)
        {
            string mUser = Session["UserLogin"].ToString();
            string deptid = txtH_ID.Value.ToString();
            string hod1 = txt_hod1id.Value.ToString().Trim();
            string hod2 = txt_hod2id.Value.ToString().Trim();

            string alert = "";

            sql = "select * from `user` where username = '" + hod1 + "'; ";
            dt = new DataTable();
            dt = CL_Sql.select(sql);
            if (dt.Rows.Count <= 0)
            {
                alert = "ไม่มีรหัสหัวหน้าแผนก " + hod1 + " นี้ ในระบบ !!";
            }

            if (hod2 != "")
            {
                sql = "select * from `user` where username = '" + hod2 + "'; ";
                dt = new DataTable();
                dt = CL_Sql.select(sql);
                if (dt.Rows.Count <= 0)
                {
                    alert += "<br />ไม่มีรหัสหัวหน้าฝ่าย " + hod2 + " นี้ ในระบบ !!";
                }
            }

            if (alert == "")
            {
                sql = "update department set depthod1 = '" + hod1 + "', depthod2 = '" + hod2 + "', " +
                    "\ndept_mdate = CURRENT_TIMESTAMP, dept_muser = '" + mUser + "' " +
                    "\nwhere deptid = '" + deptid + "'; ";
                if (CL_Sql.Modify(sql))
                {
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    alert = "ไม่สามารถบันทึกข้อมูลได้ กรุณาติดต่อผู้ดูแลระบบ !!";
                }
            }

            lbl_edit_alert.Text = alert;
        }
    }
}