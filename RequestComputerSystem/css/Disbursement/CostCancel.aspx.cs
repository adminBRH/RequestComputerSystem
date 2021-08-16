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
    public partial class CostCancel : System.Web.UI.Page
    {
        string sql = "";
        DataTable dt;
        SQLclass CL_Sql = new SQLclass();

        string FormID = "4";

        protected void Page_Load(object sender, EventArgs e)
        {
            SelectData();
        }

        public Boolean InsertData()
        {
            Boolean result = true;

            string empid = Session["UserLogin"].ToString();
            string Other = ip_other.Value.ToString().Trim(); //เหตุผลอื่นๆ
            //string Date = ip_date.Value.ToString().Trim(); //วันที่
            string Fullname = ip_fullname.Value.ToString().Trim(); //ชื่อ-นามสกุล ผู้ป่วย
            string HN = ip_hn.Value.ToString().Trim(); //HN
            string DateCome = ip_datecome.Value.ToString().Trim(); //วันที่รักษา
            string Todate = ip_todate.Value.ToString().Trim(); //ถึงวันที่
            string Deptid = ip_deptid.Value.ToString().Trim(); //sหัสแผนก
            string Dcnumber = ip_dcnumber.Value.ToString().Trim(); //sหัสแผนก
            string Wrongcancel = ip_wrongcancel_nb.Value.ToString().Trim(); //เลขที่เอกสาร
            string Doctorname = ip_doctorname.Value.ToString().Trim(); //sหัสแผนก
 
            string Moredetail = ip_moredetail.Value.ToString().Trim(); //รายละเอียดเพิ่มเติม
            string Namereq = ip_namereq.Value.ToString().Trim(); //ผู้ขออนุมัติ
            string Positionap = ip_position_approve.Value.ToString().Trim(); //ผู้ขออนุมัติ

            string CheckBox = txtH_Score.Value.ToString().Trim(); //ช่องเก็บค่าเช็คบ็อก 4 หัวข้อ
            string CheckBox1 = txtH_Score1.Value.ToString().Trim(); //ช่องเก็บค่าเช็คบ็อก 4 หัวข้อ
            string CheckBox2 = txtH_Score2.Value.ToString().Trim(); //ช่องเก็บค่าเช็คบ็อก 4 หัวข้อ
            string CheckBox3 = txtH_Score3.Value.ToString().Trim(); //ช่องเก็บค่าเช็คบ็อก 4 หัวข้อ


            sql = "INSERT INTO cancel_disbursement" +
                  "(cd_datetime, cd_empid, cd_status, cd_fullname, cd_hn, cd_datetreatment, cd_totreatment, cd_deptid, cd_documentnumber, cd_wrongcancel, cd_doctorname, cd_moredetail, cd_untreated, cd_sumipd, cd_notcovered, cd_wrongcost, cd_other, cd_position, cd_userreq, cd_formid)" +
                  "VALUES(CURRENT_TIMESTAMP, '"+ empid +"', 'waiting', '"+ Fullname + "', '"+ HN +"', '"+ DateCome +"', '"+ Todate +"', '"+ Deptid +"', '"+ Dcnumber +"', '"+ Wrongcancel +"', '"+ Doctorname +"', '"+ Moredetail +"', '"+ CheckBox +"', '"+ CheckBox1 +"', '"+ CheckBox2 +"', '"+ CheckBox3 +"', '"+ Other +"', '" + Positionap + "', '"+ Namereq +"', " + FormID + ");";
            

            if (CL_Sql.Modify(sql))
            {
                string cdid = CL_Sql.LastID("cd_id", "cancel_disbursement");
                if (cdid != "")
                {
                    UploadFile(cdid);
                    result = true;
                }
                    
            }

            return result;
        }

        public Boolean SelectData()
        {
            Boolean bl = false;

            if (Request.QueryString["id"] != null)
            {
                string id = Request.QueryString["id"].ToString();
                sql = "select* from cancel_disbursement where cd_id = '" + id + "' ";
                dt = new DataTable();
                dt = CL_Sql.select(sql);
                if (dt.Rows.Count > 0)
                {
                    string empid = dt.Rows[0]["cd_empid"].ToString();
                    string cdate = DateTime.Parse(dt.Rows[0]["cd_datetime"].ToString()).ToString("dd/MM/yyyy");
                    string untreat = dt.Rows[0]["cd_untreated"].ToString();
                    string sumipd = dt.Rows[0]["cd_sumipd"].ToString();
                    string notcovered = dt.Rows[0]["cd_notcovered"].ToString();
                    string wrongcost = dt.Rows[0]["cd_wrongcost"].ToString();
                    string cancelother = dt.Rows[0]["cd_cancelother"].ToString();

                    string fullname = dt.Rows[0]["cd_fullname"].ToString();
                    string hn = dt.Rows[0]["cd_hn"].ToString();
                    string datetreatment = DateTime.Parse(dt.Rows[0]["cd_datetreatment"].ToString()).ToString("dd/MM/yyyy");
                    string todatetreatment = DateTime.Parse(dt.Rows[0]["cd_totreatment"].ToString()).ToString("dd/MM/yyyy");                  
                    string deptid = dt.Rows[0]["cd_deptid"].ToString();
                    string documentnumber = dt.Rows[0]["cd_documentnumber"].ToString();
                    string wrongcancel = dt.Rows[0]["cd_wrongcancel"].ToString();
                    string doctorname = dt.Rows[0]["cd_doctorname"].ToString();

                    string moredetail = dt.Rows[0]["cd_moredetail"].ToString();                  
                    string userreq = SelectUserName(empid);
                    string position = dt.Rows[0]["cd_position"].ToString();
                    string documentid = dt.Rows[0]["cd_id"].ToString();

                    Approval(id);

                    lbl_date.Text = cdate;

                    
                    if (untreat != "")
                    {
                        rd_untreated.Checked = true;
                    }
                    
                    if (sumipd != "")
                    {
                        rd_sumipd.Checked = true;
                    }

                    if (notcovered != "")
                    {
                        rd_notcovered.Checked = true;
                    }

                    if (wrongcost != "")
                    {
                        rd_wrongcost.Checked = true;
                    }

                    if (cancelother != "")
                    {
                        rd_other.Checked = true;
                    }

                    lbl_fullname.Text = fullname;
                    lbl_hn.Text = hn;
                    lbl_datecome.Text = datetreatment;
                    lbl_todate.Text = todatetreatment;
                    lbl_deptid.Text = deptid;
                    lbl_dcnumber.Text = documentnumber;
                    lbl_wrongcancel.Text = wrongcancel;
                    lbl_doctorname.Text = doctorname;

                    lbl_dtmore.Text = moredetail;
                    lbl_uapprove.Text = userreq;
                    lbl_position_approve.Text = position;
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
                lbl_mao.Text = levelname3;
                lbl_director.Text = levelname4;
                lbl_doctor.Text = levelname5;
                lbl_DF.Text = levelname6;

                lbl_date_app_hod.Text = datetime1;
                lbl_date_deptdirector.Text = datetime2;
                lbl_date_mao.Text = datetime3;
                lbl_date_director.Text = datetime4;
                lbl_date_doctor.Text = datetime5;
                lbl_date_df.Text = datetime6;

                bl = true;
            }

            return bl;
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

        protected void submit_ServerClick(object sender, EventArgs e)
        {
            if (InsertData())
            {
                Response.Write("<script>alert('บันทึกสำเร็จ'); window.location.href='CostCancel.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('ไม่สามารถบันทึกได้กรุณาติดต่อ Admin !!');</script>");
            }
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