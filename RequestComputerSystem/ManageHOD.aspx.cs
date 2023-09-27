using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

using System.IO;
using System.Configuration;
using System.Data.OleDb;

namespace RequestComputerSystem
{
    public partial class ManageHOD : System.Web.UI.Page
    {
        string sql = "";
        DataTable dt;
        SQLclass CL_Sql = new SQLclass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLogin"] == null)
            {
                Response.Redirect("Default");
            }
            else
            {
                if (!IsPostBack)
                {
                    Branch();

                    string deptid = "";
                    if (Session["userDeptid"] != null)
                    {
                        dd_Branch.SelectedValue = Session["userDeptid"].ToString().Substring(0, 3);
                    }
                    deptid = dd_Branch.SelectedValue.ToString();

                    Department(deptid);

                    if (deptid != "")
                    {
                        dd_Department.SelectedValue = deptid;
                    }

                    Search();
                }
            }
        }

        protected void Branch()
        {
            dt = new DataTable();
            dt = CL_Sql.dt_Branch();
            dd_Branch.DataSource = dt;
            dd_Branch.DataTextField = "branchname";
            dd_Branch.DataValueField = "branchname";
            dd_Branch.DataBind();

            dd_Branch.Items.Insert(0, new ListItem("ALL", ""));
        }
        
        protected void Department(string br_select)
        {
            dt = new DataTable();
            dt = CL_Sql.dt_Department(br_select);
            dd_Department.DataSource = dt;
            dd_Department.DataTextField = "deptname";
            dd_Department.DataValueField = "deptid";
            dd_Department.DataBind();

            dd_Department.Items.Insert(0, new ListItem("ALL", ""));
        }

        public Boolean Grid1(string branch, string deptid)
        {
            Boolean bl = false;

            sql = "select d.* ,concat(ifnull(u1.userpname,''),u1.userfname,' ',u1.userlname) as 'HOD1' " +
                "\n,concat(u2.userpname, ' ', u2.userfname, ' ', u2.userlname) as 'HOD2' " +
                "\nfrom department as d " +
                "\nleft join `user` as u1 on u1.username = d.depthod1 " +
                "\nleft join `user` as u2 on u2.username = d.depthod2 " +
                "\nwhere d.deptactive = 'yes' " +
                "\nand d.deptid like '" + branch + "%' and d.deptid like '" + deptid + "%' " +
                "\nOrder by d.deptname ";
            dt = new DataTable();
            dt = CL_Sql.select(sql);
            if (dt.Rows.Count>0)
            {
                bl = true;
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();

            return bl;
        }

        protected void Search()
        {
            string br_select = dd_Branch.SelectedValue.ToString();
            string deptid = dd_Department.SelectedValue.ToString();

            Grid1(br_select, deptid);
        }

        protected void dd_Branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        protected void dd_Department_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        protected void btn_edit_ServerClick(object sender, EventArgs e)
        {
            string status = Session["UserStatus"].ToString();
            if (status == "hr" || status == "admin")
            {
                div_edit.Visible = true;
                lbl_edit_alert.Text = "";

                string deptid = txtH_ID.Value.ToString();
                sql = "select d.* ,concat(u1.userpname,' ',u1.userfname,' ',u1.userlname) as 'HOD1' " +
                    "\n,concat(u2.userpname, ' ', u2.userfname, ' ', u2.userlname) as 'HOD2' " +
                    "\nfrom department as d " +
                    "\nleft join `user` as u1 on u1.username = d.depthod1 " +
                    "\nleft join `user` as u2 on u2.username = d.depthod2 " +
                    "\nwhere deptid = '" + deptid + "' ";
                dt = new DataTable();
                dt = CL_Sql.select(sql);
                if (dt.Rows.Count > 0)
                {
                    lbl_deptname.Text = dt.Rows[0]["deptname"].ToString();
                    string depthod1 = dt.Rows[0]["depthod1"].ToString();
                    txt_hod1id.Value = depthod1;
                    txtH_hod1id.Value = depthod1;
                    txt_hod1name.Value = dt.Rows[0]["HOD1"].ToString();
                    string depthod2 = dt.Rows[0]["depthod2"].ToString();
                    txt_hod2id.Value = depthod2;
                    txtH_hod2id.Value = depthod2;
                    txt_hod2name.Value = dt.Rows[0]["HOD2"].ToString();
                    div_edit_btn.Visible = true;
                }
            }
            else
            {
                div_edit_btn.Visible = false;
                lbl_edit_alert.Text = "คุณไม่มีสิทธิ์กระทำการ กรุณาติดต่อ HR เพื่อทำการปรับเปลี่ยน !!";
            }
        }

        private Boolean updateDocument(string newID1, string oldID1, string newID2, string oldID2, string depID)
        {
            Boolean bl = false;

            if(updateRequestSystem(newID1, oldID1, newID2, oldID2, depID))
            {
                if (updateChangeOrder(newID1, oldID1, newID2, oldID2, depID))
                {
                    if (updateDisbursement(newID1, oldID1, newID2, oldID2, depID))
                    {
                        if (updatePayovertime(newID1, oldID1, newID2, oldID2, depID))
                        {
                            bl = true;
                        }
                    }
                }
            }

            return bl;
        }

        private Boolean updateRequestSystem(string newID1, string oldID1, string newID2, string oldID2, string deptID)
        {
            Boolean bl = true;
            sql = "";

            if (newID1 != oldID1)
            {
                sql = "update approve as a " +
                    "\nleft join requestsystems as rs on rs.rqsid = a.rqsid " +
                    "\nleft join request as r on r.rqid = rs.rqid" +
                    "\nset apuserapprove1 = '" + newID1 + "' " +
                    "\nwhere apstatus = 'Wait' and r.rqdepartment = '" + deptID + "' and apuserapprove1 = '" + oldID1 + "'; ";
            }

            if (newID2 != oldID2)
            {
                sql += "update approve as a " +
                    "\nleft join requestsystems as rs on rs.rqsid = a.rqsid " +
                    "\nleft join request as r on r.rqid = rs.rqid" +
                    "\nset apuserapprove2 = '" + newID2 + "' " +
                    "\nwhere apstatus = 'Wait' and r.rqdepartment = '" + deptID + "' and apuserapprove2 = '" + oldID2 + "'; ";
            }

            if (!CL_Sql.Modify(sql))
            {
                bl = false;
            }

            return bl;
        }

        private Boolean updateChangeOrder(string newID1, string oldID1, string newID2, string oldID2, string deptID)
        {
            Boolean bl = true;

            sql = "";
            for (int i = 1; i <= 6; i++)
            {
                if (sql != "")
                {
                    sql += "\n";
                }
                sql += "update changeorder set Approvelevel" + i.ToString() + " = '" + newID1 + "' " +
                    "\nwhere status = 'waiting' and deptid = '" + deptID + "' and Approvelevel" + i.ToString() + " = '" + oldID1 + "'; ";
                sql += "\nupdate changeorder set Approvelevel" + i.ToString() + " = '" + newID2 + "' " +
                    "\nwhere status = 'waiting' and deptid = '" + deptID + "' and Approvelevel" + i.ToString() + " = '" + oldID2 + "'; ";
            }

            if (!CL_Sql.Modify(sql))
            {
                bl = false;
            }

            return bl;
        }

        private Boolean updateDisbursement(string newID1, string oldID1, string newID2, string oldID2, string deptID)
        {
            Boolean bl = true;

            sql = "";
            for (int i = 1; i <= 7; i++)
            {
                if (sql != "")
                {
                    sql += "\n";
                }
                sql += "update disbursement_approve as da " +
                    "\nleft join disbursement_request as dr on dr.dr_id = da.da_crid " +
                    "\nset da.da_level" + i.ToString() + " = '" + newID1 + "' " +
                    "\nwhere da.da_status" + i.ToString() + " = 'waiting' and da.da_level" + i.ToString() + " = '" + oldID1 + "' " +
                    "\nand dr.dr_dept = '" + deptID + "'; ";
                sql += "\nupdate disbursement_approve as da " +
                    "\nleft join disbursement_request as dr on dr.dr_id = da.da_crid " +
                    "\nset da.da_level" + i.ToString() + " = '" + newID2 + "' " +
                    "\nwhere da.da_status" + i.ToString() + " = 'waiting' and da.da_level" + i.ToString() + " = '" + oldID2 + "' " +
                    "\nand dr.dr_dept = '" + deptID + "'; ";
            }

            if (!CL_Sql.Modify(sql))
            {
                bl = false;
            }

            return bl;
        }

        private Boolean updatePayovertime(string newID1, string oldID1, string newID2, string oldID2, string deptID)
        {
            Boolean bl = true;

            sql = "update payovertime set hod_id = '" + newID1 + "' " +
                "\nwhere hod_status = 'waiting' and dept_id = '" + deptID + "' and hod_id = '" + oldID1 + "'; ";
            sql += "\nupdate payovertime set hod_id = '" + newID2 + "' " +
                "\nwhere hod_status = 'waiting' and dept_id = '" + deptID + "' and hod_id = '" + oldID2 + "'; ";

            if (!CL_Sql.Modify(sql))
            {
                bl = false;
            }

            return bl;
        }

        protected void btn_update_ServerClick(object sender, EventArgs e)
        {
            string mUser = Session["UserLogin"].ToString();
            string deptid = txtH_ID.Value.ToString();
            string hod1 = txt_hod1id.Value.ToString().Trim();
            string hod2 = txt_hod2id.Value.ToString().Trim();

            string alert = "";

            sql = "select * from `user` where username = '" + hod1 + "'; ";
            dt = new DataTable();
            dt = CL_Sql.select(sql);
            if (dt.Rows.Count <= 0)
            {
                alert = "ไม่มีรหัสหัวหน้าแผนก " + hod1 + " นี้ ในระบบ !!";
            }

            if (hod2 != "")
            {
                sql = "select * from `user` where username = '" + hod2 + "'; ";
                dt = new DataTable();
                dt = CL_Sql.select(sql);
                if (dt.Rows.Count <= 0)
                {
                    alert += "<br />ไม่มีรหัสหัวหน้าฝ่าย " + hod2 + " นี้ ในระบบ !!";
                }
            }

            if (alert == "")
            {
                sql = "update department set depthod1 = '" + hod1 + "', depthod2 = '" + hod2 + "', " +
                    "\ndept_mdate = CURRENT_TIMESTAMP, dept_muser = '" + mUser + "' " +
                    "\nwhere deptid = '" + deptid + "'; ";
                if (CL_Sql.Modify(sql))
                {
                    string newID1 = hod1;
                    string oldID1 = txtH_hod1id.Value.ToString().Trim();
                    string newID2 = hod2;
                    string oldID2 = txtH_hod2id.Value.ToString().Trim();

                    if (updateDocument(newID1, oldID1, newID2, oldID2, deptid))
                    {
                        Response.Redirect(Request.RawUrl);
                    }
                    else
                    {
                        Search();
                        alert = "บันทึกข้อมูลเรียบร้อยแล้ว แต่ไม่สามารถอัพเดทเอกสารที่ร้องขอก่อนหน้านี้ได้ กรุณาติดต่อผู้ดูแลระบบ !!";
                    }
                }
                else
                {
                    alert = "ไม่สามารถบันทึกข้อมูลได้ กรุณาติดต่อผู้ดูแลระบบ !!";
                }
            }

            lbl_edit_alert.Text = alert;
        }

        protected void btnUpload_ServerClick(object sender, EventArgs e)
        {
            //Coneection String by default empty  
            string ConStr = "";
            //Extantion of the file upload control saving into ext because   
            //there are two types of extation .xls and .xlsx of Excel   
            string ext = Path.GetExtension(FileUpload1.FileName).ToLower();
            //getting the path of the file   
            string path = Server.MapPath("~/ExcelFiles/" + FileUpload1.FileName);
            //saving the file inside the MyFolder of the server  
            FileUpload1.SaveAs(path);
            Label1.Text = FileUpload1.FileName + "\'s Data showing into the GridView";
            //checking that extantion is .xls or .xlsx  
            if (ext.Trim() == ".xls")
            {
                //connection string for that file which extantion is .xls  
                ConStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
            }
            else if (ext.Trim() == ".xlsx")
            {
                //connection string for that file which extantion is .xlsx  
                ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
            }
            //making query  
            string query = "SELECT * FROM [Sheet1$]";
            //Providing connection  
            OleDbConnection conn = new OleDbConnection(ConStr);
            //checking that connection state is closed or not if closed the   
            //open the connection  
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            //create command object  
            OleDbCommand cmd = new OleDbCommand(query, conn);
            // create a data adapter and get the data into dataadapter  
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            //fill the Excel data to data set  
            da.Fill(ds);
            //set data source of the grid view  
            GridViewExcel.DataSource = ds.Tables[0];
            //binding the gridview  
            GridViewExcel.DataBind();
            //close the connection  
            conn.Close();
        }
    }
}