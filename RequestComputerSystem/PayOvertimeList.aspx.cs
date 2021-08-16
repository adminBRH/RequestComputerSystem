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
    public partial class PayOvertimeList : System.Web.UI.Page
    {
        string sql = "";
        DataTable dt;
        SQLclass CL_Sql = new SQLclass();
        string id = "";

        string HRID = "151379";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLogin"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                SelectData("wait");
            }
           
        }

        public Boolean SelectData(string status)
        {
            Boolean result = false;

            string userid = "";
            string userstatus = "";


            if (Session["UserLogin"] != null)
            {
                userid = Session["UserLogin"].ToString();
            }

            sql = "SELECT p.*,d.deptname,CONCAT(u.userpname,' ',u.userfname,' ',u.userlname)as 'username' ,"+
                "\nCONCAT(h.userpname, ' ', h.userfname, ' ', h.userlname) as 'hodname' , " +
                "\nCONCAT(hr.userpname, ' ', hr.userfname, ' ', hr.userlname) as 'hrname'" +
                "\nFROM brh_it_request.payovertime as p " +
                "\nLEFT JOIN department as d on d.deptid = p.dept_id " +
                "\nLEFT JOIN `user` as u on u.username = p.user_id " +
                "\nLEFT JOIN `user` as h on h.username = p.hod_id " +
                "\nLEFT JOIN `user` as hr on hr.username = p.hr_id " +
                "\nWHERE 1 ";


            if (Session["UserStatus"] != null) // เรียกใช้ เงื่อไขี้เพื่อให้ Admin เห็นข้อมูลทั้งหมด และ User เห็นแค่ของตัวเอง
            {
                userstatus = Session["UserStatus"].ToString();
                if (userstatus == "admin" || userstatus == "hr")
                { }
                else
                {
                   sql = sql + "and (p.user_id = '" + userid + "' or p.hod_id = '" + userid + "' or p.hr_id = '" + userid + "') ";
                }

            }

            sql = sql + "\nand (p.pt_status like '%" + status + "%') " +
                "\nORDER BY p.pt_id DESC";

            dt = new DataTable(); //ต้อง new data table ใหม่ทุกครั้งเมื่อรับค่า
            dt = CL_Sql.select(sql);

            if (dt.Rows.Count > 0) //หาข้อมูลว่ามีบรรทัดนั้นหรือไม่
            {
                result = true;
            }

            Pay_list.DataSource = dt;
            Pay_list.DataBind();

            return result;

        }

        public string FiledStatus(string ptid)
        {
            string result = "";

            sql = "select * from payovertime where pt_id = '" + ptid + "' ";
            dt = new DataTable();
            dt = CL_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
                string hod_status = dt.Rows[0]["hod_status"].ToString();
                string hr_status = dt.Rows[0]["hr_status"].ToString();

                if (hod_status == "wait")
                {
                    result = "hod_status";
                }
                else if (hod_status == "approved" && hr_status == "wait")
                {
                    result = "hr_status";
                }
                else
                {

                }
            }

            return result;
        }

        public string WhoCreate(string id)
        {
            string result = "";

            sql = "select * from payovertime where pt_id = '" + id + "' ";
            dt = new DataTable();
            dt = CL_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
                result = dt.Rows[0]["user_id"].ToString();
            }

            return result;
        }

        public Boolean Updatestatus(string ptid, string status, string remark)
        {
            Boolean result = false;

            string filed = FiledStatus(ptid);

            string filed2 = "";

            string WhoUserMail = WhoCreate(ptid);

            if (filed == "hod_status")
            {
                filed2 = filed2 + ",hod_remark = '" + remark + "' ";
                if (status != "reject")
                {
                    filed2 = filed2 + ", hr_id = '" + HRID + "', hr_status = 'wait' ";
                    WhoUserMail = HRID;
                }
            }

            if (filed == "hr_status")
            {
                filed2 = filed2 + ",hr_remark = '" + remark + "' ";
                if (status != "reject")
                {
                    filed2 = filed2 + ", pt_status = 'Finish', hr_remark = '" + remark + "' ";
                }
            }

            if (status == "reject")
            {
                filed2 = filed2 + ", pt_status = 'reject' ";
            }

            sql = "Update payovertime set " + filed + " = '" + status + "' " + filed2 + " where pt_id = '" + ptid + "' ";
            if (CL_Sql.Modify(sql))
            {
                if (filed == "hr_status" && status != "reject")
                {
                    status = "finish";
                    WhoUserMail = "hr";
                }
                
                SendMail(WhoUserMail, ptid, status, remark);

                result = true;
            }

            return result;
        }

        public string SendMail(string userid, string ptid, string status, string remark)
        {
            string rt = "";

            sql = "select *,CONCAT(u.userpname,' ',u.userfname,' ',u.userlname) as 'ApvName'  from `user` as u where u.username = '" + userid + "' ";
            dt = new DataTable();
            dt = CL_Sql.select(sql);

            string emailTo = dt.Rows[0]["useremail"].ToString();

            if (Session["Test"] != null) // --------------------------- For Test -------------------------
            {
                if (Session["Test"].ToString() == "Yes") { emailTo = "brh.coo@brh.co.th"; }
            }

            string emailFrom = "info.RequestSystem@brh.co.th";
            string ApvName = dt.Rows[0]["ApvName"].ToString();
            string CreateDate = DateTime.Now.Date.ToString();

            if (dt.Rows.Count > 0)
            {
                string htmlBody = "<h1 style='color: #4485b8;'>Pay Overtime Request.</h1>" +
                            "<p><strong style='color: #000;'>Pay Request ID:</strong> &nbsp; " + ptid + " </p>";

                if (status == "approved")
                {
                    htmlBody = htmlBody + "<p><strong style='color: #000;'>Status :</strong> &nbsp; Waiting Approve </p>"+
                        "<p><strong style='color: #000;'>By:</strong> &nbsp; " + ApvName + " </p>";
                }
                else if (status == "reject")
                {
                    htmlBody = htmlBody + "<p><strong style='color: #000;'>Status :</strong> &nbsp; Rejected </p>";
                }
                else if (status == "finish")
                {
                    htmlBody = htmlBody + "<p><strong style='color: #000;'>Status :</strong> &nbsp; Finish </p>";
                }
                else  { }

                htmlBody = htmlBody + 
                    "<p><strong style='color: #000;'> Remark:</strong> &nbsp; " + remark + " </p>" +   
                    "<p><strong style='color: #000;'> Date:</strong> &nbsp; " + CreateDate + " </p>" +   
                    "<p><a href='http://10.121.10.212:4001/?usermail=" + userid + "'>Link : Access to the system.</a></p>" +
                    "<p></p><p></p><p>Please do not reply to this email because this address is not monitored.</p>" +
                    "<p>Automatic send by Request Systems.</p>";

                BRH_SendMail.ServiceSoapClient BRHmail = new BRH_SendMail.ServiceSoapClient();
                BRHmail.MailSend(emailTo, "Pay Overtime Request", htmlBody, emailFrom, "Systems Request", "", "", "", false);

                rt = "success";
            }

            return rt;
        }


        public string SelectRemark(string ptid)
        {
            string result = "";

            sql = "select * from payovertime where pt_id = '" + ptid + "' ";

            dt = new DataTable();
            dt = CL_Sql.select(sql);

            if (dt.Rows.Count > 0)
            {
                txt_rmk.Text = dt.Rows[0]["pt_id"].ToString();
            }

                return result;
        }

        protected void btn_approve_ServerClick(object sender, EventArgs e)
        {
            
            string ptid = txtH_id.Value.ToString();
            string remark = txt_remark.Value.ToString();
            if(Updatestatus(ptid, "approved", remark))
            {
                Response.Redirect("PayOvertimeList.aspx");
            }
        }

        protected void btn_reject_ServerClick(object sender, EventArgs e)
        {
            string ptid = txtH_id.Value.ToString();
            string remark = txt_remark.Value.ToString().Trim();

            if (Updatestatus(ptid, "reject", remark))
            {
                Response.Redirect("PayOvertimeList.aspx");
            }
        }

        protected void Pay_list_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string username = Session["UserLogin"].ToString();
            string status = Session["UserStatus"].ToString();

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell hod_id = e.Row.Cells[8];
                TableCell hr_id = e.Row.Cells[9];

                TableCell hod_status = e.Row.Cells[4];
                TableCell hr_status = e.Row.Cells[6];

                TableCell btn_approve = e.Row.Cells[10];
                TableCell ViewDetail = e.Row.Cells[11];

                string HodStatus = hod_status.Text.Trim();
                string HrStatus = hr_status.Text.Trim();

                // ------------------------------------------------------------------------
                if (status == "admin" || status == "hr")
                { }
                else
                {
                    btn_approve.Visible = false;
                    ViewDetail.Visible = true;

                    if (hod_id.Text == username)
                    {
                        if (HodStatus == "wait")
                        {
                            btn_approve.Visible = true;
                            ViewDetail.Visible = true;
                        }
                    }

                    if (hr_id.Text == username)
                    {
                        if (HrStatus == "wait")
                        {
                            btn_approve.Visible = true;
                            ViewDetail.Visible = true;
                        }
                    }
                }

                
                if (HodStatus == "wait")
                {
                    hod_status.CssClass = "badge badge-warning";
                }
                else if (HodStatus == "reject")
                {
                    hod_status.CssClass = "badge badge-danger";
                }
                else if (HodStatus == "finish")
                {
                    hod_status.CssClass = "badge badge-success";
                }
                else
                {
                    hod_status.CssClass = "btn btn-light";
                }
                
                if (HrStatus == "wait")
                {
                    hr_status.CssClass = "badge badge-warning";
                }
                else if (HrStatus == "reject")
                {
                    hr_status.CssClass = "badge badge-danger";
                }
                else if (HrStatus == "finish")
                {
                    hr_status.CssClass = "badge badge-success";
                }
                else
                {
                    hr_status.CssClass = "btn btn-light";
                }

                // ------------------------------------------------------------------------
                hod_id.Visible = false;
                hr_id.Visible = false;
                // ------------------------------------------------------------------------
                Pay_list.HeaderRow.Cells[8].Visible = false;
                Pay_list.HeaderRow.Cells[9].Visible = false;
            }
        }

        protected void select_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            string status = select_status.SelectedValue.ToString();
            SelectData(status);
        }

        protected void ViewDetail_ServerClick(object sender, EventArgs e)
        {
            string ptid = txtH_id.Value.ToString();
            Response.Redirect("PayOvertimeDetail.aspx?id="+ ptid + "");
        }

        //protected void Pay_list_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    string CommN = e.CommandName.ToString();
        //    if (CommN == "DetailDocument")
        //    {
        //        string ptid = e.CommandArgument.ToString();
        //        SelectRemark(ptid);
        //    }
        //}
    }
}