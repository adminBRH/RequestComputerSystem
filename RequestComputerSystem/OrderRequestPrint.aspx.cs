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
    public partial class OrderRequestPrint : System.Web.UI.Page
    {
        string sql = "";
        DataTable dt;
        DataTable dt2;
        SQLclass CL_Sql = new SQLclass();

        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            if (Permission(id))
            {
                SelectData(id);
            }
            else
            {
                Response.Redirect("OrderRequestList.aspx");
            }
        }

        public Boolean Permission(string id)
        {
            Boolean bl = false;

            if (Session["UserStatus"].ToString() == "admin")
            {
                bl = true;
            }
            else
            {
                sql = "select * from changeorder where rqid = '" + id + "' ";
                dt = new DataTable();
                dt = CL_Sql.select(sql);
                if (dt.Rows.Count > 0)
                {
                    string level = dt.Rows[0]["Approvelv"].ToString();
                    sql = "select * from changeorder where rqid = '" + id + "' and Approvelevel" + level + " = '" + Session["UserLogin"].ToString() + "' ";
                    dt = new DataTable();
                    dt = CL_Sql.select(sql);
                    if (dt.Rows.Count > 0)
                    {
                        bl = true;
                    }
                }
            }

            return bl;
        }

        public Boolean SelectData(string id)
        {
            Boolean bl = false;

            sql = "select * from changeorder where rqid = '" + id + "' ";
            dt = new DataTable();
            dt = CL_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
                string DateCreate = DateTime.Parse(dt.Rows[0]["date"].ToString()).ToString("...dd/MM/yyyy...");
                string Dept = Department(dt.Rows[0]["deptid"].ToString());
                string empname = EmpName(dt.Rows[0]["empid"].ToString());

                lbl_date1.Text = DateCreate;
                lbl_date2.Text = DateCreate + "........";
                lbl_dept.Text = Dept;
                lbl_empname1.Text = empname;
                lbl_empname2.Text = "..." + empname + ".....";

                string OBJ = dt.Rows[0]["objective"].ToString();
                switch (OBJ)
                {
                    case "Economic Condition":
                        RD_obj1.Checked = true;
                        break;
                    case "Annual Reviews":
                        RD_obj2.Checked = true;
                        break;
                    case "New Department":
                        RD_obj3.Checked = true;
                        break;
                    case "New Product":
                        RD_obj4.Checked = true;
                        break;
                    case "New Wrok Flow":
                        RD_obj5.Checked = true;
                        break;
                    case "Other":
                        RD_obj6.Checked = true;
                        lbl_other.Visible = true;
                        lbl_other.Text = dt.Rows[0]["Other"].ToString();
                        break;
                    default:
                        break;
                }

                string Detail = dt.Rows[0]["detailorder"].ToString();
                switch (Detail)
                {
                    case "Set up New Item":
                        RD_dt1.Checked = true;
                        break;
                    case "Delete Order Items":
                        RD_dt2.Checked = true;
                        break;
                    case "ปรับลดราคา Order Items":
                        RD_dt3.Checked = true;
                        break;
                    case "ปรับเพิ่มราคา Order Items":
                        RD_dt4.Checked = true;
                        break;
                    default:
                        break;
                }

                string Details = dt.Rows[0]["Details"].ToString();
                lbl_Details.Text = Details.Replace("\n","<br />");
            }

            return bl;
        }

        public string Department(string id)
        {
            string result = "";

            sql = "select * from department where deptid = '" + id + "' ";
            dt2 = new DataTable();
            dt2 = CL_Sql.select(sql);
            if (dt2.Rows.Count > 0)
            {
                result = dt2.Rows[0]["deptname"].ToString();
            }

            return result;
        }

        public string EmpName(string id)
        {
            string result = "";

            sql = "select concat(userpname,' ',userfname,' ',userlname) as 'fullname' from `user` where username = '" + id + "' ";
            dt2 = new DataTable();
            dt2 = CL_Sql.select(sql);
            if (dt2.Rows.Count > 0)
            {
                result = dt2.Rows[0]["fullname"].ToString();
            }

            return result;
        }
    }
}