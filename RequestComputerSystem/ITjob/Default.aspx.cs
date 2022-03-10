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
                    string deptid = Session["UserDeptid"].ToString();
                    Approval(deptid);
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

        private string Approval(string deptid)
        {
            string result = "";
            string approval = "";
            int i = 1;

            lbl_approval.Text = "ผู้อนุมัติ...";

            sql = "select d.*,concat(u1.userpname,' ',u1.userfname,' ',u1.userlname) as username1 " +
                ",concat(u2.userpname,' ',u2.userfname,' ',u2.userlname) as username2 " +
                "\nfrom department as d " +
                "\nleft join `user` as u1 on u1.username = d.depthod1 " +
                "\nleft join `user` as u2 on u2.username = d.depthod2 " +
                "\nwhere deptid = '" + deptid + "'; ";
            dt = new DataTable();
            dt = cl_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
                string username1 = dt.Rows[0]["username1"].ToString();
                string username2 = dt.Rows[0]["username2"].ToString();

                approval = "ผู้อนุมัติลำดับที่<br />" + i + ". " + username1;
                if (username2 != "") 
                {
                    i++;
                    approval += "<br />" + i + ". " + username2;
                }
                i++;
            }

            sql = "select ia.*,concat(u.userpname,' ',u.userfname,' ',u.userlname) as username " +
                "\nfrom itjob_approval as ia " +
                "\nleft join `user` as u on u.username = ia.ita_empid " +
                "\nwhere ia.ita_empid <> '' order by ia.ita_level; ";
            dt = new DataTable(); ;
            dt = cl_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (approval != "") { approval += "<br />"; }
                    approval += i + ". " + dr["username"].ToString();
                    i++;
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

        public Boolean checkFile()
        {
            Boolean bl = true;

            string FileName = "";
            string FileType = "";

            if (File_attach.HasFile)
            {
                foreach (HttpPostedFile uploadFile in File_attach.PostedFiles)
                {
                    FileName = uploadFile.FileName;
                    string[] exts = FileName.ToString().Split('.');
                    int maxIndex = exts.Length - 1;
                    FileName = exts[0].ToString();
                    FileType = exts[maxIndex].ToString().ToLower();

                    if (FileType == "exe" || FileType == "dll" || FileType == "bat")
                    {
                        bl = false;
                    }
                }
            }

            return bl;
        }

        public Boolean UploadFile(string id)
        {
            Boolean bl = false;

            if (File_attach.HasFile)
            {
                string Path = "/file/";
                string FileName = "";
                foreach (HttpPostedFile uploadFile in File_attach.PostedFiles)
                {
                    FileName = uploadFile.FileName;
                    string[] exts = FileName.ToString().Split('.');
                    int maxIndex = exts.Length - 1;
                    FileName = exts[0].ToString() + ",id" + id + "." + exts[maxIndex].ToString();
                    uploadFile.SaveAs(System.IO.Path.Combine(Server.MapPath(Path), FileName));
                    bl = true;
                }
            }
            return bl;
        }

        protected void btn_submit_ServerClick(object sender, EventArgs e)
        {
            // ทำถึงการ เช็ค และ อัพโหลด ไฟล์ ตอนกดบันทึก
        }
    }
}