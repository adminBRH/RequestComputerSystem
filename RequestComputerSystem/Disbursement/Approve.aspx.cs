using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace RequestComputerSystem.Disbursement
{
    public partial class Approve : System.Web.UI.Page
    {
        string sql = "";
        DataTable dt;
        SQLclass cl_Sql = new SQLclass();

        DisbursementClass cl_pv = new DisbursementClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("../login.aspx");
            }
            else
            {
                if (Request.QueryString["type"] != null && Request.QueryString["id"] != null)
                {
                    string type = Request.QueryString["type"].ToString();
                    string crid = Request.QueryString["id"].ToString();
                    
                    SelectData(type, crid);
                    PosName(type);
                }
            }
        }

        public string CardApprove(string level)
        {
            string result = "";

            result = "\n<div id=\"div_Appve_" + level + "\" class=\"col-4 mx-auto my-3\">" +
                     "\n   <div class=\"card card-header bg-gradient-light\">" +
                     "\n       <div class=\"row col-12 mx-auto\">" +
                     "\n           <div class=\"col-10 text-left\">" +
                     "\n               <asp:Label ID=\"lbl_pos" + level + "\" Text=\"\" runat=\"server\"></asp:Label>" +
                     "\n           </div>" +
                     "\n           <div class=\"col-2 text-right\">" +
                     "\n               <asp:Label ID=\"lbl_icon" + level + "\" CssClass=\"fas fa-tag fa-2x text-secondary\" runat=\"server\"></asp:Label>" +
                     "\n           </div>" +
                     "\n       </div>" +
                     "\n   </div>" +
                     "\n   <div class=\"card card-body text-center\">" +
                     "\n       <asp:Panel ID=\"pn_1\" CssClass=\"col-12 mb-3\" runat=\"server\">" +
                     "\n           <a href=\"#\" id=\"btn_apv_"+ level + "\" class=\"btn btn-success\"  data-toggle=\"modal\" data-target=\"#exampleModal\" onclick=\"fnevent('approve','" + level + "')\">Approve</a>&nbsp;&nbsp;&nbsp;&nbsp;" +
                     "\n           <a href=\"#\" id=\"btn_rej_" + level + "\" class=\"btn btn-danger\"  data-toggle=\"modal\" data-target=\"#exampleModal\" onclick=\"fnevent('reject','" + level + "')\">Reject</a>" +
                     "\n       </asp:Panel>" +
                     "\n       <asp:Label ID=\"lbl_apv" + level + "\" Text=\"………………………………………………\" runat=\"server\"></asp:Label>" +
                     "\n       <asp:Label ID=\"lbl_ap" + level + "\" Text=\"(………………………………………………)\" runat=\"server\"></asp:Label>" +
                     "\n       <asp:Label ID=\"lbl_date" + level + "\" Text=\"วันที่........./.........../...........\" runat=\"server\"></asp:Label>" +
                     "\n   </div>" +
                     "\n</div>";

            return result;
        }

        public Boolean SelectData(string type, string crid)
        {
            Boolean bl = false;

            if (Session["UserLogin"] != null)
            {
                string ss_empid = Session["UserLogin"].ToString();
                string ss_status = Session["UserStatus"].ToString();

                sql = "select * from disbursement_approve where da_type = '" + type + "' and da_crid = '" + crid + "' ";
                dt = new DataTable();
                dt = cl_Sql.select(sql);
                if (dt.Rows.Count > 0)
                {
                    string empid = "";
                    string remark = "";
                    string date = "";
                    string status = "";

                    //string html = "";
                    for (int i = 1; i <= 7; i++)
                    {
                        //html = html + CardApprove(i.ToString());
                        //lbl_CardApprove.Text = html;
                        //lbl_CardApprove.DataBind();

                        //Response.Write("<script>alert('" + i + "');</script>");
                        Label lbl_apv = (Label)form1.FindControl("lbl_apv" + i.ToString());
                        empid = dt.Rows[0]["da_level" + i.ToString()].ToString();
                        lbl_apv.Text = cl_Sql.EmpName(empid);

                        Label lbl_date = (Label)form1.FindControl("lbl_date" + i.ToString());
                        date = dt.Rows[0]["da_datetime" + i.ToString()].ToString();
                        if (date != "")
                        {
                            date = DateTime.Parse(date).ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            date = "วันที่........./.........../...........";
                        }
                        lbl_date.Text = date;

                        Label lbl_remark = (Label)form1.FindControl("lbl_remark" + i.ToString());
                        remark = dt.Rows[0]["da_remark" + i.ToString()].ToString();
                        lbl_remark.Text = remark;

                        status = dt.Rows[0]["da_status" + i.ToString()].ToString();

                        if (status == "reject")
                        {
                            lbl_remark.ForeColor = System.Drawing.Color.Red;
                        }

                        Label lbl_icon = (Label)form1.FindControl("lbl_icon" + i.ToString());
                        lbl_icon.CssClass = FaIcon(status);

                        Panel pn = (Panel)form1.FindControl("pn_" + i.ToString());
                        if (status == "waiting")
                        {
                            if (ss_status == "admin" || ss_status == "test")
                            {

                            }
                            else
                            {
                                if (dt.Rows[0]["da_level" + i.ToString()].ToString() != ss_empid)
                                {
                                    pn.Visible = false;
                                }
                            }
                        }
                        else
                        {
                            pn.Visible = false;
                        }

                        if (dt.Rows[0]["da_level"].ToString() != i.ToString())
                        {
                            pn.Visible = false;
                        }
                    }
                }
            }

            return bl;
        }

        public Boolean PosName(string type)
        {
            Boolean bl = false;

            if (type != "")
            {
                string id = Request.QueryString["id"].ToString();
                sql = "Select a.*,b.Pos2 from ( " +
                    "    select '1' as 'Key', userposition as 'Pos1'  from `user` " +
                    "where username in (select da_level1 from disbursement_approve where da_crid='" + id + "') " +
                    ") as a left join( " +
                    "    select '1' as 'Key', userposition as 'Pos2'  from `user` " +
                    "where username in (select da_level2 from disbursement_approve where da_crid='" + id + "') " +
                    ") as b on a.Key = b.Key ";
                dt = new DataTable();
                dt = cl_Sql.select(sql);
                if (dt.Rows.Count > 0)
                {
                    Label lbl_pos1 = (Label)form1.FindControl("lbl_pos1");
                    lbl_pos1.Text = dt.Rows[0]["Pos1"].ToString();
                    Label lbl_pos2 = (Label)form1.FindControl("lbl_pos2");
                    lbl_pos2.Text = dt.Rows[0]["Pos2"].ToString();
                    bl = true;
                }

                sql = "select * from disbursement_level where dr_type = '" + type + "' order by dr_level ";
                dt = new DataTable();
                dt = cl_Sql.select(sql);
                if (dt.Rows.Count > 0)
                {
                    Label lbl_pos3 = (Label)form1.FindControl("lbl_pos3");
                    lbl_pos3.Text = dt.Rows[0]["dr_levelname"].ToString();
                    Label lbl_pos4 = (Label)form1.FindControl("lbl_pos4");
                    lbl_pos4.Text = dt.Rows[1]["dr_levelname"].ToString();
                    Label lbl_pos5 = (Label)form1.FindControl("lbl_pos5");
                    lbl_pos5.Text = dt.Rows[2]["dr_levelname"].ToString();
                    Label lbl_pos6 = (Label)form1.FindControl("lbl_pos6");
                    lbl_pos6.Text = dt.Rows[3]["dr_levelname"].ToString();
                    Label lbl_pos7 = (Label)form1.FindControl("lbl_pos7");
                    lbl_pos7.Text = dt.Rows[4]["dr_levelname"].ToString();
                }
            }

            return bl;
        }

        public string FaIcon(string status)
        {
            string result = "fas fa-tag fa-2x text-secondary";

            if (status == "waiting")
            {
                result = "fas fa-clock fa-2x text-warning";
            }
            else if (status == "approve")
            {
                result = "fas fa-check fa-2x text-success";
            }
            else if (status == "reject")
            {
                result = "fas fa-times fa-2x text-danger";
            }
            else
            { }

            return result;
        }

        protected void btn_submit_ServerClick(object sender, EventArgs e)
        {
            string evn = txtH_event.Value.ToString();
            string level = txtH_level.Value.ToString();
            string fromid = "";
            

            string id = "";
            string type = "";

            if (Request.QueryString["id"] != null && Request.QueryString["type"] != null)
            {
                id = Request.QueryString["id"].ToString();
                type = Request.QueryString["type"].ToString();
            }

            string remark = ip_remark.Value.ToString().Trim();

            string aj = cl_pv.ApprovedReject(type, id, evn, level, remark); // -------------------------- Approve or Reject

            sql = "select * from disbursement_request where dr_id = '"+ id + "'";
            dt = new DataTable();
            dt = cl_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
               fromid = dt.Rows[0]["dr_formid"].ToString(); 
            }

            string form_name = cl_pv.SelectFormName(fromid);
            if (aj != "")
            {
                string emailTo = "";
                string fullname = "";

                if (Session["Test"] != null) // --------------------------- For Test -------------------------
                {
                    if (Session["Test"].ToString() == "Yes") { emailTo = "brh.hito@brh.co.th"; }
                }

                DataTable DT_emp = new DataTable();
                //DT_emp = cl_pv.SelectMailUser(aj);
                sql = "select *,CONCAT(u.userpname,' ',u.userfname,' ',u.userlname) as 'fullName'  from `user` as u where u.username = '" + aj + "'; ";
                DT_emp = cl_Sql.select(sql);
                if (DT_emp.Rows.Count > 0)
                {
                    emailTo = DT_emp.Rows[0]["useremail"].ToString();
                    fullname = DT_emp.Rows[0]["fullName"].ToString();
                }

                if (emailTo == "")
                {
                    Response.Write("<script>alert('ไม่สามารถส่ง Email ได้ เนื่องผู้อนุมัติลำดับถัดไปไม่มี email ในระบบ !!');</script>");
                }
                else
                {
                    string subject = "Request Disbursement ID " + id + " ";
                    string Body = "<h3>เรียน " + fullname + ",</h3>" +
                        "<br />" +
                        "&nbsp;&nbsp; เรื่อง." + form_name + "." +
                        "<br />" +
                        "&nbsp;&nbsp; เอกสารเลขที่ :" + id + "" +
                        "<br />" +
                        "&nbsp;&nbsp; สถานะ :" + evn + "" +
                        "<p><a href='http://10.121.10.212:4001/?usermail=" + aj + "'>Link : Access to the system.</a></p>" +
                        "<p></p><p></p><p>Please do not reply to this email because this address is not monitored.</p>" +
                        "<p>Automatic send by Request Systems.</p>";

                    if (cl_pv.SendMail(id,emailTo, subject, Body))
                    {
                        Response.Redirect("Approve?id=" + id + "&type=" + type);
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('ไม่สามารถบันทึกได้ กรุราติดต่อผู้ดูแลระบบ !!');</script>");
            }
        }
    }
}