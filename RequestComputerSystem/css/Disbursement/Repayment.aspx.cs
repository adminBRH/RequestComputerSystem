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
    public partial class Repayment : System.Web.UI.Page
    {
        string sql = "";
        DataTable dt;
        SQLclass CL_Sql = new SQLclass();

        string FormID = "3";

        protected void Page_Load(object sender, EventArgs e)
        {
            SelectData();
            if (!IsPostBack)
            {
                SelectDept();
                DeptName();

            }
        }

        public Boolean InsertData()
        {
            Boolean result = true;

            string empid = Session["UserLogin"].ToString();
            string To = ip_to.Value.ToString().Trim(); //ถึง
            string From = ip_from.Value.ToString().Trim(); // จาก
            string Deptcode = ip_deptcode3.SelectedValue.ToString().Trim(); //รหัสแผนก
            string Apmoney = ip_apmoney.Value.ToString().Trim(); //เบิกให้นาย 
            string Amount = ip_amount.Value.ToString().Trim(); //จำนวนเงิน
            string Repayment = ip_repayment_nb.Value.ToString().Trim(); //คืนเงินผู้ป่วย
            string Deposit = ip_deposit_nb.Value.ToString().Trim();
            string Certificate = ip_certificate_nb.Value.ToString().Trim(); //ใบสูติบัตร
            string Refund_deposit = ip_refund_deposit_nb.Value.ToString().Trim(); 
            string IDcard = ip_idcard_nb.Value.ToString().Trim(); //บัตรประชาชน
            string Powerofattorney = ip_powerofattorney_nb.Value.ToString().Trim(); //ใบมอบอำนาจ        
            string Other = ip_other.Value.ToString().Trim(); //เหตุผลอื่นๆ
            string Moredetail = ip_moredetail.Value.ToString().Trim(); //รายละเอียดเพิ่มเติม
            //string Namereq = ip_namereq.Value.ToString().Trim(); //ผู้ขออนุมัติ

            sql = "INSERT INTO disbursement" +
                 "(d_datetime, d_empid, d_status, d_to, d_from, d_deptcode, d_disbursement, d_amount, d_refund, d_deposit, d_certificate, d_refunddeposit, d_idcard, d_powerofattorney, d_other, d_moredetail, d_formid)" +
                 "VALUES(CURRENT_TIMESTAMP, '"+ empid +"' ,'waiting', '" + To + "', '" + From + "', '" + Deptcode + "', '" + Apmoney + "', '" + Amount + "', '" + Repayment + "', '" + Deposit + "', '"+ Certificate +"', '"+ Refund_deposit + "', '"+ IDcard +"', '"+ Powerofattorney +"', '" + Other + "', '" + Moredetail + "', " + FormID + "); ";

            if (CL_Sql.Modify(sql))
            {
                string did = CL_Sql.LastID("d_id", "disbursement");
                if (did != "")
                {
                    UploadFile(did);
                    result = true;
                }
            }

            return result;

        }

        protected void submit_ServerClick(object sender, EventArgs e)
        {
            if (InsertData())
            {
                Response.Write("<script>alert('บันทึกสำเร็จ'); window.location.href='Repayment.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('ไม่สามารถบันทึกได้กรุณาติดต่อ Admin !!');</script>");
            }
        }

        public Boolean SelectData()
        {
            Boolean bl = false;

            if (Request.QueryString["id"] != null)
            {
                string id = Request.QueryString["id"].ToString();
                sql = "select* from disbursement where d_id = '" + id + "' ";
                dt = new DataTable();
                dt = CL_Sql.select(sql);
                if (dt.Rows.Count > 0)
                {
                    string empid = dt.Rows[0]["d_empid"].ToString();
                    string to = dt.Rows[0]["d_to"].ToString();
                    string from = dt.Rows[0]["d_from"].ToString();
                    string cdate = DateTime.Parse(dt.Rows[0]["d_datetime"].ToString()).ToString("dd/MM/yyyy");
                    string deptid = dt.Rows[0]["d_deptcode"].ToString();
                    string deptname = SelectDeptName(deptid);
                    string disbursement = dt.Rows[0]["d_disbursement"].ToString();
                    string amount = dt.Rows[0]["d_amount"].ToString();
                    string repayment = dt.Rows[0]["d_refund"].ToString();
                    string deposit = dt.Rows[0]["d_deposit"].ToString();
                    string certificate = dt.Rows[0]["d_certificate"].ToString();
                    string refund_deposit = dt.Rows[0]["d_refunddeposit"].ToString();
                    string idcard = dt.Rows[0]["d_idcard"].ToString();
                    string powerofattorney = dt.Rows[0]["d_powerofattorney"].ToString();
                    string other = dt.Rows[0]["d_other"].ToString();
                    string moredetail = dt.Rows[0]["d_moredetail"].ToString();
                    string userreq = SelectUserName(empid);
                    string documentid = dt.Rows[0]["d_id"].ToString();

                    Approval(id);

                    lbl_to.Text = to;
                    lbl_from.Text = from;
                    lbl_date.Text = cdate;
                    lbl_submitcost.Text = deptname;
                    lbl_deptcode.Text = deptid;
                    lbl_name.Text = disbursement;
                    lbl_money.Text = amount;
                    lbl_repayment.Text = repayment;
                    if (repayment != "")
                    {
                        rd_repayment.Checked = true;
                    }
                    lbl_deposit.Text = deposit;
                    if (deposit != "")
                    {
                        rd_deposit.Checked = true;
                    }
                    lbl_certificate.Text = certificate;
                    if (certificate != "")
                    {
                        rd_certificate.Checked = true;
                    }
                    lbl_refund_deposit.Text = refund_deposit;
                    if (refund_deposit != "")
                    {
                        rd_refund_deposit.Checked = true;
                    }
                    lbl_idcard.Text = idcard;
                    if (idcard != "")
                    {
                        rd_idcard.Checked = true;
                    }
                    lbl_powerofattorney.Text = powerofattorney;
                    if (powerofattorney != "")
                    {
                        rd_powerofattorney.Checked = true;
                    }
                    lbl_other.Text = other;
                    if (other != "")
                    {
                        rd_other.Checked = true;
                    }

                    lbl_dtmore.Text = moredetail;
                    lbl_uapprove.Text = userreq;
                    lbl_document_ID.Text = documentid;

                    bl = true;
                }
            }


            return bl;
        }

        public Boolean Approval(string id)
        {
            Boolean bl = false;

            sql = "select* from disbursement_approve where da_type = 'Request' and da_crid = '" + id + "' ";
            dt = new DataTable();
            dt = CL_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
                string level1 = dt.Rows[0]["da_level1"].ToString();
                string levelname1 = SelectUserName(level1);
                string level2 = dt.Rows[0]["da_level2"].ToString();
                string levelname2 = SelectUserName(level2);
                string level3 = dt.Rows[0]["da_level3"].ToString();
                string levelname3 = SelectUserName(level3);
                string level4 = dt.Rows[0]["da_level4"].ToString();
                string levelname4 = SelectUserName(level4);
                string level5 = dt.Rows[0]["da_level5"].ToString();
                string levelname5 = SelectUserName(level5);
                string level6 = dt.Rows[0]["da_level6"].ToString();
                string levelname6 = SelectUserName(level6);

                string datetime1 = dt.Rows[0]["da_datetime1"].ToString();
                string datetime2 = dt.Rows[0]["da_datetime2"].ToString();
                string datetime3 = dt.Rows[0]["da_datetime3"].ToString();
                string datetime4 = dt.Rows[0]["da_datetime4"].ToString();
                string datetime5 = dt.Rows[0]["da_datetime5"].ToString();
                string datetime6 = dt.Rows[0]["da_datetime6"].ToString();

                if (datetime1 != "")
                {
                    datetime1 = DateTime.Parse(datetime1).ToString("dd/MM/yyyy");
                }

                if (datetime2 != "")
                {
                    datetime2 = DateTime.Parse(datetime2).ToString("dd/MM/yyyy");
                }
                if (datetime3 != "")
                {
                    datetime3 = DateTime.Parse(datetime3).ToString("dd/MM/yyyy");
                }
                if (datetime4 != "")
                {
                    datetime4 = DateTime.Parse(datetime4).ToString("dd/MM/yyyy");
                }
                if (datetime5 != "")
                {
                    datetime5 = DateTime.Parse(datetime5).ToString("dd/MM/yyyy");
                }
                if (datetime6 != "")
                {
                    datetime6 = DateTime.Parse(datetime6).ToString("dd/MM/yyyy");
                }

                lbl_hod.Text = levelname1;
                lbl_manager.Text = levelname2;
                lbl_assdirector.Text = levelname3;
                deputy_director.Text = levelname4;
                lbl_vice_president.Text = levelname5;
                lbl_ceo.Text = levelname6;

                lbl_date_app_hod.Text = datetime1;
                lbl_date_deptdirector.Text = datetime2;
                lbl_date_assdirec.Text = datetime3;
                lbl_date_deputy.Text = datetime4;
                lbl_vicepre.Text = datetime5;
                lbl_date_ceo.Text = datetime6;

                bl = true;
            }

            return bl;
        }

        public string SelectDept()
        {
            string result = "";

            sql = "SELECT * FROM brh_it_request.department";
            dt = new DataTable();
            dt = CL_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
                ip_deptcode3.DataSource = dt;
                ip_deptcode3.DataTextField = "deptname";
                ip_deptcode3.DataValueField = "deptid";
                ip_deptcode3.DataBind();
            }

            return result;
        }

        public string SelectDeptName(string id)
        {
            string result = "";

            sql = "SELECT * FROM brh_it_request.department where deptid = '" + id + "'";
            DataTable dt2 = new DataTable();
            dt2 = CL_Sql.select(sql);
            if (dt2.Rows.Count > 0)
            {
                result = dt2.Rows[0]["deptname"].ToString();
            }

            return result;
        }

        public string SelectUserName(string id)
        {
            string result = "";

            sql = "SELECT CONCAT(userpname,' ',userfname,' ',userlname) as Fullname FROM brh_it_request.user where username = '" + id + "'";
            DataTable dt3 = new DataTable();
            dt3 = CL_Sql.select(sql);
            if (dt3.Rows.Count > 0)
            {
                result = dt3.Rows[0]["Fullname"].ToString();
            }

            return result;
        }
        protected void ip_deptcode3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeptName();
        }

        public Boolean DeptName()
        {
            Boolean bl = false;

            string deptname = ip_deptcode3.SelectedItem.ToString();
            txtH_dept.Value = deptname;
            if (deptname != "")
            {
                bl = true;
            }

            return bl;
        }

        public Boolean UploadFile(string id)
        {
            Boolean bl = false;

            if (FileUpload1.HasFile)
            {
                string Path = "~/Disbursement/FileUpload/";
                string FileName = "";
                foreach (HttpPostedFile uploadFile in FileUpload1.PostedFiles)
                {
                    FileName = uploadFile.FileName;
                    string[] exts = FileName.ToString().Split('.');
                    FileName = exts[0].ToString() + ",id" + id + "." + exts[1].ToString();
                    uploadFile.SaveAs(System.IO.Path.Combine(Server.MapPath(Path), FileName));
                    bl = true;
                }
            }
            return bl;
        }
    }
}