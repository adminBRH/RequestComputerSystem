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
    public partial class PayOvertimeDetail : System.Web.UI.Page
    {
        string sql = "";
        DataTable dt;
        DataTable dt2;
        SQLclass CL_Sql = new SQLclass();

        string status = "";
        string ptid = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                ptid = Request.QueryString["id"].ToString();

                if (!IsPostBack) //อิสโพสแบล็กคือ ให้มันทำอีเว้นครั้งเดียวเช่นเรียกชาแสดง1ครั้ง                                                                                                                                                                                0ในมอดอลเวลากดอัพเดทจะไม่เรียกมาใช้
                {
                    SelectRemark(ptid);
                }
            }
            else
            {
                Response.Redirect("PayOvertimeList.aspx");
            }
           
            
        }

        public string SelectRemark(string id)
        {
            string result = "";

            // --------------------------------------------- Show File Upload --------------------

            //string Path = "~/FileUploadPay/FilePayOvertime/";
            string Path = "FileUploadPay/FilePayOvertime/";
            string FileLink = "";
            string FileName = "";
            DirectoryInfo myDirInfo;
            myDirInfo = new DirectoryInfo(Server.MapPath(Path));
            FileInfo[] arrFileInfo = myDirInfo.GetFiles("*,id" + id + "*");
            foreach (FileInfo myFileInfo in arrFileInfo)
            {
                string[] FNs = myFileInfo.Name.Split('.');
                string[] FN = FNs[0].ToString().Split(',');
                FileName = "- " + FN[0] + "." + FNs[1];
                FileLink = FileLink + ("<br><a href='" + Path + myFileInfo.Name + "' >" + FileName + "</a>");
            }
            fileshow.Text = FileLink;
            // --------------------------------------------- Show File Upload --------------------

            //sql = "select * from payovertime where pt_id = '" + detail_use + "' ";


            sql = "SELECT p.*,d.deptname,CONCAT(u.userpname, ' ', u.userfname, ' ', u.userlname) as 'username', " +
                    "CONCAT(h.userpname, ' ', h.userfname, ' ', h.userlname) as 'hodname' , " +
                    "CONCAT(hr.userpname, ' ', hr.userfname, ' ', hr.userlname) as 'hrname' " +
                    "FROM brh_it_request.payovertime as p " +
                    "LEFT JOIN department as d on d.deptid = p.dept_id " +
                    "LEFT JOIN `user` as u on u.username = p.user_id " +
                    "LEFT JOIN `user` as h on h.username = p.hod_id " +
                    "LEFT JOIN `user` as hr on hr.username = p.hr_id " +
                    "WHERE (p.pt_id = '" + id + "');";



            dt = new DataTable();
            dt = CL_Sql.select(sql);

            if (dt.Rows.Count > 0)
            {
                lbl_id.Text = id;
                username1.Text = dt.Rows[0]["username"].ToString();
                pttime.Text = DateTime.Parse(dt.Rows[0]["pt_time"].ToString()).ToString("dd/MM/yyyy HH:mm:ss");
                hod_name1.Text = dt.Rows[0]["hodname"].ToString();

                string hod_status = dt.Rows[0]["hod_status"].ToString();
                if (hod_status == "wait")
                {
                    hodstatus.CssClass = "badge badge-warning";
                }
                else if (hod_status == "reject")
                {
                    hodstatus.CssClass = "badge badge-danger";
                }
                else if (hod_status == "finish")
                {
                    hodstatus.CssClass = "badge badge-success";
                }
                else
                {
                    hodstatus.CssClass = "";
                }
                hodstatus.Text = hod_status;

                hrname1.Text = dt.Rows[0]["hrname"].ToString(); 
                
                string hr_status = dt.Rows[0]["hr_status"].ToString();
                if (hr_status == "wait")
                {
                    hrstatus.CssClass = "badge badge-warning";
                }
                else if (hr_status == "reject")
                {
                    hrstatus.CssClass = "badge badge-danger";
                }
                else if (hr_status == "finish")
                {
                    hrstatus.CssClass = "badge badge-success";
                }
                else
                {
                    hrstatus.CssClass = "";
                }
                hrstatus.Text = hr_status;

                hodremark.Text = dt.Rows[0]["hod_remark"].ToString();
                hrremark.Text = dt.Rows[0]["hr_remark"].ToString();
                reqdate.Text = DateTime.Parse(dt.Rows[0]["date_request"].ToString()).ToString("MM");
            }

            return result;
        }

    }
}