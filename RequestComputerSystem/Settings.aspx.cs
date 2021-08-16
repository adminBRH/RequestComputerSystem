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
    public partial class Settings : System.Web.UI.Page
    {
        string sql = "";
        DataTable dt;
        SQLclass cl_Sql = new SQLclass();

        string userid = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLogin"] != null)
            {
                userid = Session["UserID"].ToString();

                lbl1.Text = "<b>Name : </b>" + Session["UserFullName"].ToString();
                string username = Session["UserLogin"].ToString();
                SetValue(username);
            }
            
        }

        public Boolean SetValue(string user)
        {
            Boolean bl = false;

            sql = "select * from brh_it_request.`user` where userid=" + userid;
            dt = new DataTable();
            dt = cl_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
                txt_tiltle.Text = dt.Rows[0]["userpname"].ToString();
                txt_tiltle_eng.Text = dt.Rows[0]["userpnameeng"].ToString();
                txt_fname.Text = dt.Rows[0]["userfname"].ToString();
                txt_fname_eng.Text = dt.Rows[0]["userfnameeng"].ToString();
                txt_lname.Text = dt.Rows[0]["userlname"].ToString();
                txt_lname_eng.Text = dt.Rows[0]["userlnameeng"].ToString();
            }

            return bl;
        }

        protected void btn_EdName_Click(object sender, EventArgs e)
        {
            sql = "Update brh_it_request.`user` Set " +
                "userpname='" + txt_tiltle.Text.Trim() + "'," +
                "userpnameeng='" + txt_tiltle_eng.Text.Trim() + "'," +
                "userfname='" + txt_fname.Text.Trim() + "'," +
                "userfnameeng='" + txt_fname_eng.Text.Trim() + "'," +
                "userlname='" + txt_lname.Text.Trim() + "'," +
                "userlnameeng='" + txt_lname_eng.Text.Trim() + "'" +
                "WHERE userid=" + userid;
            if (cl_Sql.Modify(sql) == true)
            {
                Response.Write("<script>alert('บันทึกข้อมูลเรียบร้อยแล้ว !!'); setTimeout(function () { window.location.href = 'Settings.aspx' }, 50);</script>");
            }
        }

        protected void btn_EdPass_Click(object sender, EventArgs e)
        {
            string PassOld = txt_PassOld.Value.ToString().Trim();
            string PassConf = txt_PassConf.Value.ToString().Trim();
            string username = Session["UserLogin"].ToString();
            string DateEdit = DateTime.Now.ToString(("yyyy-MM-dd"));

            class_MD5 cl_MD5 = new class_MD5();

            PassOld = cl_MD5.MD5Hash(PassOld);

            sql = "select * from brh_it_request.`user` as u where u.username=" + username + " and userpassword='" + PassOld + "' ";
            dt = new DataTable();
            dt = cl_Sql.select(sql);
            if (dt.Rows.Count == 0)
            {
                Response.Write("<script>alert('Old Password ไม่ถูกต้อง !!');</script>");
            }
            else
            {
                PassConf = cl_MD5.MD5Hash(PassConf);

                string userid = dt.Rows[0]["userid"].ToString();

                sql = "update brh_it_request.`user` set userpassword='" + PassConf + "', useridedit=" + username + ", userdateedit='" + DateEdit + "' where userid=" + userid;
                if (cl_Sql.Modify(sql) == true)
                { Response.Write("<script>alert('เปลี่ยน Password เรียบร้อยแล้ว !!'); setTimeout(function(){window.location.href='Login.aspx?logout=cookie'}, 500);</script>"); }
                else
                { Response.Write("<script>alert('ไม่สามารถเปลี่ยน Password ได้ กรุณาติดต่อ Admin !!');</script>"); }
            }
        }
    }
}