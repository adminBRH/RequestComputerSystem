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
    public partial class Cancel : System.Web.UI.Page
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
            if (Session["UserLogin"] != null)
            {
                string status = Session["UserStatus"].ToString();

                if (status == "admin" || status == "test" || status == "hr")
                { }
                else
                {
                    Response.Redirect("Alarm?code=W01");
                    //Response.Write("<script>alert('หน้านี้ให้สิทธิเฉพาะ Admin และ HR เท่านั้น !!'); setTimeout(function(){window.location.href='Default.aspx'}, 100);</script>");
                }

                userlogin = Session["UserLogin"].ToString();
                userFullname = Session["UserFullName"].ToString();
            }
            else
            {
                Response.Redirect("Default");
            }
        }

        protected Boolean HTMLRequest(string ccid,string LastID, string system, string Datetimes, string emailTo, string emailFrom)
        {
            Boolean bl = true;

            try
            {
                string htmlBody = "<h1 style='color: #4485b8;'>Request Cancel Systems.</h1>" +
                                "<p><strong style='color: #000;'> Cancel ID:</strong> &nbsp; [" + ccid + "] (" + LastID + ") </p>" +
                                "<p><strong style='color: #000;'> Cancel system:</strong> &nbsp; " + system + " </p>" +
                                "<p><strong style='color: #000;'> Cancel Date:</strong> &nbsp; " + Datetimes + " </p>" +
                                "<p><strong style='color: #000;'> Waitting process by IT </strong> &nbsp; </p>" +
                                "<p><a href='http://10.121.10.212:4001/Login?goto=CancelList'>Link : Access to the system.</a></p>" +
                                "<p></p><p></p><p>Please do not reply to this email because this address is not monitored.</p>" +
                                "<p>Automatic send by Request Systems.</p>";

                if (MainID != "") { MainID = MainID + ", "; }
                MainID = MainID + "[" + ccid + "] (" + LastID + ")";

                BRHmail = new BRH_SendMail.ServiceSoapClient();
                BRHmail.MailSend(emailTo, "Your request Cancel Systems", htmlBody, emailFrom, "Systems Request", "", "", "", false);
            }
            catch
            {
                bl = false;
            }

            return bl;
        }

        protected string InsertCancelSystem(string ccid, string sysid, string userlogin)
        {
            string result = "";

            sql = "INSERT INTO cancelsystems " +
                "(ccid, sysid, ccsdate, ccsuserid, ccsstatus, ccsflag, ccsremark) " +
                "VALUES(" + ccid + ", " + sysid + ", now(), '" + userlogin + "', 'Waitting process', NULL, NULL)";
            if (cl_Sql.Modify(sql))
            {
                result = cl_Sql.LastID("ccsid", "cancelsystems");
            }

            return result;
        }

        protected void btn_submit_ServerClick(object sender, System.EventArgs e)
        {
            string Bconnect = txth_bconnect.Text;
            string VPN = txth_VPN.Text;
            string MS = txth_MS.Text;
            string Email = txth_email.Text;

            string username = txth_userid.Text;
            string Fname = txth_Fname.Text;
            string Lname = txth_Lname.Text;

            sql = "INSERT INTO cancel " +
                "(ccdate, ccuserid, ccusername, ccfname, cclname, ccstatus, ccflag, ccremark) " +
                "VALUES(now(), '" + userlogin + "', '" + username + "', '" + Fname + "', '" + Lname + "', 'Waitting process', NULL, NULL); ";
            if (cl_Sql.Modify(sql) == true)
            {
                string LastID = cl_Sql.LastID("ccid", "cancel"); //id , table
                //MainID = LastID;
                string ccid = LastID;
                string htmlBody = "";
                string Datetimes = DateTime.Now.ToString("dd/MM/yyyy");

                string emailFrom = "info.RequestSystem@brh.co.th";
                string emailTo = "";

                sql = "select * from `user` as u where username = '" + userlogin + "' "; 
                dt = new DataTable();
                dt = cl_Sql.select(sql);
                if (dt.Rows.Count > 0)
                {
                    emailTo = dt.Rows[0]["useremail"].ToString();
                }

                if (Session["Test"] != null) // --------------------------- For Test -------------------------
                {
                    if (Session["Test"].ToString() == "Yes") { emailTo = "brh.hito@brh.co.th"; }
                }

                //BRH_SendMail.ServiceSoapClient BRHmail;

                if (Bconnect != "")
                {
                    LastID = InsertCancelSystem(ccid, Bconnect, userlogin);
                    if (LastID != "")
                    {
                        HTMLRequest(ccid, LastID, "Arcus Air", Datetimes, emailTo, emailFrom);
                    }
                }
                if (VPN != "")
                {
                    LastID = InsertCancelSystem(ccid, Bconnect, userlogin);
                    if (LastID != "")
                    {
                        HTMLRequest(ccid, LastID, "VPN", Datetimes, emailTo, emailFrom);
                    }
                }
                if (MS != "")
                {
                    LastID = InsertCancelSystem(ccid, Bconnect, userlogin);
                    if (LastID != "")
                    {
                        HTMLRequest(ccid, LastID, "Microsoft", Datetimes, emailTo, emailFrom);
                    }
                }
                if (Email != "")
                {
                    LastID = InsertCancelSystem(ccid, Bconnect, userlogin);
                    if (LastID != "")
                    {
                        HTMLRequest(ccid, LastID, "E-mail Address", Datetimes, emailTo, emailFrom);
                    }
                }

                emailFrom = emailTo; 

                htmlBody = "<h1 style='color: #4485b8;'>New request for Cancel Systems.</h1>" +
                    "<p><strong style='color: #000;'> Document ID : </strong> &nbsp; " + MainID + " </p>" +
                    "<p><strong style='color: #000;'> Cancel systems of employee id : </strong> &nbsp; " + username + " </p>" +
                    "<p><strong style='color: #000;'> Request by : </strong> &nbsp; " + userFullname + " </p>" +
                    "<p><strong style='color: #000;'> Date:</strong> &nbsp; " + Datetimes + " </p>" +
                    "<p><strong style='color: #000;'> Awaiting IT-Support process. </strong> &nbsp; </p>" +
                    "<p><a href='http://10.121.10.212:4001/'>Link : Access to the system.</a></p>";

                emailTo = "BRH.ITsupport@glsict.com"; // ------------------------- E mail IT

                if (Session["Test"] != null) // --------------------------- For Test -------------------------
                {
                    if (Session["Test"].ToString() == "Yes") { emailTo = "brh.hito@brh.co.th"; }
                    emailFrom = "info.RequestSystem@brh.co.th";
                }

                BRHmail = new BRH_SendMail.ServiceSoapClient();
                BRHmail.MailSend(emailTo, "New request Cancel Systems", htmlBody, emailFrom, "Systems Request", "", "", "", false);
            }
        }
    }
}