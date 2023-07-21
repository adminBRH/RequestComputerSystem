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
    public partial class Dashboard : System.Web.UI.Page
    {
        string sql = "";
        DataTable dt;
        SQLclass cl_Sql = new SQLclass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                date_start.Value = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
                date_end.Value = DateTime.Now.ToString("yyyy-MM-dd");
                Data_Chart();

                Systems();
                //Search("", "");
            }
        }

        protected void Systems()
        {
            dt = new DataTable();
            dt = cl_Sql.dt_Systems();
            if (dt.Rows.Count > 0)
            { }

            dd_systems.DataSource = dt;
            dd_systems.DataTextField = "sysname";
            dd_systems.DataValueField = "sysid";
            dd_systems.DataBind();
            dd_systems.Items.Insert(0, new ListItem("All systems", ""));
        }

        protected void Data_Chart()
        {
            string stDate = date_start.Value.ToString();
            string enDate = date_end.Value.ToString();
            string status = dd_status.SelectedValue.ToString();
            string system = dd_systems.SelectedValue.ToString();
            if (system != "")
            {
                system = "-" + system + "-";
            }

            string table = "temp_approve_maxlevel" + Session["UserID"].ToString();

            sql = "create table " + table + " ( " +
                "\nselect a.*,s.sysname,rs.rqsvalue,r.rqdateadd from approve as a " +
                "\nleft join requestsystems as rs on rs.rqsid = a.rqsid " +
                "\nleft join systems as s on s.sysid = rs.sysid " +
                "\nleft join request as r on r.rqid = rs.rqid " +
                "\nleft join(select rqsid, max(aplevel) as 'maxlevel' from approve group by rqsid) as b on b.rqsid = a.rqsid and b.maxlevel = a.aplevel " +
                "\nwhere b.rqsid is not null " +
                "\nand (convert(r.rqdateadd, date) between '" + stDate + "' and '" + enDate + "') " +
                "\nand a.apstatus like '%" + status + "%' and concat('-',s.sysid,'-') like '%" + system + "%' " +
                "\n); ";
            if (cl_Sql.Modify(sql))
            {
                Chart_Status(table);
                Chart_System(table, system);
                Chart_QtyDate(table);

                sql = "drop table " + table + "; ";
                cl_Sql.Modify(sql);

                lbl_DataDate.Text = DateTime.Parse(stDate).ToString("dd/MMM/yyyy") + " to " + DateTime.Parse(enDate).ToString("dd/MMM/yyyy");
            }
            else
            {
                Response.Write("<script>alert('ระบบขัดข้อง กรุณาติดต่อเจ้าหน้าที่ !!');</script>");
            }
        }

        protected Boolean Chart_Status(string table)
        {
            Boolean bl = false;

            string txt = "";
            string val = "";
            int total = 0;

            sql = "select apstatus,count(apid) as 'cnt' from " + table + " group by apstatus; ";
            dt = new DataTable();
            dt = cl_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (txt != "") { txt += ","; }
                    txt += dr["apstatus"];
                    if (val != "") { val += ","; }
                    val += dr["cnt"];
                    total = total + int.Parse(dr["cnt"].ToString());
                }
                bl = true;
            }

            txt_status.Value = txt;
            txt_status_value.Value = val;
            lbl_total.Text = "Total : " + total.ToString() + " request.";

            return bl;
        }
        
        protected Boolean Chart_System(string table, string system)
        {
            Boolean bl = false;

            string txt = "";
            string val = "";

            string fill = "sysname";
            if (system != "")
            {
                fill = " if(rqsvalue is null,sysname,rqsvalue)";
            }

            sql = "select " + fill + " as 'sysname',count(apid) as 'cnt' " +
                "\nfrom " + table + " group by " + fill + "; ";
            dt = new DataTable();
            dt = cl_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (txt != "") { txt += ","; }
                    txt += dr["sysname"];
                    if (val != "") { val += ","; }
                    val += dr["cnt"];
                }
                bl = true;
            }

            txt_System.Value = txt;
            txt_System_value.Value = val;

            return bl;
        }
        
        protected Boolean Chart_QtyDate(string table)
        {
            Boolean bl = false;

            string txt = "";
            string val = "";

            sql = "select convert(rqdateadd, date) as 'requestdate',count(apid) as 'cnt' from " + table + " group by convert(rqdateadd, date); ";
            dt = new DataTable();
            dt = cl_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (txt != "") { txt += ","; }
                    txt += DateTime.Parse(dr["requestdate"].ToString()).ToString("dd/MM/yyyy");
                    if (val != "") { val += ","; }
                    val += dr["cnt"];
                }
                bl = true;
            }

            txt_QtyDate.Value = txt;
            txt_QtyDate_Value.Value = val;

            return bl;
        }

        protected void dd_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            Data_Chart();
        }

        protected void dd_systems_SelectedIndexChanged(object sender, EventArgs e)
        {
            Data_Chart();
        }

        protected void btn_filter_ServerClick(object sender, EventArgs e)
        {
            Data_Chart();
        }


        protected void bt_search_Click(object sender, EventArgs e)
        {
            string Date1 = txt_D1.Value.ToString();
            string Date2 = txt_D2.Value.ToString();
            int Di1 = 0;
            int Di2 = 0;

            if (Date1 != "")
            {
                string[] Da1 = Date1.Split('/');
                Di1 = int.Parse(Da1[2] + Da1[0] + Da1[1]);
                Date1 = Da1[2] + "-" + Da1[0] + "-" + Da1[1];
            }

            if (Date2 != "")
            {
                string[] Da2 = Date2.Split('/');
                Di2 = int.Parse(Da2[2] + Da2[0] + Da2[1]);
                Date2 = Da2[2] + "-" + Da2[0] + "-" + Da2[1];
            }

            if (Di2 > 0 && Di1 > Di2)
            {
                Response.Write("<script>alert('วันที่เริ่มต้น มากกว่า วันที่สิ้นสุด ไม่ได้ !!')</script>");
            }
            else
            {
                //Search(Date1, Date2);
            }
        }

        public Boolean Search(string D1, string D2)
        {
            Boolean bl = false;

            string table = "temp_approve" + Session["UserID"].ToString();


            sql = "CREATE TABLE " + table + "( select * from brh_it_request.approve ";
            sql = sql + "where cast(apdate as date) ";
            if (D1 != "" && D2 != "")
            {
                sql = sql + "between '" + D1 + "' and '" + D2 + "' ";
            }
            else if (D1 == "" && D2 != "")
            {
                sql = sql + "<= '" + D2 + "' ";
            }
            else if (D1 != "" && D2 == "")
            {
                sql = sql + ">= '" + D1 + "' ";
            }
            else
            {
                sql = sql + "like '%' ";
            }
            sql = sql + ") ";

            if (cl_Sql.Modify(sql) == true)
            {
                sql = "select " +
                "(select count(*) as 'NewUserAll' from brh_it_request." + table + " as a where a.apstatus = 'Finish' ) as 'NewUserAll', " +
                "(select count(*) as 'NewUserM' from brh_it_request." + table + " as a where a.apstatus = 'Finish' and(month(cast(a.apdate as date)) = month(now())) ) as 'NewUserM', " +
                "(select count(*) as 'Bconnect' from brh_it_request." + table + " as a left join brh_it_request.requestsystems as rs on rs.rqsid = a.rqsid where a.apstatus = 'Finish' and rs.sysid = 1 ) as 'Bconnect', " +
                "(select count(*) as 'Email' from brh_it_request." + table + " as a left join brh_it_request.requestsystems as rs on rs.rqsid = a.rqsid where a.apstatus = 'Finish' and rs.sysid = 2 ) as 'Email', " +
                "(select count(*) as 'CancelAll' from brh_it_request." + table + " as a where a.apstatus = 'Cancel' )as 'CancelAll', " +
                "(select count(*) as 'CancelM' from brh_it_request." + table + " as a where a.apstatus = 'Cancel' and(month(cast(a.apdate as date)) = month(now())) )as 'CancelM', " +
                "(select count(*) as 'CBconnect' from brh_it_request." + table + " as a left join brh_it_request.requestsystems as rs on rs.rqsid = a.rqsid where a.apstatus = 'Cancel' and rs.sysid = 1 ) as 'CBconnect', " +
                "(select count(*) as 'CEmail' from brh_it_request." + table + " as a left join brh_it_request.requestsystems as rs on rs.rqsid = a.rqsid where a.apstatus = 'Cancel' and rs.sysid = 2 ) as 'CEmail'";
                dt = new DataTable();
                dt = cl_Sql.select(sql);
                if (dt.Rows.Count > 0)
                {
                    lblNewUserAll.Text = dt.Rows[0]["NewUserAll"].ToString();
                    lblNewUserM.Text = dt.Rows[0]["NewUserM"].ToString();
                    lblBconnect.Text = dt.Rows[0]["Bconnect"].ToString();
                    lblEmail.Text = dt.Rows[0]["Email"].ToString();

                    lblCancelAll.Text = dt.Rows[0]["CancelAll"].ToString();
                    lblCancelM.Text = dt.Rows[0]["CancelM"].ToString();
                    lblCBconnect.Text = dt.Rows[0]["CBconnect"].ToString();
                    lblCEmail.Text = dt.Rows[0]["CEmail"].ToString();
                }

                sql = "drop table " + table;
                if (cl_Sql.Modify(sql) == true)
                {
                    bl = true;
                }
            }

            return bl;
        }
    }
}