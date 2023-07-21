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
                if (!IsPostBack)
                {
                    SetValue(username);
                }
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
                string pname = dt.Rows[0]["userpname"].ToString();
                string fname = dt.Rows[0]["userfname"].ToString();
                string lname = dt.Rows[0]["userlname"].ToString();

                txt_titleTh.Value = pname;
                txt_titleEng.Value = dt.Rows[0]["userpnameeng"].ToString();
                txt_fnameTh.Value = fname;
                txt_fnameEng.Value = dt.Rows[0]["userfnameeng"].ToString();
                txt_lnameTh.Value = lname;
                txt_lnameEng.Value = dt.Rows[0]["userlnameeng"].ToString();

                Session["UserFullName"] = pname + " " + fname + " " + lname;
            }

            return bl;
        }

        protected void btn_EditName_ServerClick(object sender, EventArgs e)
        {
            sql = "Update brh_it_request.`user` Set " +
                "userpname='" + txt_titleTh.Value.ToString().Trim() + "'," +
                "userpnameeng='" + txt_titleEng.Value.ToString().Trim() + "'," +
                "userfname='" + txt_fnameTh.Value.ToString().Trim() + "'," +
                "userfnameeng='" + txt_fnameEng.Value.ToString().Trim() + "'," +
                "userlname='" + txt_lnameTh.Value.ToString().Trim() + "'," +
                "userlnameeng='" + txt_lnameEng.Value.ToString().Trim() + "'" +
                "WHERE userid=" + userid;
            if (cl_Sql.Modify(sql) == true)
            {
                string username = Session["UserLogin"].ToString();
                SetValue(username);

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