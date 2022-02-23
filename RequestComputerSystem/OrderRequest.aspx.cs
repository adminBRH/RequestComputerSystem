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
    public partial class OrderRequest : System.Web.UI.Page
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

            if (!IsPostBack)
            {
                department();
                Searchhod2();
            }
        }

        public Boolean department()
        {
            Boolean result = false;

            sql = "SELECT * FROM (Select '0' as 'deptOrderby','' as 'deptid','เลือกแผนก' as 'deptname' union Select '1' as 'deptOrderby',deptid,deptname from brh_it_request.department where depthod1 is not null) as a order by deptOrderby,deptname ";
            dt = new DataTable();
            dt = CL_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
                dl_department.DataSource = dt;
                dl_department.DataTextField = "deptname";
                dl_department.DataValueField = "deptid";
                dl_department.DataBind();

                result = true;
            }

            return result;
        }

        public string check_object() //การส่งค่าเป็นสตริงในรูปแบบ Checklist
        {
            string result = "";
            if (rd_ecnomic.Checked){
                result = rd_ecnomic.Value.ToString();               
            } else if (rd_annual.Checked) 
            {
                result = rd_annual.Value.ToString();
            } else if (rd_newdept.Checked)
            {
                result = rd_newdept.Value.ToString();
            } else if (re_newpro.Checked) 
            {
                result = re_newpro.Value.ToString();
            } else if (re_newwork.Checked)
            {
                result = re_newwork.Value.ToString();
            } else if (re_other.Checked)
            {
                result = re_other.Value.ToString();
            }

            return result;
        }

        public string check_detail()
        {
            string result = "";
            if (re_setup.Checked)
            {
                result = re_setup.Value.ToString();
            } else if (re_delete.Checked)
            {
                result = re_delete.Value.ToString();
            } else if (re_pricedown.Checked)
            {
                result = re_pricedown.Value.ToString();
            } else if (re_priceup.Checked)
            {
                result = re_priceup.Value.ToString();
            }
            return result;
            


        }

        protected void dl_department_SelectedIndexChanged(object sender, EventArgs e)
        {
            Searchhod2();
        }

        public string Searchhod2()
        {
            String result = "";

            sql = "SELECT * FROM brh_it_request.department WHERE deptid='" + dl_department.SelectedValue + "' ";
            dt = new DataTable();
            dt = CL_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
                string hod1 = dt.Rows[0]["depthod1"].ToString();
                string hod2 = dt.Rows[0]["depthod2"].ToString();

                result = hod1;

                sql = "select *,concat(userpname,' ',userfname,' ',userlname) as 'fullname'  from `user` where username = '" + result + "' ";
                dt = new DataTable();
                dt = CL_Sql.select(sql);
                if (dt.Rows.Count > 0)
                {
                    lbl_HOD1.Text = "หัวหน้าแผนก : " + dt.Rows[0]["fullname"].ToString();
                }

                result = hod2;

                if (result == "")
                {
                    lbl_HOD2.Text = "";
                    result = "-";
                }
                else
                {
                    sql = "select *,concat(userpname,' ',userfname,' ',userlname) as 'fullname'  from `user` where username = '" + result + "' ";
                    dt = new DataTable();
                    dt = CL_Sql.select(sql);
                    if (dt.Rows.Count > 0)
                    {
                        lbl_HOD2.Text = "หัวหน้าฝ่าย : " + dt.Rows[0]["fullname"].ToString();
                    }
                }
            }
            else
            {
                lbl_HOD2.Text = "";
            }

            return result;
        }

        protected void btnsubmit_ServerClick(object sender, EventArgs e)
        {
            if (Insertdata())
            {
                Response.Write("<script>alert('บันทึกสำเร็จ'); window.location.href='OrderRequestList.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('ไม่สามารถบันทึกได้กรุณาติดต่อ Admin');</script>");
            }
        }

        public Boolean Insertdata() // การเพิ่มข้อมูลเข้า Database
        {
            Boolean result = false;

            string UpdatePrice = "yes";

            string objects = check_object();
            string other = txt_other.Value.ToString().Trim();
            string detail = check_detail();
            string details = txt_details.Value.ToString();
            string Approvelevel1 = Searchhod2();
            string Approvelevel2 = "";
            string AppIDmail = Approvelevel1;
            string level = "1";
            if (Approvelevel1 == "-")
            {
                if (UpdatePrice == "yes") // ขอปรับราคา
                {
                    Approvelevel2 = "100384"; // <----------------- ผู้จัดการฝ่ายบัญชี
                    level = "3";
                } else {
                    Approvelevel2 = "150216"; // <---------------------- คณะกรรมการ Costing
                    level = "2";
                }
                AppIDmail = Approvelevel2;
            }

            string Dept = dl_department.SelectedValue.ToString();

            sql = "INSERT INTO changeorder" +
            "(`date`, deptid, status, empid, Approvelevel1, Approvelevel2, Approvelevel3, Approvelevel4, Approvelevel5, Approvelevel6, detailorder, objective, Approvelv, Other, Details)" +
            "VALUES(CURRENT_TIMESTAMP, '" + Dept + "', 'Waiting', '" + Session["UserLogin"].ToString() + "', '" + Approvelevel1 + "', '" + Approvelevel2 + "', '', '', '', '', '" + detail + "' , '" + objects + "', '" + level + "', '" + other + "', '" + details + "');";
            if (CL_Sql.Modify(sql))
            {
                string rqid = CL_Sql.LastID("rqid", "changeorder");
                if (rqid != "")
                {
                    UploadFile(rqid);
                    if (SendMail(rqid, AppIDmail))
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        public Boolean UploadFile(string id)
        {
            Boolean bl = false;

            if (FileUpload1.HasFile)
            {
                string Path = "~/FileUpload/OrderRequest/";
                string FileName = "";
                foreach (HttpPostedFile uploadFile in FileUpload1.PostedFiles)
                {
                    FileName = uploadFile.FileName;
                    string[] exts = FileName.ToString().Split('.');
                    int ml = exts.Length;
                    string name = "";
                    for (int i = 0; i < (ml - 1); i++)
                    {
                        if (name != "")
                        {
                            name = name + ".";
                        }
                        name = name + exts[i].ToString().Replace("&", "And");
                    }
                    FileName = name + ",id" + id + "." + exts[ml-1].ToString();
                    uploadFile.SaveAs(System.IO.Path.Combine(Server.MapPath(Path), FileName));
                    bl = true;
                }
            }
            return bl;
        }

        public Boolean SendMail(string id, string apvid)
        {
            Boolean bl = true;

            string emailTo = "";
            string emailFrom = "info.RequestSystem@brh.co.th";

            sql = "select * from `user` where username = '" + apvid + "' ";
            dt = new DataTable();
            dt = CL_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
                emailTo = dt.Rows[0]["useremail"].ToString();

                string htmlBody = "<h1 style='color: #4485b8;'>Change Order Items.</h1>" +
                                "<p><strong style='color: #000;'> ID:</strong> &nbsp; " + id + " </p>" +
                                "<p><strong style='color: #000;'> Waiting you approve</strong></p>" +
                                "<p><a href='http://10.121.10.212:4001/Login?goto=OrderRequestApprove?id=" + id + "'>Link : Access to the system.</a></p>" +
                                "<p></p><p></p><p>Please do not reply to this email because this address is not monitored.</p>" +
                                "<p>Automatic send by Request Systems.</p>";

                if (Session["Test"] != null)
                {
                    if (Session["Test"].ToString() == "Yes") { emailTo = "brh.hito@brh.co.th"; }
                }

                if (emailTo != "")
                {
                    BRH_SendMail.ServiceSoapClient BRHmail = new BRH_SendMail.ServiceSoapClient();
                    BRHmail.MailSend(emailTo, "Change Order Items", htmlBody, emailFrom, "Systems Request", "", "", "", false);

                    sql = "update changeorder set emailTo = '" + emailTo + "', emailDate = CURRENT_TIMESTAMP where rqid = '" + id + "' ";
                    if (CL_Sql.Modify(sql))
                    {
                        bl = true;
                    }
                }
            }

            return bl;
        }
    }
}