using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;

namespace RequestComputerSystem
{
    public partial class PayOvertimeDefault : System.Web.UI.Page
    {
        string sql = "";
        DataTable dt;
        SQLclass CL_Sql = new SQLclass();

        Files CL_Files = new Files();

        string hrid = "hr";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLogin"] == null)
            {
                Response.Redirect("Default");
            }

            string status = Session["UserStatus"].ToString();

            if (status == "admin" || status == "test" || status == "hr") { }
            else
            {
                if (Session["HOD"].ToString() == "No")
                {
                    Response.Write("<script>alert('หน้าการร้องขอใช้งานระบบคอมพิวเตอร์ ให้สิทธิเฉพาะระดับหัวหน้าแผนกขึ้นไปเท่านั้น !!'); setTimeout(function(){window.location.href='Default.aspx'}, 100);</script>");
                }
            }

            if (!IsPostBack)
            {    
                department();
                Searchhod2();
            }
        }
        public Boolean department()
        {
            Boolean result = false;

            sql = "SELECT deptid,deptname FROM brh_it_request.department order by deptname";
            dt = new DataTable();
            dt = CL_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
                dd_department.DataSource = dt;
                dd_department.DataTextField = "deptname";
                dd_department.DataValueField = "deptid";
                dd_department.DataBind();

                result = true;
            }

            return result;
        }

        public string Searchhod2()
        {
            String result = "";

            sql = "SELECT * FROM brh_it_request.department WHERE deptid='" + dd_department.SelectedValue + "' ";
            dt = new DataTable();
            dt = CL_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
                string hod1 = dt.Rows[0]["depthod1"].ToString();
                string hod2 = dt.Rows[0]["depthod2"].ToString();

                result = hod1;

                sql = "select *,concat(userpname,' ',userfname,' ',userlname) as 'fullname'  from `user` where username = '" + result + "' ";
                dt = new DataTable();
                dt = CL_Sql.select(sql);
                if (dt.Rows.Count > 0)
                {
                    lbl_HOD1.Text = "หัวหน้าแผนก : " + dt.Rows[0]["fullname"].ToString();
                }

                result = hod2;

                if (result == "")
                {
                    lbl_HOD2.Text = "";
                    result = "-";
                }
                else
                {
                    sql = "select *,concat(userpname,' ',userfname,' ',userlname) as 'fullname'  from `user` where username = '" + result + "' ";
                    dt = new DataTable();
                    dt = CL_Sql.select(sql);
                    if (dt.Rows.Count > 0)
                    {
                        lbl_HOD2.Text = "หัวหน้าฝ่าย : " + dt.Rows[0]["fullname"].ToString();
                    }
                }
            }
            else
            {
                lbl_HOD2.Text = "";
            }

            return result;
        }


        protected void dd_department_SelectedIndexChanged(object sender, EventArgs e)
        {
            Searchhod2();
        }

        public Boolean Insertdata()
        {
            Boolean result = false;

            string dropdownlist = dd_department.SelectedValue.ToString();
            string dateinput = DateTime.Now.Year.ToString()+ "-" + ddl_month.SelectedValue.ToString() + "-01";
            string hodid = Searchhod2();
            string hodstatus = "wait";
            string hrstatus = "";
            string userid = "";


            if (Session["UserLogin"] != null)
            {
                userid = Session["UserLogin"].ToString();
            }

            if (hodid == "-")
            {
                hrstatus = "wait";
                hodstatus = "approved";
            }

            sql = "INSERT INTO payovertime" +
                    "(user_id, dept_id, hod_id, hod_status, hr_id, hr_status, pt_time, pt_status, hr_date, date_request)" +
                    "VALUES('" + userid + "', '" + dropdownlist + "', '" + hodid + "', '" + hodstatus + "', '" + hrid + "', '" + hrstatus + "', current_timestamp(), 'wait', current_timestamp(), '"+ dateinput + "');";

            if (CL_Sql.Modify(sql))
            {
                string ptid = CL_Sql.LastID("pt_id", "payovertime");
                if (ptid != "")
                {
                    UploadFile(ptid);

                    result = true;

                    string UserMail = hodid;
                    if (hodid == "-")
                    {
                        UserMail = hrid;
                    }

                    SendMail(UserMail, ptid);

                }
            }

            return result;
        }

        public Boolean UploadFile(string id)
        {
            Boolean bl = false;

            if (FileUpload1.HasFile)
            {
                string Path = "~/FileUploadPay/FilePayOvertime/";
                string FileName = "";
                foreach (HttpPostedFile uploadFile in FileUpload1.PostedFiles)
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

        public Boolean checkFile()
        {
            Boolean bl = false;

            string FileName = "";
            string FileType = "";

            string FileExcel = "";
            string FilePDF = "";

            if (FileUpload1.HasFile)
            {
                foreach (HttpPostedFile uploadFile in FileUpload1.PostedFiles)
                {
                    FileName = uploadFile.FileName;
                    string[] exts = FileName.ToString().Split('.');
                    int maxIndex = exts.Length - 1;
                    FileName = exts[0].ToString();
                    FileType = exts[maxIndex].ToString();

                    if (FileType == "xls" || FileType == "xlsx" || FileType == "ods")
                    {
                        FileExcel = "yes";
                    }
                    if (FileType == "PDF" || FileType == "pdf")
                    {
                        FilePDF = "yes";
                    }
                }
            }

            if (FileExcel == "yes" && FilePDF == "yes")
            {
                bl = true;
            }

            return bl;
        }

        public string SendMail(string userid, string ptid)
        {
            string rt = "";

            sql = "select *,CONCAT(u.userpname,' ',u.userfname,' ',u.userlname) as 'ApvName'  from `user` as u where u.username = '" + userid + "' ";
            dt = new DataTable();
            dt = CL_Sql.select(sql);

            string emailTo = dt.Rows[0]["useremail"].ToString();

            if (Session["Test"] != null) // --------------------------- For Test -------------------------
            {
                if (Session["Test"].ToString() == "yes") { emailTo = "brh.coo@brh.co.th"; }
            }

            string emailFrom = "info.RequestSystem@brh.co.th";
            string ApvName = dt.Rows[0]["ApvName"].ToString();
            string CreateDate = DateTime.Now.Date.ToString();

            if (dt.Rows.Count > 0)
            {
                string htmlBody = "<h1 style='color: #4485b8;'>Pay Overtime Request.</h1>" +
                            "<p><strong style='color: #000;'>Pay Request ID:</strong> &nbsp; " + ptid + " </p>" +
                            "<p><strong style='color: #000;'> Create Date:</strong> &nbsp; " + CreateDate + " </p>" +
                            "<p><strong style='color: #000;'> Waiting approval by:</strong> &nbsp; " + ApvName + " </p>" +
                            "<p><a href='http://10.121.10.212:4001/Login?goto=PayOvertimeList'>Link : Access to the system.</a></p>" +
                            "<p></p><p></p><p>Please do not reply to this email because this address is not monitored.</p>" +
                            "<p>Automatic send by Request Systems.</p>";

                try
                {
                    BRH_SendMail.ServiceSoapClient BRHmail = new BRH_SendMail.ServiceSoapClient();
                    BRHmail.MailSend(emailTo, "Pay Overtime Request", htmlBody, emailFrom, "Systems Request", "", "", "", false);
                    lbl_alert.Text = "ส่ง Email ถึงคนที่ต้อง Approve เรียบร้อยแล้ว !!";
                    lbl_alert.ForeColor = System.Drawing.Color.Green;
                }
                catch
                {
                    lbl_alert.Text = "ไม่สามารถส่ง Email ถึงคนที่ Approve ได้ กรุราติดต่อผู้ดูแลระบบ !!";
                }

                rt = "success";
            }

            return rt;
        }

        protected void submit_ServerClick(object sender, EventArgs e)
        {
            string checkFileName = "";
            string FileName = FileUpload1.FileName;
            if (FileName != "")
            {
                checkFileName = CL_Files.FileNameNotUse(FileName);
            }

            lbl_fileAlert.Text = "";

            if (checkFileName == "")
            {
                if (checkFile())
                {
                    if (Insertdata())
                    {
                        Response.Write("<script>alert('บันทึกสำเร็จ'); window.location.href='PayOvertimeList.aspx';</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('ไม่สามารถบันทึกได้กรุณาติดต่อ Admin');</script>");
                    }
                }
                else
                {
                    lbl_alert.Text = "คุณต้องแนบไฟล์ Excel และ PDF ทั้งสองอย่าง !!";
                }
            }
            else
            {
                lbl_fileAlert.Text = "<br />" + checkFileName;
                lbl_fileAlert.ForeColor = System.Drawing.Color.Red;
            }
        }

    }
}