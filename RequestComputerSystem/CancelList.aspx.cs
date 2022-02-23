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
    public partial class CancelList : System.Web.UI.Page
    {
        string sql = "";
        DataTable dt;
        SQLclass cl_Sql = new SQLclass();

        string UserLogin = "";
        string UserStatus = "";

        string ccsstatus = "";
        string htmlBody = "";
        string Dates = DateTime.Now.ToString("dd/MM/yyyy");
        string emailTo = "";
        string emailFrom = "";
        string ccid = "";
        string ccuserid = "";

        string permit = "";

        BRH_SendMail.ServiceSoapClient BRHmail;

        protected void Page_Load(object sender, EventArgs e)
        {
            txt_remark.Attributes.Add("placeholder", "หมายเหตุ");

            if (Session["Userlogin"] != null)
            {
                UserLogin = Session["Userlogin"].ToString();
                UserStatus = Session["UserStatus"].ToString();
                if (UserStatus == "admin" || UserStatus == "test" || UserStatus == "hr" || UserStatus == "it")
                { }
                else
                {
                    Response.Write("<script>alert('คุณไม่มีสิทธิใช้งานหน้านี้ !!'); setTimeout(function(){window.location.href='Default.aspx'}, 100);</script>");
                }
            }
            else
            {
                Response.Redirect("Default");
            }

            if (!IsPostBack)
            {
                ccsstatus = ddl_search.SelectedValue.Trim();
                Grid1(ccsstatus);
            }
            else
            {

            }

        }

        protected void ddl_search_SelectedIndexChanged(object sender, EventArgs e)
        {
            ccsstatus = ddl_search.SelectedValue.Trim();
            Grid1(ccsstatus);
        }

        public Boolean Grid1(string St)
        {
            Boolean bl = false;

            permit = "";
            if (UserStatus == "admin" || UserStatus == "it") 
            { 
                permit = "Yes"; 
            }

            sql = "select concat('[',c.ccid,'] (',cs.ccsid,')') as 'cancelID',cs.*,concat(c.ccfname,' ',c.cclname) as 'ccname',s.sysname " +
                "from brh_it_request.cancelsystems as cs " +
                "left join brh_it_request.cancel as c on c.ccid = cs.ccid " +
                "left join brh_it_request.systems as s on s.sysid = cs.sysid " +
                "where cs.ccsstatus like '%" + St + "%' ";
                if (permit != "Yes")
                {
                    sql += "and cs.ccsuserid = '" + UserLogin + "' ";
                }
            sql += "order by ccsid desc ";

            dt = new DataTable();
            dt = cl_Sql.select(sql);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            if (dt.Rows.Count > 0) 
            {
                bl = true;
            }
            else
            {
                if (permit != "Yes")
                {
                    Response.Write("<script>alert('หน้านี้ให้สิทธิเฉพาะ IT และผู้ที่ทำรายการยกเลิกใช้งานระบบเท่านั้น !!'); setTimeout(function(){window.location.href='Default.aspx'}, 100);</script>");
                }
            }
            
            return bl;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell CellStatus = e.Row.Cells[4];
                TableCell CellBtnEdit = e.Row.Cells[6];

                if (CellStatus.Text == "Waitting process")
                {
                    if (permit == "Yes")
                    {
                        CellBtnEdit.Visible = true;
                    }
                    else
                    {
                        CellBtnEdit.Visible = false;
                    }
                }
                else
                {
                    CellBtnEdit.Visible = false;
                }
            }

        }

        protected void Btn_success_Click(object sender, EventArgs e)
        {
            if (UserStatus == "admin" || UserStatus == "it")
            {
                sql = "UPDATE cancelsystems " +
                    "SET ccsuserid = '" + UserLogin + "', ccsstatus = 'Finish', ccsremark = '" + txt_remark.Text.Trim() + "' " +
                    "WHERE ccsid = " + txth_ID.Text;
                dt = new DataTable();
                if (cl_Sql.Modify(sql) == true)
                {
                    if (MailTo("success") == true)
                    {

                    }
                }
            }
            else
            {
                Response.Write("<script>alert('คุณไม่มีสิทธิ์ Update !!');</script>");
            }
        }

        protected void Btn_reject_Click(object sender, EventArgs e)
        {
            if (UserStatus == "admin" || UserStatus == "it")
            {
                sql = "UPDATE cancelsystems " +
                "SET ccsuserid = '" + UserLogin + "', ccsstatus = 'Reject', ccsremark = '" + txt_remark.Text.Trim() + "' " +
                "WHERE ccsid = " + txth_ID.Text;
                dt = new DataTable();
                if (cl_Sql.Modify(sql) == true)
                {
                    if (MailTo("reject") == true)
                    {

                    }
                }
            }
            else
            {
                Response.Write("<script>alert('คุณไม่มีสิทธิ์ Update !!');</script>");
            }
        }

        public Boolean MailTo(string st)
        {
            Boolean bl = false;

            sql = "select cs.*,c.ccuserid,u.useremail " +
                    "from cancelsystems as cs " +
                    "left join cancel as c on c.ccid = cs.ccid " +
                    "left join `user` as u on u.username = c.ccuserid " +
                    "where cs.ccsid = " + txth_ID.Text;
            dt = new DataTable();
            dt = cl_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
                string alert = "";
                string subj = "";

                emailTo = dt.Rows[0]["useremail"].ToString();
                ccid = dt.Rows[0]["ccid"].ToString();
                ccuserid = dt.Rows[0]["ccuserid"].ToString();

                if (st == "success")
                {
                    htmlBody = "<h1 style='color: #4485b8;'>Cancel Systems already.</h1>";
                    subj = "Cancel Systems already";
                    alert = "Update Status already !!";
                }
                else if (st == "reject")
                {
                    htmlBody = "<h1 style='color: #4485b8;'>Reject Cancel Systems.</h1>";
                    subj = "Reject Cancel Systems";
                    alert = "Reject already !!";
                }
                else { }

                htmlBody += "<p><strong style='color: #000;'> Cancel ID:</strong> &nbsp; [" + ccid + "] (" + txth_ID.Text + ") </p>" +
                    "<p><strong style='color: #000;'> From : </strong> &nbsp; BRH-IT-Group </p>" +
                    "<p><strong style='color: #000;'> Date:</strong> &nbsp; " + Dates + " </p>" +
                    "<p><a href='http://10.121.10.212:4001/Login?goto=CancelList'>Link : Access to the system.</a></p>";

                emailFrom = "BRH-IT-GROUP@glsict.com"; // ------------------------- E mail IT

                if (Session["Test"] != null) // --------------------------- For Test -------------------------
                {
                    if (Session["Test"].ToString() == "Yes") { emailTo = "brh.hito@brh.co.th"; }
                }

                try
                {
                    BRHmail = new BRH_SendMail.ServiceSoapClient();
                    BRHmail.MailSend(emailTo, subj, htmlBody, emailFrom, "Systems Request", "", "", "", false);
                }
                catch
                {
                    Response.Write("<script>alert('ไม่สามารถส่ง Email ถึง พนักงานรหัส " + ccuserid + " ได้ !!');window.location='CancelList.aspx'</script>");
                }

                Response.Write("<script>alert('" + alert + "');window.location='CancelList.aspx'</script>");

                bl = true;
            }

            return bl;
        }
    }
}