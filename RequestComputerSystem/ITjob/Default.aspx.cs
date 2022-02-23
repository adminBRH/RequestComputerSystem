using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace RequestComputerSystem.ITjob
{
    public partial class Default : System.Web.UI.Page
    {
        string sql = "";
        DataTable dt;
        SQLclass cl_Sql = new SQLclass();
        BRH_SendMail.ServiceSoapClient BRHmail;

        string userlogin = "";
        string userFullname = "";

        string MainID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLogin"] == null)
            {
                Response.Redirect("Default");
            }
            else
            {
                if (!IsPostBack)
                {
                    lbl_requester.Text = Session["UserFullName"].ToString();
                    Approval();
                    Category();
                }
            }
        }

        private void Category()
        {
            sql = "select * from itjob_category where itc_active='yes' order by itc_name; ";
            dt = new DataTable();
            dt = cl_Sql.select(sql);
            if (dt.Rows.Count > 0)
            { }
            DD_cate.DataSource = dt;
            DD_cate.DataTextField = "itc_name";
            DD_cate.DataValueField = "itc_id";
            DD_cate.DataBind();
            DD_cate.Items.Insert(0, new ListItem("เลือกหมวดหมู่การร้องขอ", ""));
        }

        private void Subcate(string id)
        {
            sql = "select * from itjob_subcate where its_active = 'yes' and its_itcid='" + id + "' order by its_name; ";
            dt = new DataTable();
            dt = cl_Sql.select(sql);
            if (dt.Rows.Count <= 0)
            { }
            RB_subcate.DataSource = dt;
            RB_subcate.DataTextField = "its_name";
            RB_subcate.DataValueField = "its_id";
            RB_subcate.DataBind();
        }

        private string Approval()
        {
            string result = "";

            sql = "select a.*,u.username,u.userpname,u.userfname,u.userlname,u.userdeptcode " +
                "\nfrom it_approval as a " +
                "\nleft join `user as u on u.username = a.ita_empid " +
                "\nwhere ita_active = 'yes' order by ita_level ; ";
            dt = new DataTable(); ;
            dt = cl_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
                string approval = "";
                int i = 1;
                foreach (DataRow dr in dt.Rows)
                {
                    if (i == 1)
                    {
                        result = dr["username"].ToString();
                    }
                    if (approval != "") { approval += "<br />"; }
                    approval = "ผู้อนุมัติลำดับที่ " + i + " " + dr["userpname"].ToString() + " " + dr["userfname"].ToString() + " " + dr["userlname"].ToString();
                }
                lbl_approval.Text = approval;
            }
            return result;
        }

        protected void DD_cate_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cateID = DD_cate.SelectedValue;
            if (cateID == "")
            {
                File_attach.Visible = false;
            }
            else
            {
                File_attach.Visible = true;
            }

            Subcate(cateID);
        }
    }
}