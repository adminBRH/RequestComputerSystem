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
    public partial class ApproveEvent : System.Web.UI.Page
    {
        string sql = "";
        DataTable dt;
        SQLclass cl_Sql = new SQLclass();

        string UserStatus = "";
        string UserLogin = "";
        string UserLoginName = "";
        string rqid = "";
        string rqsid = "";
        string apLevelMax = "";

        string sysname = "";
        string sysdetail = "";

        string UserRequest = "";
        string PostRequest = "";

        string UseridActor = "";
        string UserActor = "";
        string PostActor = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLogin"] == null)
            {
                Response.Redirect("Default");
            }

            try
            {
                UserStatus = Session["UserStatus"].ToString();
                UserLogin = Session["UserLogin"].ToString();
                UserLoginName = Session["UserFullName"].ToString();

                rqsid = Request.QueryString["id"].ToString();

                Details();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"')</script>");
                //Response.Redirect("ApproveEvent.aspx?id=1");
            }
            
        }

        // Details from request 
        private void Details()
        {
            sql = "select r.rqid, rs.rqsid, concat(ifnull(u.userpname,''),u.userfname,' ',u.userlname) as 'userFullName', u.userposition, a.apdate, a.apstatus, a.aprequestuser " +
                    ",a.userid , concat(ifnull(u2.userpname,''),u2.userfname,' ',u2.userlname) as 'userFullName2', u2.userposition as 'userposition2', m.apLevelMax " +
                    ", rs.sysid, rs.rqsvalue " +
                    ", s.sysname " +
                    ", r.rqpost, r.rqdepartment, d.deptname, concat(r.rqpname,' ',r.rqfname,' ',r.rqlname) as 'UserReqName', r.rqremark " +
                    "from approve as a " +
                    "left join requestsystems as rs on a.rqsid = rs.rqsid " +
                    "left join request as r on r.rqid = rs.rqid " +
                    "left join department as d on d.deptid = r.rqdepartment " +
                    "left join systems as s on rs.sysid = s.sysid " +
                    "left join `user` as u on a.aprequestuser = u.username " +
                    "left join `user` as u2 on a.userid=u2.username " +
                    "left join (select apid,max(aplevel) as apLevelMax from approve where apstatus<>'Wait' and rqsid = " + rqsid + ") as m on a.apid=m.apid " +
                    "where a.aplevel = 1 and a.apstatus = 'Approved' and a.rqsid = " + rqsid;
            dt = new DataTable();
            dt = cl_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
                rqid = dt.Rows[0]["rqid"].ToString();
                lb0_0.Text = "[" + rqid + "](" + rqsid + ")";
                sysname = dt.Rows[0]["sysname"].ToString();
                lb0_1.Text = sysname;
                sysdetail = dt.Rows[0]["rqsvalue"].ToString();
                if (sysdetail != "")
                {
                    sysdetail = " --> " + sysdetail;
                }
                lb0_1_detail.Text = sysdetail;
                lb0_2.Text = dt.Rows[0]["UserReqName"].ToString();
                lb0_3.Text = dt.Rows[0]["rqpost"].ToString();
                lbl_branch.Text = dt.Rows[0]["rqdepartment"].ToString().Substring(0, 3);
                lb0_4.Text = dt.Rows[0]["rqdepartment"].ToString() + " " + dt.Rows[0]["deptname"].ToString();
                lb0_5.Text = dt.Rows[0]["rqremark"].ToString();

                UserRequest = dt.Rows[0]["userFullName"].ToString();
                lb1_1.Text = dt.Rows[0]["userFullName2"].ToString();
                UserActor = dt.Rows[0]["userFullName2"].ToString();
                UseridActor = dt.Rows[0]["userid"].ToString();
                PostRequest = dt.Rows[0]["userposition"].ToString();
                lb1_2.Text = dt.Rows[0]["userposition2"].ToString();
                PostActor = dt.Rows[0]["userposition2"].ToString();
                lb1_3.Text = dt.Rows[0]["apdate"].ToString();

                apLevelMax = dt.Rows[0]["apLevelMax"].ToString();

                RunBlock();
            }
        }

        // Data for Block Line Approve
        private DataTable BlockData(string level, string level_sub)
        {
            sql = "select concat(u.userpname,' ',u.userfname,' ',u.userlname) as 'ApName' " +
                "\n, concat(u2.userpname,' ',u2.userfname,' ',u2.userlname) as 'SignName' " +
                "\n, u.userposition, a.apdate, a.apstatus, a.apremark " +
                "\n, a.apuserapprove1, a.apuserapprove2 " +
                "\nfrom approve as a " +
                "\nleft join `user` as u on a.apuserapprove1 = u.username " +
                "\nleft join `user` as u2 on a.userid = u2.username " +
                "\nwhere a.aplevel = " + level + " and a.aplevel_sub = " + level_sub + " and a.rqsid = " + rqsid + " " +
                "\norder by apid";
            dt = new DataTable();
            dt = cl_Sql.select(sql);
            if (dt.Rows.Count > 0)
            { }

            return dt;
        }

        // ตรวจสอบโดย(หัวหน้าแผนก) ------------ Level 2 --------------------------------------------
        public string Block2()
        {
            string apstatus = "";

            dt = new DataTable();
            dt = BlockData("2", "0");
            if (dt.Rows.Count > 0)
            {
                apstatus = dt.Rows[0]["apstatus"].ToString();

                lb2_1.Text = dt.Rows[0]["SignName"].ToString();
                lb2_2.Text = dt.Rows[0]["userposition"].ToString();

                string[] root = new string[] {"0", dt.Rows[0]["apuserapprove1"].ToString(), dt.Rows[0]["apuserapprove2"].ToString() };
                string vib = "";

                foreach (string i in root)
                {
                    if (UserLogin==i || UserStatus=="admin")
                    {
                        vib = "y";
                        break;
                    }
                    else
                    {
                        vib = "n";
                    }
                }

                if (apstatus == "Approved" || apstatus == "Finish")
                {
                    lb2_3.Text = dt.Rows[0]["apdate"].ToString();
                    div2.Attributes.Add("class", "card border-left-success shadow h-100 py-2s");
                    i2.Attributes.Add("class", "fas fa-check fa-2x text-success");
                }
                else if (apstatus == "Wait")
                {
                    div2.Attributes.Add("class", "card border-left-warning shadow h-100 py-2s");
                    i2.Attributes.Add("class", "fas fa-clock fa-2x text-warning");
                    if (vib == "y")
                    {
                        lb2_1.Text = dt.Rows[0]["ApName"].ToString();

                        bt_edit.Visible = true;

                        bt_2_1.Visible = true;
                        bt_2_2.Visible = true;

                        bt_1_2.Visible = true;
                    }
                }
                else
                {
                    div2.Attributes.Add("class", "card border-left-danger shadow h-100 py-2s divDisable");
                    i2.Attributes.Add("class", "fas fa-times fa-2x text-danger");
                    if (vib == "y" && apLevelMax=="2")
                    {
                        bt_2_3.Visible = true;
                    }
                    lb2_4.Text = "หมายเหตุ : " + dt.Rows[0]["apremark"].ToString();
                }

            }
            return apstatus;
        }

        // ตรวจสอบโดย(ผู้จัดการสายงาน) ---------- Level 3 ----------------------------------------------
        public string Block3()
        {
            string apstatus = "";

            dt = new DataTable();
            dt = BlockData("3", "0");
            if (dt.Rows.Count > 0)
            {
                apstatus = dt.Rows[0]["apstatus"].ToString();

                lb3_1.Text = dt.Rows[0]["SignName"].ToString();
                lb3_2.Text = dt.Rows[0]["userposition"].ToString();

                string[] root = new string[] { dt.Rows[0]["apuserapprove1"].ToString(), dt.Rows[0]["apuserapprove2"].ToString() };
                string vib = "";

                foreach (string i in root)
                {
                    if (UserLogin == i || UserStatus == "admin")
                    {
                        vib = "y";
                        break;
                    }
                    else
                    {
                        vib = "n";
                    }
                }

                if (apstatus == "Approved" || apstatus == "Finish")
                {
                    lb3_3.Text = dt.Rows[0]["apdate"].ToString();
                    div3.Attributes.Add("class", "card border-left-success shadow h-100 py-2s");
                    i3.Attributes.Add("class", "fas fa-check fa-2x text-success");
                }
                else if (apstatus == "Wait")
                {
                    div3.Attributes.Add("class", "card border-left-warning shadow h-100 py-2s");
                    i3.Attributes.Add("class", "fas fa-clock fa-2x text-warning");
                    if (vib == "y")
                    {
                        lb3_1.Text = dt.Rows[0]["ApName"].ToString();
                        bt_3_1.Visible = true;
                        bt_3_2.Visible = true;
                    }
                }
                else
                {
                    div3.Attributes.Add("class", "card border-left-danger shadow h-100 py-2s");
                    i3.Attributes.Add("class", "fas fa-times fa-2x text-danger");
                    if (vib == "y" && apLevelMax == "3")
                    {
                        bt_3_3.Visible = true;
                    }
                    lb3_4.Text = "หมายเหตุ : " + dt.Rows[0]["apremark"].ToString();
                }

            }
            return apstatus;
        }
        
        // เห็นชอบโดย ------------------------ Level 3x1 ----------------------------------------------
        public string Block3x1()
        {
            int X = 1;
            string apstatus = "";
            string signname = "";
            string apname = "";
            string userposition = "";
            string userapprove1 = "";
            string userapprove2 = "";
            string apdate = "";
            string apremark = "";

            dt = new DataTable();
            dt = BlockData("3", "1");
            if (dt.Rows.Count > 0)
            {
                apstatus = dt.Rows[0]["apstatus"].ToString();
                signname = dt.Rows[0]["SignName"].ToString();
                apname = dt.Rows[0]["ApName"].ToString();
                userposition = dt.Rows[0]["userposition"].ToString();
                userapprove1 = dt.Rows[0]["apuserapprove1"].ToString();
                userapprove2 = dt.Rows[0]["apuserapprove2"].ToString();
                apdate = dt.Rows[0]["apdate"].ToString();
                apremark = dt.Rows[0]["apremark"].ToString();

                lb3x1_1.Text = signname;
                lb3x1_2.Text = userposition;

                string[] root = new string[] { userapprove1, userapprove2 };
                string vib = "";

                foreach (string i in root)
                {
                    if (UserLogin == i || UserStatus == "admin")
                    {
                        vib = "y";
                        break;
                    }
                    else
                    {
                        vib = "n";
                    }
                }

                if (apstatus == "Approved" || apstatus == "Finish")
                {
                    lb3x1_3.Text = apdate;
                    div3x1.Attributes.Add("class", "card border-left-success shadow h-100 py-2s");
                    i3x1.Attributes.Add("class", "fas fa-check fa-2x text-success");
                }
                else if (apstatus == "Wait")
                {
                    div3x1.Attributes.Add("class", "card border-left-warning shadow h-100 py-2s");
                    i3x1.Attributes.Add("class", "fas fa-clock fa-2x text-warning");
                    if (vib == "y")
                    {
                        lb3x1_1.Text = apname;
                        bt_3x1_1.Visible = true;
                        bt_3x1_2.Visible = true;
                    }
                }
                else
                {
                    div3x1.Attributes.Add("class", "card border-left-danger shadow h-100 py-2s");
                    i3x1.Attributes.Add("class", "fas fa-times fa-2x text-danger");
                    if (vib == "y" && apLevelMax == "3")
                    {
                        bt_3x1_3.Visible = true;
                    }
                    lb3x1_4.Text = "หมายเหตุ : " + apremark;
                }

            }
            return apstatus;
        }

        // ทบทวนเห็นชอบ ---------------------- Level 4 ----------------------------------------------
        public string Block4()
        {
            string apstatus = "";

            dt = new DataTable();
            dt = BlockData("4", "0");
            if (dt.Rows.Count > 0)
            {
                apstatus = dt.Rows[0]["apstatus"].ToString();

                lb4_1.Text = dt.Rows[0]["SignName"].ToString();
                lb4_2.Text = dt.Rows[0]["userposition"].ToString();

                string[] root = new string[] { dt.Rows[0]["apuserapprove1"].ToString(), dt.Rows[0]["apuserapprove2"].ToString() };
                string vib = "";

                foreach (string i in root)
                {
                    if (UserLogin == i || UserStatus == "admin")
                    {
                        vib = "y";
                        break;
                    }
                    else
                    {
                        vib = "n";
                    }
                }

                if (apstatus == "Approved" || apstatus == "Finish")
                {
                    lb4_3.Text = dt.Rows[0]["apdate"].ToString();
                    div4.Attributes.Add("class", "card border-left-success shadow h-100 py-2s");
                    i4.Attributes.Add("class", "fas fa-check fa-2x text-success");
                    lb4_4.Text = "หมายเหตุ : " + dt.Rows[0]["apremark"].ToString();
                }
                else if (apstatus == "Wait")
                {
                    div4.Attributes.Add("class", "card border-left-warning shadow h-100 py-2s");
                    i4.Attributes.Add("class", "fas fa-clock fa-2x text-warning");
                    if (vib == "y")
                    {
                        lb4_1.Text = dt.Rows[0]["ApName"].ToString();
                        bt_4_1.Visible = true;
                        bt_4_2.Visible = true;
                    }
                }
                else
                {
                    div4.Attributes.Add("class", "card border-left-danger shadow h-100 py-2s");
                    i4.Attributes.Add("class", "fas fa-times fa-2x text-danger");
                    if (vib == "y" && apLevelMax == "4")
                    {
                        bt_4_3.Visible = true;
                    }
                    lb4_4.Text = "หมายเหตุ : " + dt.Rows[0]["apremark"].ToString();
                }

            }
            return apstatus;
        }

        // เห็นควรอนุมัติโดย --------------------- Level 5 ----------------------------------------------
        public string Block5()
        {
            string apstatus = "";

            dt = new DataTable();
            dt = BlockData("5", "0");
            if (dt.Rows.Count > 0)
            {
                apstatus = dt.Rows[0]["apstatus"].ToString();

                lb5_1.Text = dt.Rows[0]["SignName"].ToString();
                lb5_2.Text = dt.Rows[0]["userposition"].ToString();

                string[] root = new string[] { dt.Rows[0]["apuserapprove1"].ToString(), dt.Rows[0]["apuserapprove2"].ToString() };
                string vib = "";

                foreach (string i in root)
                {
                    if (UserLogin == i || UserStatus == "admin")
                    {
                        vib = "y";
                        break;
                    }
                    else
                    {
                        vib = "n";
                    }
                }

                if (apstatus == "Approved" || apstatus == "Finish")
                {
                    lb5_3.Text = dt.Rows[0]["apdate"].ToString();
                    div5.Attributes.Add("class", "card border-left-success shadow h-100 py-2s");
                    i5.Attributes.Add("class", "fas fa-check fa-2x text-success");
                }
                else if (apstatus == "Wait")
                {
                    div5.Attributes.Add("class", "card border-left-warning shadow h-100 py-2s");
                    i5.Attributes.Add("class", "fas fa-clock fa-2x text-warning");
                    if (vib == "y")
                    {
                        lb5_1.Text = dt.Rows[0]["ApName"].ToString();
                        bt_5_1.Visible = true;
                        bt_5_2.Visible = true;
                    }
                }
                else
                {
                    div5.Attributes.Add("class", "card border-left-danger shadow h-100 py-2s");
                    i5.Attributes.Add("class", "fas fa-times fa-2x text-danger");
                    if (vib == "y" && apLevelMax == "5")
                    {
                        bt_5_3.Visible = true;
                    }
                }
                lb5_4.Text = "หมายเหตุ : " + dt.Rows[0]["apremark"].ToString();

            }
            return apstatus;
        }

        // อนุมัติโดย --------------------------- Level 6 ----------------------------------------------
        public string Block6()
        {
            string apstatus = "";

            dt = new DataTable();
            dt = BlockData("6", "0");
            if (dt.Rows.Count > 0)
            {
                apstatus = dt.Rows[0]["apstatus"].ToString();

                lb6_1.Text = dt.Rows[0]["SignName"].ToString();
                lb6_2.Text = dt.Rows[0]["userposition"].ToString();

                string[] root = new string[] { dt.Rows[0]["apuserapprove1"].ToString(), dt.Rows[0]["apuserapprove2"].ToString() };
                string vib = "";

                foreach (string i in root)
                {
                    if (UserLogin == i || UserStatus == "admin")
                    {
                        vib = "y";
                        break;
                    }
                    else
                    {
                        vib = "n";
                    }
                }

                if (apstatus == "Approved" || apstatus == "Finish")
                {
                    lb6_3.Text = dt.Rows[0]["apdate"].ToString();
                    div6.Attributes.Add("class", "card border-left-success shadow h-100 py-2s");
                    i6.Attributes.Add("class", "fas fa-check fa-2x text-success");
                }
                else if (apstatus == "Wait")
                {
                    div6.Attributes.Add("class", "card border-left-warning shadow h-100 py-2s");
                    i6.Attributes.Add("class", "fas fa-paperclip fa-2x text-warning");
                    if (vib == "y")
                    {
                        lb6_1.Text = dt.Rows[0]["ApName"].ToString();
                        bt_6_1.Visible = true;
                        bt_6_2.Visible = true;
                    }
                }
                else
                {
                    div6.Attributes.Add("class", "card border-left-danger shadow h-100 py-2s");
                    i6.Attributes.Add("class", "fas fa-times fa-2x text-danger");
                    if (vib == "y" && apLevelMax == "6")
                    {
                        bt_6_3.Visible = true;
                    }
                    lb6_4.Text = "หมายเหตุ : " + dt.Rows[0]["apremark"].ToString();
                }

            }
            return apstatus;
        }

        // ผู้ดำเนินการ -------------------------- Level 7 ----------------------------------------------
        public string Block7()
        {
            string apstatus = "";

            //sql = "select * from approve as a where aplevel = 7 and aplevel_sub = 0 and rqsid = " + rqsid;
            dt = new DataTable();
            dt = BlockData("7", "0");
            if (dt.Rows.Count > 0) 
            {
                apstatus = dt.Rows[0]["apstatus"].ToString();

                lb7_1.Text = "<b>" + dt.Rows[0]["SignName"].ToString() + "</b>";
                lb7_2.Text = dt.Rows[0]["userposition"].ToString();

                if (apstatus == "Wait")
                {
                    div7.Attributes.Add("class", "card border-left-warning shadow h-100 py-2s");
                    i7.Attributes.Add("class", "fas fa-paperclip fa-2x text-warning");

                    lb7_1.Text = "<b>" + dt.Rows[0]["ApName"].ToString() + "</b>";
                    if (UserStatus == "admin" || UserStatus == "it")
                    {
                        bt_7_1.Visible = true;
                        bt_7_2.Visible = true;
                    }
                }
                else if (apstatus == "Acknowledge")
                {
                    div7.Attributes.Add("class", "card border-left-success shadow h-100 py-2s");
                    i7.Attributes.Add("class", "fas fa-eye fa-2x text-success");

                    lb7_3.Text = dt.Rows[0]["apdate"].ToString();
                }
                else if (apstatus == "Cancel")
                {
                    div7.Attributes.Add("class", "card border-left-danger shadow h-100 py-2s");
                    i7.Attributes.Add("class", "fas fa-times fa-2x text-danger");
                    if (UserStatus == "admin" || UserStatus == "it")
                    {
                        bt_7_3.Visible = true;
                    }
                    lb7_4.Text = "หมายเหตุ : " + dt.Rows[0]["apremark"].ToString();
                }
                else { }

                if (dt.Rows[0]["userid"].ToString() != "0")
                {
                    sql = "select * from `user` where username = '" + dt.Rows[0]["userid"].ToString() + "'; ";
                    dt = new DataTable();
                    dt = cl_Sql.select(sql);
                    if (dt.Rows.Count > 0)
                    {
                        string fullname = dt.Rows[0]["userpname"].ToString() + " " + dt.Rows[0]["userfname"].ToString() + " " + dt.Rows[0]["userlname"].ToString();
                        lb7_1.Text = "<b>" + fullname + "</b>";
                    }
                }
            }

            return apstatus;
        }

        // แจ้งผู้ขอใช้ --------------------------- Level 8 ----------------------------------------------
        public string Block8()
        {
            string apstatus = "";

            //sql = "select * from approve as a where aplevel = 8 and aplevel_sub = 0 and rqsid = " + rqsid;
            dt = new DataTable();
            dt = BlockData("8", "0");
            if (dt.Rows.Count > 0)
            {
                apstatus = dt.Rows[0]["apstatus"].ToString();

                lb8_1.Text = UserActor;
                lb8_2.Text = PostActor;

                if (apstatus == "Wait")
                {
                    div8.Attributes.Add("class", "card border-left-warning shadow h-100 py-2s");
                    i8.Attributes.Add("class", "fas fa-paperclip fa-2x text-warning");

                    if (UserStatus == "admin" || UserStatus == "it")
                    {
                        bt_8.Visible = true;
                    }
                }
                else if (apstatus == "CloseJob")
                {
                    div8.Attributes.Add("class", "card border-left-success shadow h-100 py-2s");
                    i8.Attributes.Add("class", "fas fa-check fa-2x text-success");

                    lb8_3.Text = dt.Rows[0]["apdate"].ToString();
                }
                else { }
            }

            return apstatus;
        }

        // อื่นๆ/หมายเหตุ ------------------------ Level 9 ----------------------------------------------
        public string Block9()
        {
            string apstatus = "";

            sql = "select a.*, r.rqalertactor,r.rqremark from approve as a " +
                "left join requestsystems as rs on rs.rqsid = a.rqsid " +
                "left join request as r on r.rqid = rs.rqid " +
                "where(a.apstatus = 'CloseJob' or a.apstatus = 'Reject') and a.rqsid = " + rqsid;
            dt = new DataTable();
            dt = cl_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
                apstatus = dt.Rows[0]["apstatus"].ToString();

                lb9_1.Text = "";
                lb9_2.Text = "";

                if (apstatus == "CloseJob")
                {
                    lb9_1.Text = "ข้อความสำคัญ : " + dt.Rows[0]["rqalertactor"].ToString();
                    lb9_2.Text = "อื่นๆ/หมายเหตุ : " + dt.Rows[0]["rqremark"].ToString();
                    div9.Attributes.Add("class", "card border-left-success shadow h-100 py-2s");
                    i9.Attributes.Add("class", "fas fa-check fa-2x text-success");
                }
                else if (apstatus == "Reject")
                {
                    div9.Attributes.Add("class", "card border-left-danger shadow h-100 py-2s");
                    i9.Attributes.Add("class", "fas fa-times fa-2x text-danger");
                }
                else { }

                lb9_3.Text = dt.Rows[0]["apdate"].ToString();
            }

            return apstatus;
        }

        // Run All Block Line Approve ---------
        protected void RunBlock()
        {
            Block2();
            Block3();
            Block3x1();
            Block4();
            Block5();
            Block6();
            Block7();
            Block8();
            Block9();
        }

        // -------------------------------------------------------- -------------------------------------------------------- 
        // -------------------------------------------------------- --------------------------------------------------------

        // Button อนุมัติ --------------------------------------------------------
        protected void bt_1_ServerClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string BTid = btn.ID.ToString();
            string[] ArBTid = BTid.Split('_');
            string apLevel = "";

            if (txt_level.Text != "")
            {
                apLevel = txt_level.Text;
            }
            else
            {
                apLevel = ArBTid[1];
            }
            

            if (Approved(apLevel) == true)
            {
                //Response.Write("<script>alert('อนุมัติ เรียบร้อยแล้ว !!'); setTimeout(function(){window.location.href='ApproveEvent.aspx?id=" + rqsid +"'}, 10);</script>");
                Response.Write("<script>alert('อนุมัติ เรียบร้อยแล้ว !!'); setTimeout(function(){history.back()}, 10);</script>");
            }
            else
            {

            }
        }

        // Button ไม่อนุมัติ --------------------------------------------------------
        protected void bt_2_ServerClick(object sender, EventArgs e)
        {
            string apLevel = txt_level.Text;

            if (NotApprove(apLevel) == true)
            {
                Response.Write("<script>alert('ไม่อนุมัติ การร้องขอนี้ !!')</script>");
                Response.Redirect(Request.RawUrl);
            }
            else
            {

            }
        }

        // Button ยกเลิก --------------------------------------------------------
        protected void bt_3_ServerClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string BTid = btn.ID.ToString();
            string[] ArBTid = BTid.Split('_');
            string apLevel = ArBTid[1];

            if (Cancel(apLevel) == true)
            {
                Response.Write("<script>alert('ทำการยกเลิก เรียบร้อยแล้ว !!')</script>");
                Response.Redirect(Request.RawUrl);
            }
            else
            {

            }
        }


        public Boolean Approved(string level)
        {
            Boolean bl = false;
            try
            {
                string level_sub = "0";
                string oldLevel = level;

                if (oldLevel == "3x1")
                {
                    level = "3";
                }

                string Dates = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                sql = "select a.*, r.rqid, r.rqdepartment, rs.sysid, s.sysname " +
                    "\nfrom approve as a " +
                    "\nleft join requestsystems as rs on a.rqsid = rs.rqsid " +
                    "\nleft join request as r on rs.rqid = r.rqid " +
                    "\nleft join systems as s on s.sysid = rs.sysid " + 
                    "\nwhere a.apstatus = 'wait' and a.aplevel = " + level + " and a.rqsid = " + rqsid;
                dt = new DataTable();
                dt = cl_Sql.select(sql);
                if (dt.Rows.Count > 0)
                {
                    string rqid = dt.Rows[0]["rqid"].ToString();
                    string deptid = dt.Rows[0]["rqdepartment"].ToString();
                    string branch = deptid.Substring(0, 3);
                    string apid = dt.Rows[0]["apid"].ToString();
                    string sysid = dt.Rows[0]["sysid"].ToString();
                    string sysname = dt.Rows[0]["sysname"].ToString();
                    string UserRequest = dt.Rows[0]["aprequestuser"].ToString();

                    string apuserapprove1 = "0";
                    string apuserapprove2 = "0";
                    string finish = "";
                    if (level == "2")
                    {
                        apuserapprove1 = dt.Rows[0]["apuserapprove2"].ToString(); // ผู้จัดการฝ่าย 

                        if (apuserapprove1 == "0" || apuserapprove1 == "") // ถ้าไม่มี ผู้จัดการฝ่าย 
                        {
                            if (sysid == "13") // Drive O/R
                            {
                                apuserapprove1 = "150020"; //พี่วิไล ผจก.ศูนย์คุณภาพ
                                level_sub = "1";
                            }
                            else
                            {
                                apuserapprove1 = "151588"; // พี่นุช
                                level = "3";
                            }
                        }
                    }
                    else if (level == "3") //เห็นชอบโดย -- ผู้ทบทวน เห็นชอบโดย
                    {
                        apuserapprove1 = "151588"; // พี่นุช

                        if (sysid == "13") // Drive O/R
                        {
                            if (oldLevel == level)
                            {
                                apuserapprove1 = "150020"; //พี่วิไล ผจก.ศูนย์คุณภาพ
                                level = "2";
                                level_sub = "1";
                            }
                        }
                    }
                    else if (level == "4")
                    {
                        finish = "y"; 

                        if (sysid == "3") // VPN
                        {
                            apuserapprove1 = "151579"; // ส่งต่อให้ อ. พัชรี อนุมัติ
                        }
                        else
                        {
                            level = "6"; 
                            apuserapprove1 = Session["UserLogin"].ToString();
                        }

                        // ยกเลิกลำดับ ผู้บริหาร ไม่ต้องอนุมัติใด นอกจาก สายงานของ ผู้บริหาร เอง
                        //if (sysid == "1" || sysid == "6") // B-Connect || Arcus Air
                        //{
                        //    // ส่งต่อให้ ผอ. อนุมัติ เฉพาะร้องขอระบบ B-Connect และ Arcus Air (อ.จา)
                        //    apuserapprove1 = "040010"; OldID
                        //    apuserapprove2 = "548962"; NewID
                        //}
                        //else
                        //{
                        //    finish = "y"; level = "6";
                        //    apuserapprove1 = Session["UserLogin"].ToString();
                        //}
                    }
                    else if (level == "5")
                    {
                        finish = "y";
                        level = "6";
                        apuserapprove1 = Session["UserLogin"].ToString();
                    }
                    else if (level == "6")
                    {
                        if (sysid != "1") { finish = "y"; }
                        apuserapprove1 = "0";
                        apuserapprove2 = "0";
                    }
                    else if (level == "7")
                    {
                        finish = "yy";
                        apuserapprove1 = UseridActor;
                        apuserapprove2 = "0";
                    }
                    else if (level == "8")
                    {
                        finish = "yyy";
                        apuserapprove1 = "0";
                        apuserapprove2 = "0";
                    }
                    else
                    {
                        apuserapprove1 = "0";
                        apuserapprove2 = "0";
                    }

                    int levelInt = 0;
                    if (finish == "yyy") 
                    { 
                        levelInt = int.Parse(level); 
                    } 
                    else 
                    {
                        levelInt = int.Parse(level) + 1;
                    }

                    // Change empid to IT
                    if (levelInt == 7)
                    {
                        if (branch.ToUpper() == "BRD")
                        {
                            apuserapprove1 = "brd_it";
                        }
                        else
                        {
                            apuserapprove1 = "brh_it";
                        }
                    }
                    
                    string RequestID = "[" + rqid + "." + rqsid + "]";

                    string apst = "";
                    if (finish == "y") { apst = "Finish"; } else if (finish == "yy") { apst = "Acknowledge"; } else if (finish == "yyy") { apst = "CloseJob"; } else { apst = "Approved"; }

                    string apremark = "";
                    if (txt_remarkApprove.Value.ToString().Trim() != "")
                    {
                        apremark = txt_remarkApprove.Value.ToString().Trim();
                    }

                    sql = "update approve set apstatus='" + apst + "', " +
                        "\napremark = '" + apremark + "', " +
                        "\nuserid='" + UserLogin + "', " +
                        "\napdate='" + Dates + "' " +
                        "\nwhere apid = " + apid;
                    if (cl_Sql.Modify(sql) == true)
                    {
                        string StepMail = "";
                        if (finish == "y")
                        {
                            bl = true;
                            StepMail = "ToITTeam";
                        }
                        else if (finish == "yyy")
                        {
                            bl = true;
                            StepMail = "ToUserReuest";
                            apuserapprove1 = UserLogin;
                        }
                        else
                        {
                            bl = true;
                            StepMail = "ToNextLevel";
                        }

                        if (finish == "yyy") // จบกระบวนการ
                        {
                            sql = "select * from ( " +
                                        "select a.*,rs.rqid " +
                                        "from approve as a " +
                                        "left join requestsystems as rs on rs.rqsid = a.rqsid " +
                                        "where a.apstatus = 'Finish' and rs.rqid = " + rqid + " "+
                                    ") a where a.apstatus <> 'Finish'";
                            dt = new DataTable();
                            cl_Sql.select(sql);
                            if (dt.Rows.Count == 0)
                            {
                                sql = "update request set rqstatus='Finish', rqalertactor='" + txt_actor.Value.Trim() + "', rqremark='" + txt_other.Value.Trim() + "' where rqid = " + rqid;
                                dt = new DataTable();
                                cl_Sql.Modify(sql);
                            }
                        }
                        else // Insert การอนุมัติ ตามลำดับขั้น
                        {
                            sql = "insert into approve(rqsid,aplevel,aplevel_sub,userid,aprequestuser,apstatus,apuserapprove1,apuserapprove2,apdate) " +
                                    "select rqsid, " + levelInt + ", " + level_sub + ", 0, aprequestuser, 'Wait' as 'apstatus', '" + apuserapprove1 + "', '" + apuserapprove2 + "', '" + Dates + "' " +
                                    "from approve where apid = " + apid;
                            if (cl_Sql.Modify(sql) == false) { bl = false; }
                        }

                        if (bl==true)
                        {
                            bl = false;

                            sql = "Select u.*, CONCAT(u.userpname,' ',u.userfname,' ',u.userlname) as 'ApvName', " +
                                "\nCONCAT(u2.userpname,' ',u2.userfname,' ',u2.userlname) as 'ReqName', " +
                                "\nal.aplname, u2.useremail as 'Requseremail' " +
                                "\nfrom `user` as u " +
                                "\nleft join (" +
                                "\n     select *,'" + apuserapprove1 + "'  as 'Requsername' from `user` where username = '" + UseridActor + "'" +
                                "\n) as u2 on u2.Requsername = u.username " +
                                "\nleft join (" +
                                "\n     select *,'" + apuserapprove1 + "' as 'aplusername' from approvelevel " +
                                "\n     where aplgroup = 1 and apllevel = " + levelInt + " and apllevel_sub = " + level_sub + " " +
                                "\n) as al on u.username = al.aplusername " +
                                "\nwhere u.username = '" + apuserapprove1 + "'; ";
                            dt = new DataTable();
                            dt = cl_Sql.select(sql);

                            if (dt.Rows.Count > 0)
                            {
                                string emailTo = dt.Rows[0]["useremail"].ToString();
                                string ApvStep = dt.Rows[0]["aplname"].ToString();
                                string ApvName = dt.Rows[0]["ApvName"].ToString();
                                string ReqName = dt.Rows[0]["ReqName"].ToString();
                                string Requseremail = dt.Rows[0]["Requseremail"].ToString();
                                string NameTo = ApvName;
                                string emailFrom = "info.RequestSystem@brh.co.th";
                                //string ApproveDate = DateTime.Now.Date.ToString();
                                string ApproveDate = Dates;

                                string htmlBody = "<h1 style='color: #4485b8;'>Systems Request.</h1>" +
                                        "<h4 style='color: #4485b8;'>" + sysname + "</h4>" +
                                        "<p><strong style='color: #000;'> Request ID:</strong> &nbsp; " + RequestID + " </p>" +
                                        "<p><strong style='color: #000;'> Approve Date:</strong> &nbsp; " + ApproveDate + " </p>" +
                                        "<p><strong style='color: #000;'> Approve by:</strong> &nbsp; " + UserLoginName + " </p>";
                                if (StepMail== "ToNextLevel")
                                {
                                    htmlBody += "<br /><p><h4 style='color: #4485b8;'>And now.</h4></p>" +
                                        "<p><strong style='color: #000;'> Waiting step:</strong> &nbsp; " + ApvStep + " </p>" +
                                        "<p><strong style='color: #000;'> Waiting approval by:</strong> &nbsp; " + ApvName + " </p>";
                                }
                                else if (StepMail == "ToITTeam")
                                {
                                    apuserapprove1 = "0";

                                    // find Email IT by site
                                    if (branch.ToUpper() == "BRD")
                                    {
                                        emailTo = cl_Sql.EmployeeMail("brd_it");
                                    }
                                    else
                                    {
                                        emailTo = cl_Sql.EmployeeMail("brh_it"); 
                                    }

                                    htmlBody += "<p><strong style='color: #000;'> Process for :</strong> &nbsp; " + ApvStep + " </p>" +
                                        "<p><strong style='color: #000;'> By:</strong> &nbsp; IT LanSignSolution </p>";
                                }
                                else if (StepMail == "ToUserReuest")
                                {
                                    emailTo = Requseremail;
                                    NameTo = ReqName;
                                    apuserapprove1 = UserRequest;
                                    htmlBody += "<p><strong style='color: #000;'> Last Step:</strong> &nbsp; " + ApvStep + " </p>" +
                                    "<p><strong style='color: #000;'> Please check the order.</strong> </p>";
                                }
                                else
                                { }
                                htmlBody += "<p><a href='http://10.121.10.212:4001/Login?goto=ApproveEvent?id=" + rqsid + "'>Link : Access to the system.</a></p>" +
                                        "<p></p><p></p><p>Please do not reply to this email because this address is not monitored.</p>" +
                                        "<p>Automatic send by Request Systems.</p>";

                                if (Session["Test"] != null) // --------------------------- For Test -------------------------
                                {
                                    if (Session["Test"].ToString() == "Yes") { emailTo = "brh.hito@brh.co.th"; }
                                }

                                try
                                {
                                    //emailTo = "brh.hito@brh.co.th"; // Test Only

                                    BRH_SendMail.ServiceSoapClient BRHmail = new BRH_SendMail.ServiceSoapClient();
                                    BRHmail.MailSend(emailTo, "AWaiting your approval", htmlBody, emailFrom, "Systems Request", "", "", "", false);

                                    sql = "update approve set apmailto = '" + emailTo + "' where apid = '" + apid + "'; ";
                                    cl_Sql.Modify(sql);

                                    bl = true;
                                }
                                catch
                                {
                                    bl = false;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ ex.Message + "')</script>");
            }
            return bl;
        } // ลำดับการอนุมัติ

        public Boolean NotApprove(string level)
        {
            Boolean bl = false;
            try
            {
                string Dates = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string apstatus = "and apstatus = 'wait' ";
                if (level == "1")
                {
                    apstatus = "";
                }
                sql = "select * from approve where aplevel = " + level + " and rqsid = " + rqsid + " " + apstatus;
                dt = new DataTable();
                dt = cl_Sql.select(sql);
                if (dt.Rows.Count > 0)
                {
                    string remark = txt_remark.Value.ToString().Trim();
                    string apid = dt.Rows[0]["apid"].ToString();
                    rqsid = dt.Rows[0]["rqsid"].ToString();

                    sql = "update approve set apstatus='Cancel' ,userid='" + UserLogin + "' ,apremark='" + remark + "' ,apdate='" + Dates + "' where apid = " + apid + "; ";
                    if (apstatus == "")
                    {
                        sql += "\nupdate approve set apstatus='Cancel',apdate='" + Dates + "' where rqsid = '" + rqsid + "'; ";
                    }
                    if (cl_Sql.Modify(sql) == true)
                    {
                        sql = "select * from request where rqid = (select rqid from requestsystems where rqsid = " + rqsid + "); ";
                        dt = new DataTable();
                        dt = cl_Sql.select(sql);
                        if (dt.Rows.Count > 0)
                        {
                            string rqid = dt.Rows[0]["rqid"].ToString();

                            string userRequest = dt.Rows[0]["userid"].ToString();

                            sql = "select * from ( " +
                                        "select a.*,rs.rqid " +
                                        "from approve as a " +
                                        "left join requestsystems as rs on rs.rqsid = a.rqsid " +
                                        "where a.apstatus = 'Cancel' and rs.rqid = " + rqid + " " +
                                    ") a where a.apstatus <> 'Cancel' ";
                            dt = new DataTable();
                            cl_Sql.select(sql);
                            if (dt.Rows.Count == 0)
                            {
                                sql = "update request set rqstatus='Cancel' where rqid = " + rqid;
                                dt = new DataTable();
                                if (cl_Sql.Modify(sql))
                                {
                                    string emailFrom = "info.RequestSystem@brh.co.th";
                                    string emailTo = "";

                                    string SJ = "Your Systems Request is Rejected.";

                                    sql = "select * from `user` where username = '" + userRequest + "' ";
                                    dt = new DataTable();
                                    dt = cl_Sql.select(sql);
                                    if (dt.Rows.Count > 0)
                                    {
                                        emailTo = dt.Rows[0]["useremail"].ToString();
                                    }

                                    string htmlBody = "<h1 style='color: #FC390F;'>Systems Request (Rejected)</h1>" +
                                        "<h4 style='color: #FC390F;'>Systems name : " + sysname + "</h4>" +
                                        "<p><strong style='color: #000;'> Request ID:</strong> &nbsp; [" + rqid + "." + rqsid + "] </p>" +
                                        "<p><strong style='color: #000;'> Reject Date:</strong> &nbsp; " + Dates + " </p>" +
                                        "<p><strong style='color: #000;'> Reject by:</strong> &nbsp; " + UserLoginName + " </p>" +
                                        "<p><strong style='color: #000;'> Remark:</strong> &nbsp; " + remark + " </p>" +
                                        "<p><a href='http://10.121.10.212:4001/Login?goto=ApproveEvent?id=" + rqsid + "'>Link : Access to the system.</a></p>" +
                                        "<p></p><p></p><p>Please do not reply to this email because this address is not monitored.</p>" +
                                        "<p>Automatic send by Request Systems.</p>";


                                    if (Session["Test"] != null) // --------------------------- For Test -------------------------
                                    {
                                        if (Session["Test"].ToString() == "Yes") { emailTo = "brh.hito@brh.co.th"; }
                                    }

                                    try
                                    {
                                        BRH_SendMail.ServiceSoapClient BRHmail = new BRH_SendMail.ServiceSoapClient();
                                        BRHmail.MailSend(emailTo, SJ, htmlBody, emailFrom, "Systems Request", "", "", "", false);

                                        sql = "update approve set apmailto = '" + emailTo + "' where apid = '" + apid + "'; ";
                                        cl_Sql.Modify(sql);

                                        bl = true;
                                    }
                                    catch
                                    {
                                        bl = false;
                                    }
                                }
                            }
                        }
                        bl = true;
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            return bl;
        }

        public Boolean Cancel(string level)
        {
            Boolean bl = false;
            try
            {
                string Dates = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                sql = "select * from approve where apstatus = 'Cancel' and aplevel = " + level + " and rqsid = " + rqsid;
                dt = new DataTable();
                dt = cl_Sql.select(sql);
                if (dt.Rows.Count > 0)
                {
                    string apid = dt.Rows[0]["apid"].ToString();
                    sql = "update approve set apstatus='Wait', userid='" + UserLogin + "' ,apremark='คืนค่าไม่อนุมัติ' , apdate='" + Dates + "' where apid = " + apid;
                    if (cl_Sql.Modify(sql) == true)
                    {
                        bl = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
            return bl;
        }

        protected void btn_report_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReportRequest.rpt");
        }

        protected void bt_edit_Click(object sender, EventArgs e)
        {
            Response.Redirect("RequestEdit?rqid=" + rqid);
        }
    }
}