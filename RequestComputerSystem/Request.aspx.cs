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
    public partial class Request : System.Web.UI.Page
    {
        SQLclass cl_Sql = new SQLclass();
        DataTable dt;
        string sql = "";

        string HOD = "";
        string Staff = "";
        string Committee = "";
        string userid = "";
        string RequestID = "";

        string LastID = "";

        string jquery1 = "";
        string jquery2 = "";
        string jquery = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLogin"] == null)
            {
                Response.Redirect("Default");
            }

            if (!IsPostBack)
            {
                userid = Session["UserLogin"].ToString();
                string status = Session["UserStatus"].ToString();

                if (status == "admin" || status == "test")
                { }
                else
                {
                    if (Session["HOD"].ToString() == "No")
                    {
                        Response.Write("<script>alert('หน้าการร้องขอใช้งานระบบคอมพิวเตอร์ ให้สิทธิเฉพาะระดับหัวหน้าแผนกขึ้นไปเท่านั้น !!'); setTimeout(function(){window.location.href='Default.aspx'}, 100);</script>");
                    }
                }

                Pname();
                Department();
                ApproveName();
            }
            else
            {
                if (CL_validate().ToString() == "y")
                {
                    if (CL_Insert() == true)
                    {
                        Response.Write("<script>alert('บันทึกข้อมูลเรียบร้อยแล้ว !!'); setTimeout(function(){window.location.href='RequestList.aspx'}, 10);</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('ล้มเหลว ไม่สามารถบันทึกข้อมูลได้ !!');</script>");
                    }
                }
            }

        } // else PostBack

        public Boolean Pname()
        {
            Boolean bl = false;

            sql = "select * from prename where pactive = 'Y' ";
            dt = new DataTable();
            dt = cl_Sql.select(sql);

            ddl_pname.DataSource = dt;
            ddl_pname.DataTextField = "pname";
            ddl_pname.DataValueField = "pname";
            ddl_pname.DataBind();

            return bl;
        }

        public Boolean Department()
        {
            Boolean bl = false;

            sql = "select * from department where (depthod1<>'' or depthod1 is not null) order by deptname";
            DataTable dt3 = new DataTable();
            dt3 = cl_Sql.select(sql);

            InDept.DataSource = dt3;
            InDept.DataTextField = "deptname";
            InDept.DataValueField = "deptid";
            InDept.DataBind();

            return bl;
        }

        public Boolean ApproveName()
        {
            Boolean bl = false;

            string dept = "";
            dept = InDept.SelectedValue.ToString();

            sql = "select d.*, concat(u.userpname,' ',u.userfname,' ',u.userlname) as 'name', concat(u2.userpname,' ',u2.userfname,' ',u2.userlname) as 'name2' " +
                "from department as d " +
                "left join `user` as u on u.username = d.depthod1 " +
                "left join `user` as u2 on u2.username = d.depthod2 " +
                "where d.deptid = '" + dept + "'";
            dt = new DataTable();
            dt = cl_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
                lbl_approval.Visible = true;
                string Approval = "";
                Approval = "หัวหน้าแผนก: " + dt.Rows[0]["name"].ToString();
                lbl_approval.Text = Approval;

                if (dt.Rows[0]["name2"].ToString() != "")
                {
                    lbl_approval2.Visible = true;
                    Approval = "ผจก.สายงาน: " + dt.Rows[0]["name2"].ToString();
                    lbl_approval2.Text = Approval;
                }
                else
                {
                    lbl_approval2.Visible = false;
                }

            }

            return bl;
        }

        protected void InDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApproveName();
        }

        public string CL_validate()
        {
            // Page Load -----------------------------------------------------------------------------
            jquery1 = "$(document).ready(function () { $(\"#form1\").on(\"submit\", function () { ";
            jquery = "$(\"#pageloader\").fadeIn();";
            jquery2 = " }); });";
            jquery = jquery1 + jquery + jquery2;
            Page.ClientScript.RegisterStartupScript(typeof(Page), "a key", "<script type=\"text/javascript\">" + jquery + "</script>");

            string Ctn = "n";
                if (Cb_Bconnect.Checked == true || Cb_Email.Checked == true || Cb_VPN.Checked == true || Cb_MS.Checked == true
                    || Cb_SwL.Checked == true || Cb_IPP.Checked == true || Cb_Com.Checked == true)
                {
                    lblCb_Bconnect.Visible = false;
                    lblCb_Email.Visible = false;
                    lblCb_VPN.Visible = false;
                    lblCb_MS.Visible = false;
                    lblCb_SwL.Visible = false;
                    lblCb_IPP.Visible = false;
                    lblCb_Com.Visible = false;

                    Ctn = "y";
                    if (Cb_Email.Checked)
                    {
                        if (txtEmail.Text == "")
                        {
                            txtEmailValidator.Enabled = true;
                            Ctn = "n";
                        }
                        else
                        {
                            txtEmailValidator.Enabled = false;
                        }

                        if (dd_Quota.SelectedValue == "")
                        {
                            dd_QuotaValidator.Enabled = true;
                            Ctn = "n";
                        }
                        else
                        {
                            dd_QuotaValidator.Enabled = false;
                        } 

                        if (cb_hod.Checked || cb_staff.Checked || cb_committee.Checked)
                        {
                            if (cb_hod.Checked) { HOD = cb_hod.Value.ToString(); }
                            if (cb_staff.Checked) { Staff = cb_staff.Value.ToString(); }

                        lblcb_groupmail.Visible = false;
                            if (cb_committee.Checked)
                            {
                                if (txt_commmitee.Text == "")
                                {
                                    txt_commmiteeValidator.Enabled = true;
                                    Ctn = "n";
                                }
                                else
                                {
                                    txt_commmiteeValidator.Enabled = false;
                                    Committee = txt_commmitee.Text.Trim();
                                }
                            }
                            else
                            {
                                txt_commmiteeValidator.Enabled = false;
                            }
                        }
                        else
                        {
                            lblcb_groupmail.Visible = true;
                            Ctn = "n";
                        }
                    }
                }
                else
                {
                    lblCb_Bconnect.Visible = true;
                    lblCb_Email.Visible = true;
                    lblCb_VPN.Visible = true;
                    lblCb_MS.Visible = true;
                    lblCb_SwL.Visible = true;
                    lblCb_IPP.Visible = true;
                    lblCb_Com.Visible = true;
                Ctn = "n";
                }

                if (Ctn == "n")
                {
                    lblAlert.ForeColor = System.Drawing.Color.Red;
                    //lblAlert.Text = "กรุณากรอกให้ครบถ้วน !!";
                }
                else
                {
                    lblAlert.ForeColor = System.Drawing.Color.Green;
                    //lblAlert.Text = "Success !!";
                }
            return Ctn;
        }

        public Boolean CL_Insert()
        {
            //try
            //{
                Boolean bl;

                userid = Session["UserLogin"].ToString();
                string rqtype = "Request";
                string rqrequestuser = InUsername.Value.ToString().Trim();
                string rqstatus = "process";
                string rqdateadd = DateTime.Now.ToString(("yyyy-MM-dd HH:mm:ss"));
                string rqpname = ddl_pname.SelectedValue.ToString();
                string rqfname = InFName.Value.ToString().Trim();
                string rqlname = InLName.Value.ToString().Trim();
                string rqfnameeng = InFNameEng.Value.ToString().Trim();
                string rqlnameeng = InLNameEng.Value.ToString().Trim();
                string rqpost = InPost.Value.ToString().Trim();
                string rqdepartment = InDept.SelectedValue.Trim();
                string rqfaction = InFaction.Value.ToString().Trim();
                string rqphone = InPhone.Value.ToString().Trim();
                string rqspecailty = Specailty.Value.ToString().Trim();
                string rqcodecare = CodeCare.Value.ToString().Trim();
                string rqlocation = Location.Value.ToString().Trim();

            string sql = "INSERT INTO request" +
                             "(userid, rqtype, rqrequestuser, rqstatus, rqdateadd, rqpname, rqfname, rqlname, rqfnameeng, rqlnameeng, rqpost, rqdepartment, rqfaction, rqphone, rqspecailty, rqcodecare, rqlocation)" +
                             "VALUES('" + userid + "', '"+ rqtype + "', '" + rqrequestuser + "', '" + rqstatus + "', '" + rqdateadd + "', '" + rqpname + "', '" + rqfname + "', '" + rqlname + "', '" + rqfnameeng + "', '" + rqlnameeng + "', '" + rqpost + "', '" + rqdepartment + "', '" + rqfaction + "', '" + rqphone + "', '" + rqspecailty + "', '" + rqcodecare + "', '" + rqlocation + "')";
                bl = cl_Sql.Modify(sql);
                if (bl == true)
                {
                    LastID = cl_Sql.LastID("rqid", "request"); //id , table
                    RequestID = LastID;

                    sql = "select r.*,d.depthod1,d.depthod2 from request as r " +
                        "left join department as d on r.rqdepartment = d.deptid " +
                        "where rqid = " + LastID;
                    dt = new DataTable();
                    dt = cl_Sql.select(sql);

                    string Approve1 = dt.Rows[0]["depthod1"].ToString();
                    string Approve2 = dt.Rows[0]["depthod2"].ToString();
                    if (Approve2 == "") { Approve2 = "0"; }

                    string LastID2 = "";

                    string rqsemail = txtEmail.Text.Trim();
                    string rqsquota = dd_Quota.SelectedValue.ToString();

                    if (Cb_Bconnect.Checked == true)
                    {
                    // 1 = B-Connect
                    // 6 = Arcus Air
                        sql = "INSERT INTO requestsystems" +
                            "(rqid, sysid, rqsflag) " +
                            "VALUES("+ LastID + ", 6, NULL);";
                        bl = cl_Sql.Modify(sql);
                        if (bl == true)
                        {
                            LastID2 = cl_Sql.LastID("rqsid", "requestsystems"); //id , table

                            sql = "INSERT INTO approve " +
                                "(rqsid, aplevel, userid, aprequestuser, apstatus, apuserapprove1, apdate) " +
                                "VALUES("+ LastID2 + ", 1, '"+ userid + "', '"+ rqrequestuser + "', 'Approved', 0, '" + rqdateadd + "')";
                            bl = cl_Sql.Modify(sql);


                        if (rqdepartment == "BRH7112") //By pass อ.จารุวัฑ
                        {
                            Approve2 = "0";
                        }

                            sql = "INSERT INTO approve " +
                                "(rqsid, aplevel, userid, aprequestuser, apstatus, apuserapprove1, apuserapprove2, apdate) " +
                                "VALUES(" + LastID2 + ", 2, '0', '" + rqrequestuser + "', 'Wait', '" + Approve1 + "', '" + Approve2 + "', '" + rqdateadd + "')";
                            bl = cl_Sql.Modify(sql);
                        }
                    }
                    if (Cb_VPN.Checked == true)
                    {
                        sql = "INSERT INTO requestsystems" +
                            "(rqid, sysid, rqsflag)" +
                            "VALUES(" + LastID + ", 3, NULL)";
                        bl = cl_Sql.Modify(sql);
                        if (bl == true)
                        {
                            LastID2 = cl_Sql.LastID("rqsid", "requestsystems"); //id , table

                            sql = "INSERT INTO approve " +
                                "(rqsid, aplevel, userid, aprequestuser, apstatus, apuserapprove1, apdate) " +
                                "VALUES(" + LastID2 + ", 1, '" + userid + "', '" + rqrequestuser + "', 'Approved', 0, '" + rqdateadd + "')";
                            bl = cl_Sql.Modify(sql);

                            sql = "INSERT INTO approve " +
                                "(rqsid, aplevel, userid, aprequestuser, apstatus, apuserapprove1, apuserapprove2, apdate) " +
                                "VALUES(" + LastID2 + ", 2, '0', '" + rqrequestuser + "', 'Wait', '" + Approve1 + "', '" + Approve2 + "', '" + rqdateadd + "')";
                            bl = cl_Sql.Modify(sql);
                        }
                    }
                    if (Cb_MS.Checked == true)
                    {
                        sql = "INSERT INTO requestsystems" +
                            "(rqid, sysid, rqsflag)" +
                            "VALUES(" + LastID + ", 4, NULL)";
                        bl = cl_Sql.Modify(sql);
                        if (bl == true)
                        {
                            LastID2 = cl_Sql.LastID("rqsid", "requestsystems"); //id , table

                            sql = "INSERT INTO approve " +
                                "(rqsid, aplevel, userid, aprequestuser, apstatus, apuserapprove1, apdate) " +
                                "VALUES(" + LastID2 + ", 1, '" + userid + "', '" + rqrequestuser + "', 'Approved', 0, '" + rqdateadd + "')";
                            bl = cl_Sql.Modify(sql);

                            sql = "INSERT INTO approve " +
                                "(rqsid, aplevel, userid, aprequestuser, apstatus, apuserapprove1, apuserapprove2, apdate) " +
                                "VALUES(" + LastID2 + ", 2, '0', '" + rqrequestuser + "', 'Wait', '" + Approve1 + "', '" + Approve2 + "', '" + rqdateadd + "')";
                            bl = cl_Sql.Modify(sql);
                        }
                    }
                    if (Cb_Email.Checked == true)
                    {
                        sql = "INSERT INTO requestsystems" +
                            "(rqid, sysid, rqsemail, rqsquota, rqsgroupmail_hod, rqsgroupmail_staff, rqsgroupmail_committeeother, rqsflag)" +
                            "VALUES(" + LastID + ", 2, '" + rqsemail + "', '"+ rqsquota + "', '"+ HOD + "', '" + Staff + "', '" + Committee + "', NULL)";
                        bl = cl_Sql.Modify(sql);
                        if (bl == true)
                        {
                            LastID2 = cl_Sql.LastID("rqsid", "requestsystems"); //id , table

                            sql = "INSERT INTO approve " +
                                "(rqsid, aplevel, userid, aprequestuser, apstatus, apuserapprove1, apdate) " +
                                "VALUES(" + LastID2 + ", 1, '" + userid + "', '" + rqrequestuser + "', 'Approved', 0, '" + rqdateadd + "')";
                            bl = cl_Sql.Modify(sql);

                            sql = "INSERT INTO approve " +
                                "(rqsid, aplevel, userid, aprequestuser, apstatus, apuserapprove1, apuserapprove2, apdate) " +
                                "VALUES(" + LastID2 + ", 2, '0', '" + rqrequestuser + "', 'Wait', '" + Approve1 + "', '" + Approve2 + "', '" + rqdateadd + "')";
                            bl = cl_Sql.Modify(sql);
                        }
                    }
                    if (Cb_SwL.Checked == true)
                    {
                        sql = "INSERT INTO requestsystems" +
                            "(rqid, sysid, rqsemail, rqsquota, rqsgroupmail_hod, rqsgroupmail_staff, rqsgroupmail_committeeother, rqsflag)" +
                            "VALUES(" + LastID + ", 7, '" + rqsemail + "', '"+ rqsquota + "', '"+ HOD + "', '" + Staff + "', '" + Committee + "', NULL)";
                        bl = cl_Sql.Modify(sql);
                        if (bl == true)
                        {
                            LastID2 = cl_Sql.LastID("rqsid", "requestsystems"); //id , table

                            sql = "INSERT INTO approve " +
                                "(rqsid, aplevel, userid, aprequestuser, apstatus, apuserapprove1, apdate) " +
                                "VALUES(" + LastID2 + ", 1, '" + userid + "', '" + rqrequestuser + "', 'Approved', 0, '" + rqdateadd + "')";
                            bl = cl_Sql.Modify(sql);

                            sql = "INSERT INTO approve " +
                                "(rqsid, aplevel, userid, aprequestuser, apstatus, apuserapprove1, apuserapprove2, apdate) " +
                                "VALUES(" + LastID2 + ", 2, '0', '" + rqrequestuser + "', 'Wait', '" + Approve1 + "', '" + Approve2 + "', '" + rqdateadd + "')";
                            bl = cl_Sql.Modify(sql);
                        }
                    }
                    if (Cb_IPP.Checked == true)
                    {
                        sql = "INSERT INTO requestsystems" +
                            "(rqid, sysid, rqsemail, rqsquota, rqsgroupmail_hod, rqsgroupmail_staff, rqsgroupmail_committeeother, rqsflag)" +
                            "VALUES(" + LastID + ", 8, '" + rqsemail + "', '"+ rqsquota + "', '"+ HOD + "', '" + Staff + "', '" + Committee + "', NULL)";
                        bl = cl_Sql.Modify(sql);
                        if (bl == true)
                        {
                            LastID2 = cl_Sql.LastID("rqsid", "requestsystems"); //id , table

                            sql = "INSERT INTO approve " +
                                "(rqsid, aplevel, userid, aprequestuser, apstatus, apuserapprove1, apdate) " +
                                "VALUES(" + LastID2 + ", 1, '" + userid + "', '" + rqrequestuser + "', 'Approved', 0, '" + rqdateadd + "')";
                            bl = cl_Sql.Modify(sql);

                            sql = "INSERT INTO approve " +
                                "(rqsid, aplevel, userid, aprequestuser, apstatus, apuserapprove1, apuserapprove2, apdate) " +
                                "VALUES(" + LastID2 + ", 2, '0', '" + rqrequestuser + "', 'Wait', '" + Approve1 + "', '" + Approve2 + "', '" + rqdateadd + "')";
                            bl = cl_Sql.Modify(sql);
                        }
                    }
                    if (Cb_Com.Checked == true)
                    {
                        sql = "INSERT INTO requestsystems" +
                            "(rqid, sysid, rqsemail, rqsquota, rqsgroupmail_hod, rqsgroupmail_staff, rqsgroupmail_committeeother, rqsflag)" +
                            "VALUES(" + LastID + ", 9, '" + rqsemail + "', '"+ rqsquota + "', '"+ HOD + "', '" + Staff + "', '" + Committee + "', NULL)";
                        bl = cl_Sql.Modify(sql);
                        if (bl == true)
                        {
                            LastID2 = cl_Sql.LastID("rqsid", "requestsystems"); //id , table

                            sql = "INSERT INTO approve " +
                                "(rqsid, aplevel, userid, aprequestuser, apstatus, apuserapprove1, apdate) " +
                                "VALUES(" + LastID2 + ", 1, '" + userid + "', '" + rqrequestuser + "', 'Approved', 0, '" + rqdateadd + "')";
                            bl = cl_Sql.Modify(sql);

                            sql = "INSERT INTO approve " +
                                "(rqsid, aplevel, userid, aprequestuser, apstatus, apuserapprove1, apuserapprove2, apdate) " +
                                "VALUES(" + LastID2 + ", 2, '0', '" + rqrequestuser + "', 'Wait', '" + Approve1 + "', '" + Approve2 + "', '" + rqdateadd + "')";
                            bl = cl_Sql.Modify(sql);
                        }
                    }

                    if (bl == false)
                    {
                        sql = "Delete from approve where rqsid in (select rqsid from requestsystems where rqid = " + LastID + ")";
                        cl_Sql.Modify(sql);
                        sql = "Delete from requestsystems where rqid = " + LastID;
                        cl_Sql.Modify(sql);
                        sql = "Delete from request where rqid = " + LastID;
                        cl_Sql.Modify(sql);
                    }
                }

                if (bl == true)
                {
                    SendMail();
                }

                return bl;
            //}
            //catch (Exception ex)
            //{
            //    Response.Write("<script>alert('" + ex.Message + "');</script>");
            //    return false;
            //}
        }

        public string SendMail()
        {
            string rt = "";

            sql = "select u.*,d.depthod1,CONCAT(u2.userpname,' ',u2.userfname,' ',u2.userlname) as 'ApvName' " +
                "from `user` as u " +
                "left join department as d on u.userdeptcode = d.deptid " +
                "left join `user` as u2 on d.depthod1=u2.username " +
                "where u.username = '" + userid + "' ";
            dt = new DataTable();
            dt = cl_Sql.select(sql);

            string emailTo = dt.Rows[0]["useremail"].ToString();

            if (Session["Test"] != null) // --------------------------- For Test -------------------------
            {
                if (Session["Test"].ToString() == "Yes") { emailTo = "brh.hito@brh.co.th"; }
            }

            string emailFrom = "info.RequestSystem@brh.co.th";
            string ApvName = dt.Rows[0]["ApvName"].ToString();
            string CreateDate = DateTime.Now.Date.ToString();

            if (dt.Rows.Count > 0)
            {
                string htmlBody = "<h1 style='color: #4485b8;'>Systems Request.</h1>" +
                            "<p><strong style='color: #000;'> Request ID:</strong> &nbsp; " + RequestID + " </p>" +
                            "<p><strong style='color: #000;'> Create Date:</strong> &nbsp; " + CreateDate + " </p>" +
                            "<p><strong style='color: #000;'> Waiting approval by:</strong> &nbsp; " + ApvName + " </p>" +
                            "<p><a href='http://10.121.10.212:4001/Login?goto=RequestList'>Link : Access to the system.</a></p>" +
                            "<p></p><p></p><p>Please do not reply to this email because this address is not monitored.</p>" +
                            "<p>Automatic send by Request Systems.</p>";

                BRH_SendMail.ServiceSoapClient BRHmail = new BRH_SendMail.ServiceSoapClient();
                BRHmail.MailSend(emailTo, "Your Systems request", htmlBody, emailFrom, "Systems Request", "", "", "", false);

                rt = "success";
            }

        return rt;
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }

        //protected void a_hod_ServerClick(object sender, EventArgs e)
        //{
        //    string hod_dept = "";
        //    hod_dept = InDept.SelectedValue.ToString();

        //    sql = "select d.*,concat(u.userpname,' ',u.userfname,' ',u.userlname) as 'UserHOD', u.useremail " +
        //        "from department as d " +
        //        "left join `user` as u on u.username = d.depthod1 " +
        //        "where d.deptid = '" + hod_dept + "' ";
        //    dt = new DataTable();
        //    dt = cl_Sql.select(sql);
        //    if (dt.Rows.Count > 0)
        //    {
        //        lbl_hod_dept.Text = dt.Rows[0]["deptname"].ToString();
        //        lbl_hod_name.Text = dt.Rows[0]["UserHOD"].ToString();
        //        lbl_hod_email.Text = dt.Rows[0]["useremail"].ToString();

        //        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none",
        //        // "<script>$('#HODModal').modal('show');</script>", false);
        //    }
        //}
    }
}