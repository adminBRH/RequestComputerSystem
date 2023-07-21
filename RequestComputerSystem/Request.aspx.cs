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
                        Response.Redirect("Alarm?code=W02");
                        //Response.Write("<script>alert('หน้าการร้องขอใช้งานระบบคอมพิวเตอร์ ให้สิทธิเฉพาะระดับหัวหน้าแผนกขึ้นไปเท่านั้น !!'); setTimeout(function(){window.location.href='Default.aspx'}, 100);</script>");
                    }
                }

                string UserDeptid = "";
                if (Session["UserDeptid"] != null)
                {
                    UserDeptid = Session["UserDeptid"].ToString();
                }
                Branch(UserDeptid);
                Pname();
                Department(UserDeptid);
                ApproveName();

                ListHIS();
                ListPrinter();
                ListCom();
                ListDrive();
            }

        }

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

        public void Branch(string br_select)
        {
            dt = new DataTable();
            dt = cl_Sql.dt_Branch();
            dd_branch.DataSource = dt;
            dd_branch.DataTextField = "branchname";
            dd_branch.DataValueField = "branchname";
            dd_branch.DataBind();

            if (br_select != "")
            {
                dd_branch.SelectedValue = br_select.Substring(0, 3);
            }
        }

        protected void dd_branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string branch = dd_branch.SelectedValue.ToString();
            Location.Value = branch.ToUpper();
            string deptID = "";
            if (Session["userDeptid"] != null)
            {
                deptID = Session["userDeptid"].ToString();
            }
            Department(deptID);
            ApproveName();
        }

        public Boolean Department(string deptID)
        {
            Boolean bl = false;

            string branch = dd_branch.SelectedValue.ToString();

            DataTable dt3 = new DataTable();
            dt3 = cl_Sql.dt_Department(branch);

            InDept.DataSource = dt3;
            InDept.DataTextField = "deptname";
            InDept.DataValueField = "deptid";
            InDept.DataBind();

            if (deptID != "")
            {
                try
                {
                    InDept.SelectedValue = deptID;
                }
                catch
                {}
            }

            return bl;
        }

        public Boolean ApproveName()
        {
            Boolean bl = false;

            string dept = "";
            dept = InDept.SelectedValue.ToString();

            sql = "select d.*, " +
                "\nconcat(ifnull(u.userpname,''),' ',u.userfname,' ',u.userlname) as 'name', u.userposition as 'userposition1', " +
                "\nconcat(ifnull(u2.userpname,''),' ',u2.userfname,' ',u2.userlname) as 'name2', u2.userposition as 'userposition2' " +
                "\nfrom department as d " +
                "\nleft join `user` as u on u.username = d.depthod1 " +
                "\nleft join `user` as u2 on u2.username = d.depthod2 " +
                "\nwhere d.deptid = '" + dept + "'";
            dt = new DataTable();
            dt = cl_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
                lbl_approval.Visible = true;
                string Approval = "";
                string pos = dt.Rows[0]["userposition1"].ToString();
                if (pos == "")
                {
                    pos = "ไม่มีชื่อตำแหน่ง";
                }
                Approval = dt.Rows[0]["name"].ToString() + "<br />[" + pos + "]";
                lbl_approval.Text = Approval;

                if (dt.Rows[0]["name2"].ToString() != "")
                {
                    pos = dt.Rows[0]["userposition2"].ToString();
                    if (pos == "")
                    {
                        pos = "ไม่มีชื่อตำแหน่ง";
                    }

                    lbl_approval2.Visible = true;
                    Approval = dt.Rows[0]["name2"].ToString() + "<br />[" + pos + "]";
                    lbl_approval2.Text = Approval;
                }
                else
                {
                    lbl_approval2.Visible = false;
                }

            }

            return bl;
        }

        protected DataTable ListSystems(string sysid)
        {
            sql = "select * from systemlist where sysid = '" + sysid + "' order by sylindex; ";
            DataTable dtLS = new DataTable();
            dtLS = cl_Sql.select(sql);
            return dtLS;
        }

        public void ListHIS()
        {
            dt = new DataTable();
            dt = ListSystems("6");
            DD_HIS.DataSource = dt;
            DD_HIS.DataTextField = "sylname";
            DD_HIS.DataValueField = "sylname";
            DD_HIS.DataBind();
        }

        public void ListPrinter()
        {
            dt = new DataTable();
            dt = ListSystems("10");
            DD_Printer.DataSource = dt;
            DD_Printer.DataTextField = "sylname";
            DD_Printer.DataValueField = "sylname";
            DD_Printer.DataBind();
        }

        public void ListCom()
        {
            dt = new DataTable();
            dt = ListSystems("9");
            DD_Com.DataSource = dt;
            DD_Com.DataTextField = "sylname";
            DD_Com.DataValueField = "sylname";
            DD_Com.DataBind();
        }

        public void ListDrive()
        {
            dt = new DataTable();
            dt = ListSystems("13");
            DD_Drive.DataSource = dt;
            DD_Drive.DataTextField = "sylname";
            DD_Drive.DataValueField = "sylname";
            DD_Drive.DataBind();
        }

        protected void InDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApproveName();
        }

        public string CL_validate()
        {
            //string jquery1 = "";
            //string jquery2 = "";
            //string jquery = "";

            //// Page Load -----------------------------------------------------------------------------
            //jquery1 = "$(document).ready(function () { $(\"#form1\").on(\"submit\", function () { ";
            //jquery = "$(\"#pageloader\").fadeIn();";
            //jquery2 = " }); });";
            //jquery = jquery1 + jquery + jquery2;
            //Page.ClientScript.RegisterStartupScript(typeof(Page), "a key", "<script type=\"text/javascript\">" + jquery + "</script>");

            string Ctn = "y";

            InUsername.Attributes.Add("class", "form-control");
            if (InUsername.Value.Trim() == "")
            {
                InUsername.Attributes.Add("class", "form-control redBox");
                Ctn = "n";
            }
            InFName.Attributes.Add("class", "form-control");
            if (InFName.Value.Trim() == "")
            {
                InFName.Attributes.Add("class", "form-control redBox");
                Ctn = "n";
            }
            InLName.Attributes.Add("class", "form-control");
            if (InLName.Value.Trim() == "")
            {
                InLName.Attributes.Add("class", "form-control redBox");
                Ctn = "n";
            }
            InPost.Attributes.Add("class", "form-control");
            if (InPost.Value.Trim() == "")
            {
                InPost.Attributes.Add("class", "form-control redBox");
                Ctn = "n";
            }
            Specailty.Attributes.Add("class", "form-control");
            if (Specailty.Value.Trim() == "")
            {
                Specailty.Attributes.Add("class", "form-control redBox");
                Ctn = "n";
            }
            CodeCare.Attributes.Add("class", "form-control");
            if (CodeCare.Value.Trim() == "")
            {
                CodeCare.Attributes.Add("class", "form-control redBox");
                Ctn = "n";
            }
            Location.Attributes.Add("class", "form-control");
            if (Location.Value.Trim() == "")
            {
                Location.Attributes.Add("class", "form-control redBox");
                Ctn = "n";
            }

            //dd_Quota.CssClass = "";
            txt_commmitee.CssClass = "";

            if (CBHIS.Checked == true || CbEmail.Checked == true || CBVPN.Checked == true
                || Cb_SwL.Checked == true || Cb_IPP.Checked == true || CBCom.Checked == true || CBDrive.Checked == true
                || CBPrinter.Checked == true || Cb_Tablet.Checked == true || Cb_iPad.Checked == true)
            {
                lblCBHIS.Visible = false;
                lblCb_SwL.Visible = false;
                //lblCb_MS.Visible = false;
                lblCb_IPP.Visible = false;
                lblCb_Tablet.Visible = false;
                lblCb_iPad.Visible = false;
                lblCBVPN.Visible = false;
                lblCBPrinter.Visible = false;
                lblCBCom.Visible = false;
                lblCBDrive.Visible = false;
                lblCb_Email.Visible = false;

                if (Ctn == "y")
                {
                    Ctn = validateVPN();
                    if (Ctn == "y")
                    {
                        Ctn = validateEmail();
                    }
                    else
                    {
                        validateEmail();
                    }
                }
                else
                {
                    validateVPN();
                    validateEmail();
                }
            }
            else
            {
                lblCBHIS.Visible = true;
                lblCb_SwL.Visible = true;
                //lblCb_MS.Visible = true;
                lblCb_IPP.Visible = true;
                lblCb_Tablet.Visible = true;
                lblCb_iPad.Visible = true;
                lblCBVPN.Visible = true;
                lblCBPrinter.Visible = true;
                lblCBCom.Visible = true;
                lblCBDrive.Visible = true;
                lblCb_Email.Visible = true;
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

        private string validateVPN()
        {
            string result = "y";

            if (CBVPN.Checked)
            {
                txt_VPNAccount.Attributes.Remove("style");
                if (txt_VPNAccount.Value.Trim() == "")
                {
                    txt_VPNAccount.Attributes.Add("style", "border: solid; border-color: red;");
                    result = "n";
                }
                else
                {
                    txt_VPNAccount.Attributes.Add("style", "border: solid; border-color: green;");
                }
            }

            return result;
        }

        private string validateEmail()
        {
            string result = "y";

            if (CbEmail.Checked)
            {
                txt_Email.Attributes.Remove("style");
                if (txt_Email.Value.Trim() == "")
                {
                    txt_Email.Attributes.Add("style", "border: solid; border-color: red;");
                    //txtEmailValidator.Enabled = true;
                    result = "n";
                }
                else
                {
                    txt_Email.Attributes.Add("style", "border: solid; border-color: green;");
                    //txtEmailValidator.Enabled = false;
                }

                // -----------> ปิดเมื่อวันที่ 10/01/2023 23:00 น. พี่นุช สั่งยกเลิกใช้งาน ------------------------------
                //if (dd_Quota.SelectedValue == "")
                //{
                //    dd_Quota.CssClass = "redBox";
                //    //dd_QuotaValidator.Enabled = true;
                //    result = "n";
                //}
                //else
                //{
                //    dd_Quota.CssClass = "greenBox";
                //    //dd_QuotaValidator.Enabled = false;
                //}

                if (cb_hod.Checked || cb_staff.Checked || cb_committee.Checked)
                {
                    if (cb_hod.Checked) { HOD = cb_hod.Value.ToString(); }
                    if (cb_staff.Checked) { Staff = cb_staff.Value.ToString(); }

                    lblcb_groupmail.Visible = false;
                    if (cb_committee.Checked)
                    {
                        if (txt_commmitee.Text == "")
                        {
                            txt_commmitee.CssClass = "redBox";
                            //txt_commmiteeValidator.Enabled = true;
                            result = "n";
                        }
                        else
                        {
                            txt_commmitee.CssClass = "greenBox";
                            //txt_commmiteeValidator.Enabled = false;
                            Committee = txt_commmitee.Text.Trim();
                        }
                    }
                    else
                    {
                        //txt_commmiteeValidator.Enabled = false;
                    }
                }
                else
                {
                    lblcb_groupmail.Visible = true;
                    result = "n";
                }
            }

            return result;
        }

        public string CL_Insert()
        {
            string RequestID = "";
            string rqid = "";

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
            string rqremark = setValue(txt_remark.Value.ToString().Trim());

            string sql = "INSERT INTO request" +
                "(userid, rqtype, rqrequestuser, rqstatus, rqdateadd, rqpname, rqfname, rqlname, rqfnameeng, rqlnameeng, rqpost, rqdepartment, rqfaction, rqphone, rqspecailty, rqcodecare, rqlocation, rqremark)" +
                "VALUES('" + userid + "', '"+ rqtype + "', '" + rqrequestuser + "', '" + rqstatus + "', '" + rqdateadd + "', '" + rqpname + "', '" + rqfname + "', '" + rqlname + "', '" + rqfnameeng + "', '" + rqlnameeng + "', '" + rqpost + "', '" + rqdepartment + "', '" + rqfaction + "', '" + rqphone + "', '" + rqspecailty + "', '" + rqcodecare + "', '" + rqlocation + "', " + rqremark + ")";
            bl = cl_Sql.Modify(sql);
            if (bl == true)
            {
                sql = "select max(rqid) as 'rqid' from request where convert(rqdateadd, date) = CURRENT_DATE and userid = '" + userid + "'; ";
                dt = new DataTable();
                dt = cl_Sql.select(sql);
                if (dt.Rows.Count > 0)
                {
                    RequestID = dt.Rows[0]["rqid"].ToString();
                    rqid = RequestID;

                    sql = "select r.*,d.depthod1,d.depthod2 from request as r " +
                        "left join department as d on r.rqdepartment = d.deptid " +
                        "where rqid = " + rqid;
                    dt = new DataTable();
                    dt = cl_Sql.select(sql);

                    string Approve1 = dt.Rows[0]["depthod1"].ToString();
                    string Approve2 = dt.Rows[0]["depthod2"].ToString();
                    if (Approve2 == "") { Approve2 = "0"; }

                    string rqsemail = txt_Email.Value.Trim();
                    string rqsquota = ""; // dd_Quota.SelectedValue.ToString();

                    string systemID = "";
                    string rqsflag = "";

                    if (CbEmail.Checked == true)
                    {
                        systemID = "2";
                        bl = insertSystemApprove(systemID, rqid, rqrequestuser, rqdateadd, rqdepartment, Approve1, Approve2, rqsemail, rqsquota, HOD, Staff, Committee, rqsflag, "");
                    }
                    else
                    {
                        rqsemail = "";
                        rqsquota = "";
                        HOD = "";
                        Staff = "";
                        Committee = "";
                    }

                    if (CBVPN.Checked == true)
                    {
                        systemID = "3";
                        bl = insertSystemApprove(systemID, rqid, rqrequestuser, rqdateadd, rqdepartment, Approve1, Approve2, rqsemail, rqsquota, HOD, Staff, Committee, rqsflag, txt_VPNAccount.Value.ToString().Trim());
                    }
                    //if (Cb_MS.Checked == true)
                    //{
                    //    systemID = "4";
                    //    bl = insertSystemApprove(systemID, rqid, rqrequestuser, rqdateadd, rqdepartment, Approve1, Approve2, rqsemail, rqsquota, HOD, Staff, Committee, rqsflag, "");
                    //}
                    if (CBHIS.Checked == true)
                    {
                        // 1 = B-Connect >> Old systems
                        // 6 = Arcus Air >> New systems 
                        // 6 = HIS >> Arcus Air, iMed, EBMC (Now open)
                        systemID = "6";
                        if (rqdepartment == "BRH7112") //By pass อ.จารุวัฑ
                        {
                            Approve2 = "0";
                        }
                        bl = insertSystemApprove(systemID, rqid, rqrequestuser, rqdateadd, rqdepartment, Approve1, Approve2, rqsemail, rqsquota, HOD, Staff, Committee, rqsflag, DD_HIS.SelectedValue.ToString());
                    }
                    if (Cb_SwL.Checked == true)
                    {
                        systemID = "7";
                        bl = insertSystemApprove(systemID, rqid, rqrequestuser, rqdateadd, rqdepartment, Approve1, Approve2, rqsemail, rqsquota, HOD, Staff, Committee, rqsflag, "");
                    }
                    if (Cb_IPP.Checked == true)
                    {
                        systemID = "8";
                        bl = insertSystemApprove(systemID, rqid, rqrequestuser, rqdateadd, rqdepartment, Approve1, Approve2, rqsemail, rqsquota, HOD, Staff, Committee, rqsflag, "");
                    }
                    if (CBCom.Checked == true)
                    {
                        systemID = "9";
                        bl = insertSystemApprove(systemID, rqid, rqrequestuser, rqdateadd, rqdepartment, Approve1, Approve2, rqsemail, rqsquota, HOD, Staff, Committee, rqsflag, DD_Com.SelectedValue.ToString());
                    }
                    if (CBDrive.Checked == true)
                    {
                        systemID = "13";
                        bl = insertSystemApprove(systemID, rqid, rqrequestuser, rqdateadd, rqdepartment, Approve1, Approve2, rqsemail, rqsquota, HOD, Staff, Committee, rqsflag, DD_Drive.SelectedValue.ToString());
                    }
                    if (CBPrinter.Checked == true)
                    {
                        systemID = "10";
                        bl = insertSystemApprove(systemID, rqid, rqrequestuser, rqdateadd, rqdepartment, Approve1, Approve2, rqsemail, rqsquota, HOD, Staff, Committee, rqsflag, DD_Printer.SelectedValue.ToString());
                    }
                    if (Cb_Tablet.Checked == true)
                    {
                        systemID = "11";
                        bl = insertSystemApprove(systemID, rqid, rqrequestuser, rqdateadd, rqdepartment, Approve1, Approve2, rqsemail, rqsquota, HOD, Staff, Committee, rqsflag, "");
                    }
                    if (Cb_iPad.Checked == true)
                    {
                        systemID = "12";
                        bl = insertSystemApprove(systemID, rqid, rqrequestuser, rqdateadd, rqdepartment, Approve1, Approve2, rqsemail, rqsquota, HOD, Staff, Committee, rqsflag, "");
                    }

                    if (bl == false)
                    {
                        sql = "Delete from approve where rqsid in (select rqsid from requestsystems where rqid = " + rqid + ")";
                        cl_Sql.Modify(sql);
                        sql = "Delete from requestsystems where rqid = " + rqid;
                        cl_Sql.Modify(sql);
                        sql = "Delete from request where rqid = " + rqid;
                        cl_Sql.Modify(sql);

                        RequestID = "";
                    }
                }
                else
                {
                    bl = false;
                }
            }

            if (bl == true)
            {
                SendMail(RequestID);
            }

            return RequestID;
        //}
        //catch (Exception ex)
        //{
        //    Response.Write("<script>alert('" + ex.Message + "');</script>");
        //    return false;
        //}
        }

        public string setValue(string val)
        {
            if (val == "")
            {
                val = "NULL";
            }
            else
            {
                val = "'" + val + "'";
            }

            return val;
        }

        private Boolean insertSystemApprove(string systemsID,string rqid, string rqrequestuser, string rqdateadd, string rqdepartment, string Approve1, string Approve2, string rqsemail, string rqsquota, string HOD, string Staff, string Committee, string rqsflag, string rqsvalue)
        {
            Boolean bl = false;

            rqsemail = setValue(rqsemail);
            rqsquota = setValue(rqsquota);
            HOD = setValue(HOD);
            Staff = setValue(Staff);
            Committee = setValue(Committee);
            rqsflag = setValue(rqsflag);
            rqsvalue = setValue(rqsvalue);

            sql = "INSERT INTO requestsystems" +
                "(rqid, sysid, rqsemail, rqsquota, rqsgroupmail_hod, rqsgroupmail_staff, rqsgroupmail_committeeother, rqsflag, rqsvalue)" +
                "VALUES(" + rqid + ", " + systemsID + ", " + rqsemail + ", " + rqsquota + ", " + HOD + ", " + Staff + ", " + Committee + ", " + rqsflag + ", " + rqsvalue + ");";
            bl = cl_Sql.Modify(sql);
            if (bl == true)
            {
                string rqsid = "";

                sql = "select max(rqsid) as 'rqsid' from requestsystems where rqid = '" + rqid + "'; ";
                dt = new DataTable();
                dt = cl_Sql.select(sql);
                if (dt.Rows.Count > 0)
                {
                    rqsid = dt.Rows[0]["rqsid"].ToString();
                }

                sql = "INSERT INTO approve " +
                    "(rqsid, aplevel, userid, aprequestuser, apstatus, apuserapprove1, apdate) " +
                    "VALUES(" + rqsid + ", 1, '" + userid + "', '" + rqrequestuser + "', 'Approved', 0, '" + rqdateadd + "')";
                bl = cl_Sql.Modify(sql);

                sql = "INSERT INTO approve " +
                    "(rqsid, aplevel, userid, aprequestuser, apstatus, apuserapprove1, apuserapprove2, apdate) " +
                    "VALUES(" + rqsid + ", 2, '0', '" + rqrequestuser + "', 'Wait', '" + Approve1 + "', '" + Approve2 + "', '" + rqdateadd + "')";
                bl = cl_Sql.Modify(sql);
            }

            return bl;
        }

        protected string APV(string RequestID)
        {
            string result = "";

            sql = "select d.*,concat(u1.userpname,' ',u1.userfname,' ',u1.userlname) as 'hod1', concat(u2.userpname,' ',u2.userfname,' ',u2.userlname) as 'hod2' " +
                "\nfrom department as d " +
                "\nleft join `user` as u1 on u1.username = d.depthod1 " +
                "\nleft join `user` as u2 on u2.username = d.depthod2 " +
                "\nwhere d.deptid in (select rqdepartment from request where rqid = '" + RequestID + "'); ";
            DataTable dtAPV = new DataTable();
            dtAPV = cl_Sql.select(sql);
            if (dtAPV.Rows.Count > 0)
            {
                string hod1 = dtAPV.Rows[0]["hod1"].ToString();
                string hod2 = dtAPV.Rows[0]["hod2"].ToString();
                result = hod1 + " และ " + hod2;
            }

            return result;
        }

        public string SendMail(string RequestID)
        {
            string rt = "";

            //sql = "select u.*,d.depthod1,CONCAT(u2.userpname,' ',u2.userfname,' ',u2.userlname) as 'ApvName' " +
            //    "from `user` as u " +
            //    "left join department as d on u.userdeptcode = d.deptid " +
            //    "left join `user` as u2 on d.depthod1=u2.username " +
            //    "where u.username = '" + userid + "' ";

            sql = "select * from `user` where username = '" + userid + "'; ";
            dt = new DataTable();
            dt = cl_Sql.select(sql);

            string emailTo = dt.Rows[0]["useremail"].ToString();

            if (Session["Test"] != null) // --------------------------- For Test -------------------------
            {
                if (Session["Test"].ToString() == "Yes") { emailTo = "brh.hito@brh.co.th"; }
            }

            string emailFrom = "info.RequestSystem@brh.co.th";
            string CreateDate = DateTime.Now.Date.ToString();

            string ApvName = APV(RequestID);

            if (dt.Rows.Count > 0)
            {
                string htmlBody = "<h1 style='color: #4485b8;'>Systems Request.</h1>" +
                            "<p><strong style='color: #000;'> Request ID:</strong> &nbsp; " + RequestID + " </p>" +
                            "<p><strong style='color: #000;'> Create Date:</strong> &nbsp; " + CreateDate + " </p>" +
                            "<p><strong style='color: #000;'> Waiting approval by:</strong> &nbsp; " + ApvName + " </p>" +
                            "<p><a href='http://10.121.10.212:4001/Login?goto=RequestList'>Link : Access to the system.</a></p>" +
                            "<p></p><p></p><p>Please do not reply to this email because this address is not monitored.</p>" +
                            "<p>Automatic send by Request Systems.</p>";

                //emailTo = "brh.hito@brh.co.th"; // --------------------- For test ----------------------

                BRH_SendMail.ServiceSoapClient BRHmail = new BRH_SendMail.ServiceSoapClient();
                BRHmail.MailSend(emailTo, "Your Systems request", htmlBody, emailFrom, "Systems Request", "", "", "", false);

                rt = "success";
            }

        return rt;
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }

        protected void btn_submit_ServerClick(object sender, EventArgs e)
        {
            if (CL_validate().ToString() == "y")
            {
                string rqid = CL_Insert();
                if (rqid != "")
                {
                    Response.Redirect("RequestList?qid=" + rqid);
                    //lblAlert.Text = "บันทึกข้อมูลเรียบร้อยแล้ว !!";
                    //Response.Write("<script>alert('บันทึกข้อมูลเรียบร้อยแล้ว !!'); setTimeout(function(){window.location.href='RequestList.aspx'}, 10);</script>");
                }
                else
                {
                    lblAlert.Text = "ล้มเหลว ไม่สามารถบันทึกข้อมูลได้ !!";
                    //Response.Write("<script>alert('ล้มเหลว ไม่สามารถบันทึกข้อมูลได้ !!');</script>");
                }
            }
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