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

namespace RequestComputerSystem
{
    public partial class OrderRequestApprove : System.Web.UI.Page //การเรียกใช้คลาสในการ Insert Update Delete 
    {
        string sql = "";
        DataTable dt;
        DataTable dt2;
        SQLclass CL_Sql = new SQLclass();

        string status = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLogin"] == null)
            {
                Response.Redirect("Default");
            }
            else
            {
                status = Session["UserStatus"].ToString();
                if (status == "admin" || status == "it" || status == "test")
                { }
                else
                {
                    string id = Request.QueryString["id"].ToString();
                    if (!Permission(id))
                    {
                        Response.Redirect("OrderRequestList.aspx");
                    }
                }
                select_data();
            }
        }

        public Boolean Permission(string id)
        {
            Boolean bl = false;

            string empid = Session["UserLogin"].ToString();
            string Aplv = "";
            sql = "select * from changeorder where rqid = '" + id + "' ";
            dt2 = new DataTable();
            dt2 = CL_Sql.select(sql);
            if (dt2.Rows.Count > 0)
            {
                Aplv = "\nempid = '" + empid + "' or ";
                for (int i=1; i<=6; i++)
                {
                    Aplv = Aplv + " \nApprovelevel" + i.ToString() + " = '" + empid + "' ";
                    if (i < 6) { Aplv = Aplv + "or "; }
                }

                sql = "select * from changeorder where rqid = '" + id + "' and (" + Aplv + ") ";
                dt2 = new DataTable();
                dt2 = CL_Sql.select(sql);
                if (dt2.Rows.Count > 0)
                {
                    bl = true;
                }
            }

            return bl;
        }

        public Boolean select_data() //Select ข้อมูลมาแสดง
        {
            Boolean result = false;

            string id = "";
            string empid = "";

            id = Request.QueryString["id"].ToString();

            lbl_id.Text = id;

            sql = "SELECT * FROM changeorder WHERE rqid = '"+ id +"' " ;
            dt = new DataTable();
            dt = CL_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
                string OBJ = dt.Rows[0]["objective"].ToString();
                lbl_Obj.Text = OBJ;
                if (OBJ == "Other")
                {
                    lbl_Other.Text = " (" + dt.Rows[0]["Other"].ToString() + ")";
                }
                string detailorder = dt.Rows[0]["detailorder"].ToString();
                lbl_detail.Text = detailorder;
                string costingType = "yes";
                //if (detailorder == "ปรับเพิ่มราคา Order Items" || detailorder == "ปรับลดราคา Order Items")
                //{
                //    lbl_3.Text = "ความเห็นของผู้จัดการฝ่ายการตลาด";
                //    costingType = "yes";
                //}
                lbl_3.Text = "ความเห็นของผู้จัดการฝ่ายการตลาด";
                txtH_detailOrder.Value = costingType;
                txt_details.Value = dt.Rows[0]["Details"].ToString();

                // --------------------------------------------- Show File Upload --------------------
                string Path = "FileUpload/OrderRequest/";
                string FileLink = "";
                string FileName = "";
                DirectoryInfo myDirInfo;
                myDirInfo = new DirectoryInfo(Server.MapPath(Path));
                FileInfo[] arrFileInfo = myDirInfo.GetFiles("*,id" + id +".*");
                foreach (FileInfo myFileInfo in arrFileInfo)
                {
                    FileName = "- " + myFileInfo.Name.Replace(",id" + id, "");
                    FileLink = FileLink + ("<a href='" + Path + myFileInfo.Name + "' >" + FileName + "</a><br>");
                }
                lbl_file.Text = FileLink;
                // --------------------------------------------- Show File Upload --------------------

                empid = dt.Rows[0]["empid"].ToString();
                lbl_request.Text = EmployeeName(empid);
                lbl_post.Text = EmployeePost(empid);
                lbl_dept.Text = DeptName(dt.Rows[0]["deptid"].ToString());
                lbl_datereq.Text = DateTime.Parse(dt.Rows[0]["date"].ToString()).ToString("dd/MMM/yyyy");

                string level = dt.Rows[0]["Approvelv"].ToString();

                string Apv1 = dt.Rows[0]["Approvelevel1"].ToString();
                if (Apv1 != "")
                {
                    lbl_name_ap1.Text = "..." + EmployeeName(Apv1) + "...";
                    if (level == "1") { div_btn1.Visible = true; }
                }
                string ap1 = dt.Rows[0]["App1"].ToString();
                if (ap1 != "")
                {
                    string rm = dt.Rows[0]["Remark1"].ToString();
                    lbl_apy1.Text = "..." + rm;
                    lbl_apn1.Text = "..." + rm;
                    if (ap1 == "Yes") { div_apy1.Visible = true; }
                    if (ap1 == "No") { div_apn1.Visible = true; div_btn1.Visible = false; }
                    lbl_date_ap1.Text = DateTime.Parse(dt.Rows[0]["Date1"].ToString()).ToString("...dd/MMM/yyyy...");
                }

                string Apv2 = dt.Rows[0]["Approvelevel2"].ToString();
                if (Apv2 != "")
                {
                    lbl_name_ap2.Text = "..." + EmployeeName(Apv2) + "...";
                    if (level == "2") { div_btn2.Visible = true; }
                }
                string ap2 = dt.Rows[0]["App2"].ToString();
                if (ap2 != "")
                {
                    string rm = dt.Rows[0]["Remark2"].ToString();
                    lbl_apy2.Text = "..." + rm;
                    lbl_apn2.Text = "..." + rm;
                    if (ap2 == "Yes") { div_apy2.Visible = true; }
                    if (ap2 == "No") { div_apn2.Visible = true; div_btn2.Visible = false; }
                    lbl_date_ap2.Text = DateTime.Parse(dt.Rows[0]["Date2"].ToString()).ToString("...dd/MMM/yyyy...");
                }

                string Apv3 = dt.Rows[0]["Approvelevel3"].ToString();
                if (Apv3 != "")
                {
                    lbl_name_ap3.Text = "..." + EmployeeName(Apv3) + "...";
                    if (level == "3") { div_btn3.Visible = true; }
                }
                string ap3 = dt.Rows[0]["App3"].ToString();
                if (ap3 != "")
                {
                    string rm = dt.Rows[0]["Remark3"].ToString();
                    lbl_apy3.Text = "..." + rm;
                    lbl_apn3.Text = "..." + rm;
                    if (ap3 == "Yes") { div_apy3.Visible = true; }
                    if (ap3 == "No") { div_apn3.Visible = true; div_btn3.Visible = false; }
                    lbl_date_ap3.Text = DateTime.Parse(dt.Rows[0]["Date3"].ToString()).ToString("...dd/MMM/yyyy...");
                }

                string Apv4 = dt.Rows[0]["Approvelevel4"].ToString();
                if (Apv4 != "")
                {
                    lbl_name_ap4.Text = "..." + EmployeeName(Apv4) + "...";
                    if (level == "4") { div_btn4.Visible = true; }
                }
                string ap4 = dt.Rows[0]["App4"].ToString();
                if (ap4 != "")
                {
                    string rm = dt.Rows[0]["Remark4"].ToString();
                    lbl_apy4.Text = "..." + rm;
                    lbl_apn4.Text = "..." + rm;
                    if (ap4 == "Yes") { div_apy4.Visible = true; }
                    if (ap4 == "No") { div_apn4.Visible = true; div_btn4.Visible = false; }
                    lbl_date_ap4.Text = DateTime.Parse(dt.Rows[0]["Date4"].ToString()).ToString("...dd/MMM/yyyy...");
                }

                string Apv5 = dt.Rows[0]["Approvelevel5"].ToString();
                if (Apv5 != "")
                {
                    lbl_name_ap5.Text = "..." + EmployeeName(Apv5) + "...";
                    if (level == "5") { div_btn5.Visible = true; }
                }
                string ap5 = dt.Rows[0]["App5"].ToString();
                if (ap5 != "")
                {
                    string rm = dt.Rows[0]["Remark5"].ToString();
                    lbl_apy5.Text = "..." + rm;
                    lbl_apn5.Text = "..." + rm;
                    if (ap5 == "Yes") { div_apy5.Visible = true; }
                    if (ap5 == "No") { div_apn5.Visible = true; div_btn5.Visible = false; }
                    lbl_date_ap5.Text = DateTime.Parse(dt.Rows[0]["Date5"].ToString()).ToString("...dd/MMM/yyyy...");
                }

                string Apv6 = dt.Rows[0]["Approvelevel6"].ToString();
                if (Apv6 != "")
                {
                    lbl_name_ap6.Text = "..." + EmployeeName(Apv6) + "...";
                    if (level == "6") { div_btn6.Visible = true; }
                }
                string ap6 = dt.Rows[0]["App6"].ToString();
                if (ap6 != "")
                {
                    string rm = dt.Rows[0]["Remark6"].ToString();
                    lbl_apy6.Text = "..." + rm;
                    lbl_apn6.Text = "..." + rm;
                    if (ap6 == "Yes") { div_apy6.Visible = true; }
                    if (ap6 == "No") { div_apn6.Visible = true; }
                    div_btn6.Visible = false;
                    lbl_date_ap6.Text = DateTime.Parse(dt.Rows[0]["Date6"].ToString()).ToString("...dd/MMM/yyyy...");
                }

                result = true;
            }

            return result;
        }

        public string EmployeeName(string empid)
        {
            string Result = "";

            sql = "select * from `user` where username = '" + empid + "' ";
            dt2 = new DataTable();
            dt2 = CL_Sql.select(sql);
            if (dt2.Rows.Count > 0)
            {
                Result = dt2.Rows[0]["userpname"].ToString() + " " + dt2.Rows[0]["userfname"].ToString() + " " + dt2.Rows[0]["userlname"].ToString();
            }

            return Result;
        }

        public string EmployeePost(string empid)
        {
            string Result = "";

            sql = "select * from `user` where username = '" + empid + "' ";
            dt2 = new DataTable();
            dt2 = CL_Sql.select(sql);
            if (dt2.Rows.Count > 0)
            {
                Result = dt2.Rows[0]["userposition"].ToString();
            }

            return Result;
        }

        public string EmployeeDept(string empid)
        {
            string Result = "";

            sql = "select * from `user` where username = '" + empid + "' ";
            dt2 = new DataTable();
            dt2 = CL_Sql.select(sql);
            if (dt2.Rows.Count > 0)
            {
                sql = "select * from department where deptid = '" + dt2.Rows[0]["userdeptcode"].ToString() +"' ";
                dt2 = new DataTable();
                dt2 = CL_Sql.select(sql);
                if (dt2.Rows.Count > 0)
                {
                    Result = dt2.Rows[0]["deptname"].ToString();
                }
            }

            return Result;
        }

        public string DeptName(string dpid)
        {
            string result = "";

            sql = "select * from department where deptid = '" + dpid + "' ";
            dt2 = new DataTable();
            dt2 = CL_Sql.select(sql);
            if (dt2.Rows.Count > 0)
            {
                result = dt2.Rows[0]["deptname"].ToString();
            }

            return result;
        }

        protected void btn_submit_ServerClick(object sender, EventArgs e)
        {
            if (Session["UserStatus"] != null)
            {
                string next = "";

                string status = Session["UserStatus"].ToString();
                if (status == "admin" || status == "test")
                {
                    next = "yes";
                }
                else
                {
                    if (Permission(Request.QueryString["id"].ToString()))
                    {
                        next = "yes";
                    }
                }

                if (next == "yes")
                {
                    if (Update())
                    {
                        string id = Request.QueryString["id"].ToString();
                        Response.Redirect("OrderRequestApprove?id=" + id);
                    }
                    else
                    {
                        Response.Write("<script>alert('ไม่สามารถบันทึกได้กรุณาติดต่อ Admin !!');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('คุณไม่มีสิทธิ์อนุมัติขั้นตอนนี้ !!');</script>");
                }
            }
        }

        public Boolean Update()
        {
            Boolean bl = false;

            string id = Request.QueryString["id"].ToString();
            string applevel_field = "";
            string empid = "Approvelevel1";
            string level = txtH_level.Value.ToString();
            string YN = txtH_YN.Value.ToString();
            string YN_field = "";
            string Remark = txt_remark.Value.ToString().Trim();
            string Remark_field = "";
            string Date_field = "";
            string status = "";

            YN_field = "App" + level;
            Remark_field = "Remark" + level;
            Date_field = "Date" + level;

            if (YN == "Yes")
            {
                status = "Waiting";

                level = (int.Parse(level) + 1).ToString();
                int lv = int.Parse(level);

                if (lv == 2) { empid = "'150216'"; } // <---------------------- คณะกรรมการ Costing
                else if (lv == 3) { empid = "'100384'"; } // <----------------- ผู้จัดการฝ่าย บัญชี
                else if (lv == 4) { empid = "'151579'"; } // <----------------- รองผู้อำนวยการโรงพยาบาล
                else if (lv == 5) { empid = "'151588'"; } // <----------------- ฝ่ายกลยุทธ์และสารสนเทศ
                else if (lv == 6) { empid = "'brh_it'"; } // <----------------- IT
                else { }

                if(txtH_detailOrder.Value == "yes") // flow Costing Only
                {
                    if (lv == 2){ empid = "'100384'"; } // <---------------------- คณะกรรมการ Costing
                    else if (lv == 3) { empid = "'151579'"; level = "4"; } // <----------------- รองผู้อำนวยการโรงพยาบาล
                    else if (lv == 5) { empid = "'150831'"; level = "3"; } // <----------------- ผู้จัดการฝ่าย การตลาด
                    else if (lv == 4) { empid = "'151588'"; level = "5"; } // <----------------- ฝ่ายกลยุทธ์และสารสนเทศ
                    else if (lv == 6) { empid = "'brh_it'"; } // <----------------- IT
                    else { }
                }

                if (lv > 6) { status = "Finish"; level = (lv - 1).ToString(); empid = "'brh_it'"; }
            }
            else
            {
                status = "Reject";

                //if (int.Parse(level) > 1) { level = (int.Parse(level) - 1).ToString(); }
                empid = "'" + Session["UserLogin"].ToString() + "'";
            }

            applevel_field = "Approvelevel" + level;

            sql = "UPDATE changeorder " +
                "SET " + applevel_field + " = " + empid + ", " + YN_field + " = '" + YN + "', " + Remark_field + " = '" + Remark + "' " +
                ", " + Date_field + " = current_timestamp, Approvelv = '" + level + "', status = '" + status + "' " +
                "WHERE rqid = '" + id + "'; ";
            if (CL_Sql.Modify(sql))
            {
                if (YN == "Yes")
                {
                    if (int.Parse(level) > 1 && int.Parse(level) <= 6)
                    {
                        bl = false;
                        string next = "";

                        //if (int.Parse(level) == 4) // << ------ อนุมัติทีเดียว 2 ช่อง
                        //{
                        //    empid = "151588";
                        //    sql = "update changeorder set Approvelevel5 = '" + empid + "', Approvelv = '5', App4 = App3, Remark4 = Remark3, Date4 = Date3 where rqid = '" + id + "' ";
                        //    if (CL_Sql.Modify(sql))
                        //    {
                        //        next = "y";
                        //    }
                        //}
                        //else
                        //{
                        //    next = "y";
                        //}

                        //if (next == "y")
                        //{
                        //    SendMail(id, empid, YN);
                        //    bl = true;
                        //}

                        SendMail(id, empid, YN);

                        if (int.Parse(level) == 6 || status == "Reject") 
                        {
                            YN = "Finish";
                            if (status == "Reject") { YN = status; }

                            sql = "select * from changeorder where rqid='" + id + "' ";
                            dt = new DataTable();
                            dt = CL_Sql.select(sql);
                            if (dt.Rows.Count > 0)
                            {
                                empid = dt.Rows[0]["empid"].ToString();
                                SendMail(id, empid, YN);
                            }
                        }

                        bl = true;
                    }
                }
                else
                {
                    //SendMail(id, empid, YN);

                    sql = "select * from changeorder where rqid = '" + id + "' ";
                    dt = new DataTable();
                    dt = CL_Sql.select(sql);
                    if (dt.Rows.Count > 0)
                    {
                        empid = "'" + dt.Rows[0]["empid"].ToString() + "'";
                        YN = "Reject";
                        SendMail(id, empid, YN);
                    }

                    bl = true;
                }
            }
            
            return bl;
        }

        public Boolean SendMail(string id, string apvid ,string YN)
        {
            Boolean bl = false;

            string emailTo = "";
            string emailFrom = "info.RequestSystem@brh.co.th";

            sql = "select * from `user` where username = " + apvid + " ";
            dt = new DataTable();
            dt = CL_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
                emailTo = dt.Rows[0]["useremail"].ToString();

                string sj = "";
                string htmlBody = "";
                string htmlFooter = "";

                if (YN == "Yes")
                {
                    sj = "Change Order Items (Awaiting approval)";
                    htmlBody = "<h1 style='color: #4485b8;'>Change Order Items (Awaiting approval).</h1>" +
                                "<p><strong style='color: #000;'> ID:</strong> &nbsp; " + id + " </p>" +
                                "<p><strong style='color: #000;'> Waiting you approve</strong></p>";
                }
                else if (YN == "Reject")
                {
                    sj = "Change Order Items (Rejected)";
                    htmlBody = "<h1 style='color: #4485b8;'>Change Order Items (Rejected).</h1>" +
                                "<p><strong style='color: #000;'> ID:</strong> &nbsp; " + id + " </p>" +
                                "<p><strong style='color: #000;'> Rejected</strong></p>";
                }
                else if (YN == "Finish")
                {
                    sj = "Change Order Items (Finish)";
                    htmlBody = "<h1 style='color: green;'>Change Order Items (Finish).</h1>" +
                                "<p><strong style='color: #000;'> ID:</strong> &nbsp; " + id + " </p>" +
                                "<p><strong style='color: #000;'> Your request finish.</strong></p>";
                }
                else
                {
                    sj = "Change Order Items (ID:" + id + ") ERROR not have Status";
                    htmlBody = "<h1 style='color: green;'>Change Order Items (ERROR).</h1>";

                    emailTo = "brh.hito@brh.co.th";
                }

                htmlFooter = "<p><a href='http://10.121.10.212:4001/?usermail=" + apvid + "'>Link : Access to the system.</a></p>" +
                            "<p></p><p></p><p>Please do not reply to this email because this address is not monitored.</p>" +
                            "<p>Automatic send by Request Systems.</p>";


                if (Session["Test"] != null)
                {
                    if (Session["Test"].ToString() == "Yes") { emailTo = "brh.hito@brh.co.th"; }
                }

                if (emailTo != "")
                {
                    BRH_SendMail.ServiceSoapClient BRHmail = new BRH_SendMail.ServiceSoapClient();
                    BRHmail.MailSend(emailTo, sj, htmlBody + htmlFooter, emailFrom, "Systems Request", "", "", "", false);
                }

                sql = "update changeorder set emailTo = '" + emailTo + "', emailDate = CURRENT_TIMESTAMP where rqid = '" + id + "' ";
                if (CL_Sql.Modify(sql))
                {
                    bl = true;
                }
            }

            return bl;
        }
    }
}