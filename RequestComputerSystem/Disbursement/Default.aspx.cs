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
    public partial class Default : System.Web.UI.Page
    {
        string sql = "";
        DataTable dt;
        SQLclass CL_Sql = new SQLclass();

        Files CL_Files = new Files();

        DisbursementClass cl_pv = new DisbursementClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("../login.aspx");
            }
            else
            {
                string HOD = Session["HOD"].ToString();
                string test = "";
                if (Session["Test"] != null) { test = Session["Test"].ToString(); }
                string userStatus = Session["UserStatus"].ToString();
                if (HOD == "Yes" || test == "Yes" || userStatus == "admin")
                {
                    if (!IsPostBack)
                    {
                        string userDept = "";
                        if (Session["userDeptid"] != null)
                        {
                            userDept = Session["userDeptid"].ToString();
                        }

                        Branch(userDept);
                        SelectDept(userDept);
                        HODname();
                        lbl_rdType.Text = ShowType();
                    }
                }
                else
                {
                    Response.Write("<script>alert('เฉพาะหัวหน้าแผนกเท่านั้น !!'); window.location.href='../Default.aspx';</script>");
                }
            }
        }

        public string ShowType()
        {
            string result = "";

            sql = "select * from disbursement_form where df_active = 'yes' order by df_id ";
            dt = new DataTable();
            dt = CL_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i=0; i<dt.Rows.Count; i++)
                {
                    string dfid = dt.Rows[i]["df_id"].ToString();
                    string dfname = dt.Rows[i]["df_name"].ToString();
                    result = result + "<div class=\"col-6 mx-auto\">" +
                                "<input type=\"radio\" name=\"rdType\" value=\"" + dfid + "\" onclick=\"getType()\" /> " + dfname + " " +
                            "</div> ";
                }
            }
            
            return result;
        }

        public void Branch(string br_select)
        {
            dt = new DataTable();
            dt = CL_Sql.dt_Branch();

            ddl_branch.DataSource = dt;
            ddl_branch.DataTextField = "branchname";
            ddl_branch.DataValueField = "branchname";
            ddl_branch.DataBind();

            if (br_select != "")
            {
                ddl_branch.SelectedValue = br_select.Substring(0, 3);
            }
        }

        public Boolean SelectDept(string deptid)
        {
            Boolean result = false;

            string br_select = ddl_branch.SelectedValue.ToString();

            dt = new DataTable();
            dt = CL_Sql.dt_Department(br_select);
            if (dt.Rows.Count > 0)
            {
                ddl_department.DataSource = dt;
                ddl_department.DataTextField = "deptname";
                ddl_department.DataValueField = "deptid";
                ddl_department.DataBind();

                result = true;
            }

            if (deptid != "")
            {
                try
                {
                    ddl_department.SelectedValue = deptid;
                }
                catch
                { }
            }

            return result;
        }

        public Boolean InsertData()
        {
            Boolean result = false;

            string empid = Session["UserLogin"].ToString();
            string ddlform = txtH_Type.Value.ToString();
            string form_name = cl_pv.SelectFormName(ddlform);
            string ddldept = ddl_department.SelectedValue.ToString();
            string branch = ddldept.Substring(0, 3);
            string status = "";

            string forfname = txt_forfName.Value.ToString().Trim();
            string forlname = txt_forlName.Value.ToString().Trim();
            string forpname = txt_forpName.Value.ToString().Trim();
            string forName = forfname + " " + forlname;

            string type = SelectType(ddlform);

            sql = "INSERT INTO disbursement_request (dr_datetime, dr_empid, dr_formid, dr_status, dr_type, dr_dept, dr_forfname, dr_forlname, dr_forpname) " +
                "\nVALUES(CURRENT_TIMESTAMP, '" + empid + "', '"+ ddlform + "', 'waiting', '"+ type + "', '"+ ddldept +"', '" + forfname + "', '" + forlname + "', '" + forpname + "'); ";
            if (CL_Sql.Modify(sql))
            {
                string drid = ""; //CL_Sql.LastID("dr_id", "disbursement_request");
                sql = "select max(dr_id) as 'dr_id' from disbursement_request " +
                    "\nwhere dr_empid = '" + empid + "'; ";
                dt = new DataTable();
                dt = CL_Sql.select(sql);
                if (dt.Rows.Count > 0)
                {
                    drid = dt.Rows[0]["dr_id"].ToString();
                }
                
                if (drid != "")
                {
                    UploadFile(drid);

                    string drType = "";

                    sql = "select * from disbursement_request where dr_id = '"+ drid + "'; ";
                    dt = new DataTable();
                    dt = CL_Sql.select(sql);
                    if (dt.Rows.Count > 0)
                    {
                        status = dt.Rows[0]["dr_status"].ToString();
                        drType = dt.Rows[0]["dr_type"].ToString();
                    }

                    if (cl_pv.approval(branch, drid, type, ddldept))
                    {
                        DataTable DT_emp = new DataTable();
                        DT_emp = cl_pv.SelectMailUser(empid);
                        string emailTo = DT_emp.Rows[0]["useremail"].ToString();
                        string subject = "Request Disbursement ID "+ drid +" ";
                        string Body = "<h3>เรียน " + DT_emp.Rows[0]["fullName"].ToString() + ",</h3>" +
                            "<br />" +
                            "&nbsp;&nbsp;<h5> เรื่อง." + form_name + ".<h5>" +
                            "<br />" +
                            "&nbsp;&nbsp; เอกสารเลขที่ :" + drid + "" +
                            "<br />" +
                            "&nbsp;&nbsp; สถานะ :" + status + "" +
                            "<p><a href='http://10.121.10.212:4001/Login?goto=Disbursement/Approve?id=" + drid + "&type=" + drType + "'>Link : Access to the system.</a></p>" +
                            "<p></p><p></p><p>Please do not reply to this email because this address is not monitored.</p>" +
                            "<p>Automatic send by Request Systems.</p>";

                        if (Session["Test"] != null) // --------------------------- For Test -------------------------
                        {
                            if (Session["Test"].ToString() == "Yes") { emailTo = "brh.hito@brh.co.th"; }
                        }

                        if (cl_pv.SendMail(drid,emailTo, subject, Body))
                        {
                            result = true;
                        }
                    }
                }
                    
            }

                return result;
        }

        public string SelectType(string formid)
        {
            string result = "";

            sql = "SELECT * FROM disbursement_form where df_id = '"+ formid + "' ";

            dt = new DataTable();
            dt = CL_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
                string type = dt.Rows[0]["df_type"].ToString();

                result = type;
            }

                return result;

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
                    FileName = "id" + id +","+ FileName.ToString();
                    uploadFile.SaveAs(System.IO.Path.Combine(Server.MapPath(Path), FileName));
                    bl = true;
                }
            }
            return bl;
        }

        protected void submit_1_ServerClick(object sender, EventArgs e)
        {
            string Type = txtH_Type.Value.ToString();
            string dept = ddl_department.SelectedValue.ToString();
            string haveFile = "";
            if (FileUpload1.HasFile) 
            { 
                haveFile = "yes";

                lbl_fileAlert.Text = "";
                string checkFile = "";
                string FileName = FileUpload1.FileName;
                if (FileName != "")
                {
                    checkFile = CL_Files.FileNameNotUse(FileName);
                    if (checkFile != "")
                    {
                        lbl_fileAlert.Text = "<br />" + checkFile;
                        lbl_fileAlert.ForeColor = System.Drawing.Color.Red;
                        haveFile = "";
                    }
                }
            }
            if (Type == "" || dept == "" || haveFile == "")
            {
                Response.Write("<script>alert('กรุณากรอกข้อมูล หรือ แนบไฟล์เอกสาร ให้ครบถ้วน !!');</script>");
            }
            else 
            {
                if (InsertData())
                {
                    Response.Write("<script>alert('บันทึกสำเร็จ'); window.location.href='Default.aspx';</script>");
                } 
                else
                {
                    Response.Write("<script>alert('ไม่สามารถบันทึกได้กรุณาติดต่อ Admin'); window.location.href='Default.aspx';</script>");
                }
            }
            
        }

        protected void HODname()
        {
            string deptid = ddl_department.SelectedValue.ToString();

            string hodName = "";
            sql = "select deptid, depthod1, depthod2 from department " +
                "\nwhere deptid = '" + deptid + "';";
            dt = new DataTable();
            dt = CL_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
                DataTable dtE = new DataTable();
                dtE = CL_Sql.EmpName(dt.Rows[0]["depthod1"].ToString());
                if (dtE.Rows.Count > 0)
                {
                    string hod1 = dtE.Rows[0]["fullname"].ToString();
                    string pos1 = " [" + dtE.Rows[0]["userposition"].ToString() + "]";
                    hodName = hod1 + pos1;
                    if (hod1 != "")
                    {
                        hodName += "<br />";
                    }
                }

                dtE = new DataTable();
                dtE = CL_Sql.EmpName(dt.Rows[0]["depthod2"].ToString());
                if (dtE.Rows.Count > 0)
                {
                    string hod2 = dtE.Rows[0]["fullname"].ToString();
                    string pos2 = " [" + dtE.Rows[0]["userposition"].ToString() + "]";
                    hodName += hod2 + pos2;
                }
            }

            lbl_hod.Text = hodName;
        }

        protected void ddl_branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string br_select = ddl_branch.SelectedValue.ToString();
            SelectDept(br_select);
            HODname();
        }

        protected void ddl_department_SelectedIndexChanged(object sender, EventArgs e)
        {
            HODname();
        }
    }
}