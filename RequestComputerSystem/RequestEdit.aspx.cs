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
    public partial class RequestEdit : System.Web.UI.Page
    {
        SQLclass cl_Sql = new SQLclass();
        DataTable dt;
        string sql = "";

        string userid = "";
        string rqid = "";
        string rqsid = "";
        string pname = "";
        string deptid = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLogin"] != null)
            {
                userid = Session["UserLogin"].ToString();

                if (Request.QueryString["rqid"] == null)
                {
                    Response.Redirect("RequestList.aspx");
                }
                else
                {
                    rqid = Request.QueryString["rqid"].ToString();

                    if (!IsPostBack)
                    {
                        Data(rqid);
                    }

                    Validation();
                }
            }
        }

        public Boolean Data(string id)
        {
            Boolean bl = false;

            string quota = "";

            sql = "select r.*,rs.sysid,rs.rqsemail,rs.rqsquota,rs.rqsgroupmail_staff,rs.rqsgroupmail_hod,rs.rqsgroupmail_committeeother " +
                "from brh_it_request.request as r " +
                "left join brh_it_request.requestsystems as rs on rs.rqid = r.rqid " +
                "where r.rqid = " + id + " ";
            dt = new DataTable();
            dt = cl_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
                txt_emp.Value = dt.Rows[0]["rqrequestuser"].ToString();
                pname = dt.Rows[0]["rqpname"].ToString();
                txt_fname.Value = dt.Rows[0]["rqfname"].ToString();
                txt_lname.Value = dt.Rows[0]["rqlname"].ToString();
                txt_fnameeng.Value = dt.Rows[0]["rqfnameeng"].ToString();
                txt_lnameeng.Value = dt.Rows[0]["rqlnameeng"].ToString();
                txt_pos.Value = dt.Rows[0]["rqpost"].ToString();
                deptid = dt.Rows[0]["rqdepartment"].ToString();
                txt_faction.Value = dt.Rows[0]["rqfaction"].ToString();
                txt_phone.Value = dt.Rows[0]["rqphone"].ToString();
                txt_specailty.Value = dt.Rows[0]["rqspecailty"].ToString();
                txt_codecare.Value = dt.Rows[0]["rqcodecare"].ToString();
                txt_location.Value = dt.Rows[0]["rqlocation"].ToString();

                string sys = "";
                foreach (DataRow dtr in dt.Rows)
                {
                    sys = dtr["sysid"].ToString();
                    if (sys == "1") { cb_bconnect.Checked = true; }
                    else if (sys == "2") 
                    { 
                        cb_email.Checked = true;
                        div_quota.Visible = true;
                        div_eg.Visible = true;
                        div_emailgroup.Visible = true;
                    }
                    else if (sys == "3") { cb_vpn.Checked = true; }
                    else if (sys == "4") { cb_MS.Checked = true; }
                    else { }

                    if (dtr["rqsemail"].ToString() != "") 
                    {
                        txt_email.Value = dtr["rqsemail"].ToString();
                        quota = dtr["rqsquota"].ToString();
                        if (dtr["rqsgroupmail_staff"].ToString() != "") { cb_staff.Checked = true; }
                        if (dtr["rqsgroupmail_hod"].ToString() != "") { cb_hod.Checked = true; }
                        if (dtr["rqsgroupmail_committeeother"].ToString() != "") 
                        { 
                            cb_committee.Checked = true;
                            txt_committee.Value = dtr["rqsgroupmail_committeeother"].ToString();
                        }
                    }
                }

                bl = true;
            }

            if (bl == true)
            {
                PName(pname);
                Department(deptid);
                Quota(quota);
            }

            return bl;
        }

        public Boolean PName(string txt)
        {
            Boolean bl = false;

            sql = "select * from brh_it_request.prename where pactive = 'Y' ";
            dt = new DataTable();
            dt = cl_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
                ddl_pname.DataSource = dt;
                ddl_pname.DataTextField = "pname";
                ddl_pname.DataValueField = "pname";
                ddl_pname.DataBind();

                ddl_pname.Items.FindByText(txt).Selected = true;

                bl = true;
            }
            
            return bl;
        }

        public Boolean Department(string id)
        {
            Boolean bl = false;

            sql = "select * from brh_it_request.department where (depthod1<>'' or depthod1 is not null) order by deptname";
            dt = new DataTable();
            dt = cl_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
                ddl_dept.DataSource = dt;
                ddl_dept.DataTextField = "deptname";
                ddl_dept.DataValueField = "deptid";
                ddl_dept.DataBind();

                ddl_dept.Items.FindByValue(id).Selected = true;
                
                bl = true;
            }

                return bl;
        }

        public Boolean Quota(string val)
        {
            Boolean bl = false;

            sql = "select * from brh_it_request.emailquota as e order by eqindex ";
            dt = new DataTable();
            dt = cl_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
                ddl_quota.DataSource = dt;
                ddl_quota.DataTextField = "eqname";
                ddl_quota.DataValueField = "eqid";
                ddl_quota.DataBind();

                if (val != "")
                {
                    ddl_quota.Items.FindByValue(val).Selected = true;
                }

                bl = true;
            }

            return bl;
        }

        public Boolean Validation()
        {
            Boolean bl = false;

            if (cb_email.Checked == true)
            {
                txt_email.Attributes.Add("required", "required");

                if (cb_committee.Checked == true)
                {
                    txt_committee.Attributes.Add("required", "required");
                }
                else
                {
                    txt_committee.Attributes.Remove("required");
                }
            }
            else
            {
                txt_email.Attributes.Remove("required");
            }

            return bl;
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            if (update() == true)
            {
                Response.Write("<script>alert('Update ข้อมูลเรียบร้อยแล้ว !!');</script>");
            }
            else
            {
                Response.Write("<script>alert('ไม่สามารถ Update ข้อมูลได้ !!');</script>");
            }
        }

        public Boolean update()
        {
            Boolean bl = false;

            string empid = "";
            string fname = "";
            string lname = "";
            string fnameeng = "";
            string lnameeng = "";
            string post = "";
            string deptidold = "";
            string faction = "";
            string phone = "";
            string specailty = "";
            string codecare = "";
            string location = "";

            empid = txt_emp.Value.ToString();
            pname = ddl_pname.SelectedValue.ToString();
            fname = txt_fname.Value.ToString();
            lname = txt_lname.Value.ToString();
            fnameeng = txt_fnameeng.Value.ToString();
            lnameeng = txt_lnameeng.Value.ToString();
            post = txt_pos.Value.ToString();
            deptid = ddl_dept.SelectedValue.ToString();
            faction = txt_faction.Value.ToString();
            phone = txt_phone.Value.ToString();
            specailty = txt_specailty.Value.ToString();
            codecare = txt_codecare.Value.ToString();
            location = txt_location.Value.ToString();

            sql = "select * from brh_it_request.request where rqid = " + rqid;
            dt = new DataTable();
            dt = cl_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
                deptidold = dt.Rows[0]["rqdepartment"].ToString();
            }

            sql = "UPDATE brh_it_request.request " +
                "SET userid='" + userid + "', rqrequestuser='" + empid + "', rqdateadd=NOW(), rqfname='" + fname + "', rqlname='" + lname + "', rqfnameeng='" + fnameeng + "' " +
                ", rqlnameeng='" + lnameeng + "', rqpost='" + post + "', rqdepartment='" + deptid + "', rqfaction='" + faction + "', rqphone='" + phone + "' " +
                ", rqcodecare='" + codecare + "', rqlocation='" + location + "', rqspecailty='" + specailty + "', rqpname='" + pname + "' " +
                "WHERE rqid = " + rqid;
            if (cl_Sql.Modify(sql) == true)
            {
                bl = true;

                if (cb_email.Checked == true)
                {
                    bl = false;

                    sql = "select * from brh_it_request.requestsystems where rqid = '" + rqid + "' and sysid=2 ";
                    dt = new DataTable();
                    dt = cl_Sql.select(sql);
                    if (dt.Rows.Count > 0)
                    {
                        rqsid = dt.Rows[0]["rqsid"].ToString();
                        string email = "";
                        string quota = "";
                        string hod = "";
                        string staff = "";
                        string committee = "";

                        email = txt_email.Value;
                        quota = ddl_quota.SelectedValue.ToString();

                        if (cb_hod.Checked == true) { hod = "HOD"; } else { hod = ""; }
                        if (cb_staff.Checked == true) { staff = "Staff"; } else { staff = ""; }
                        if (cb_committee.Checked == true) { committee = txt_committee.Value; } else { committee = ""; }

                        sql = "UPDATE brh_it_request.requestsystems " +
                            "SET rqsemail='" + email + "', rqsquota='" + quota + "', rqsgroupmail_hod='" + hod + "', rqsgroupmail_staff='" + staff + "', rqsgroupmail_committeeother='" + committee + "' " +
                            "WHERE rqsid = '" + rqsid + "' ";
                        if (cl_Sql.Modify(sql) == true)
                        {
                            bl = true;
                        }
                    }
                } // edit data for email

                if (deptidold != deptid)
                {
                    bl = false;

                    string hod1 = "";
                    string hod2 = "";
                    sql = "select d.*,u.useremail from brh_it_request.department as d " +
                        "left join brh_it_request.`user` as u on u.username = d.depthod1 " +
                        "where d.deptid in (select rqdepartment from brh_it_request.request where rqid = '" + rqid + "') ";
                    dt = new DataTable();
                    dt = cl_Sql.select(sql);
                    if (dt.Rows.Count > 0)
                    {
                        hod1 = dt.Rows[0]["depthod1"].ToString();
                        hod2 = dt.Rows[0]["depthod2"].ToString();
                        string emailTo = dt.Rows[0]["useremail"].ToString();
                        if (Session["Test"] != null) // --------------------------- For Test -------------------------
                        {
                            if (Session["Test"].ToString() == "Yes") { emailTo = "brh.hito@brh.co.th"; }
                        }
                        string emailFrom = "info.RequestSystem@brh.co.th";
                        string CreateDate = DateTime.Now.Date.ToString();

                        sql = "UPDATE  brh_it_request.approve " +
                        "SET apuserapprove1='" + hod1 + "', apuserapprove2='" + hod2 + "', apdate=NOW() " +
                        "where aplevel=2 and rqsid = " + rqsid;
                        if (cl_Sql.Modify(sql) == true)
                        {
                            string htmlBody = "<h1 style='color: #4485b8;'>Systems Request.</h1>" +
                                    "<p><strong style='color: #000;'> Request ID:</strong> &nbsp; " + rqid + " </p>" +
                                    "<p><strong style='color: #000;'> Create Date:</strong> &nbsp; " + CreateDate + " </p>" +
                                    "<p><strong style='color: #000;'> Waiting you approval </strong> </p>" +
                                    "<p><a href='http://10.121.10.212:4001/?usermail=" + hod1 + "'>Link : Access to the system.</a></p>" +
                                    "<p></p><p></p><p>Please do not reply to this email because this address is not monitored.</p>" +
                                    "<p>Automatic send by Request Systems.</p>";

                            BRH_SendMail.ServiceSoapClient BRHmail = new BRH_SendMail.ServiceSoapClient();
                            BRHmail.MailSend(emailTo, "Your Systems request", htmlBody, emailFrom, "Systems Request", "", "", "", false);

                            bl = true;
                        }
                    }
                } // Send mail
            }

            return bl;
        }
    }
}