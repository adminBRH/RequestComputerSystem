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
    public partial class Report : System.Web.UI.Page
    {
        string sql = "";
        DataTable dt;
        SQLclass cl_Sql = new SQLclass();

        string rqsid = "";
        string ccsid = "";

        string formatdate = "dd/MM/yyyy";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserLogin"] == null)
            {
                Response.Redirect("Default");
            }

            cb_request.Enabled = false;
            cb_cancel.Enabled = false;

            cb_bconnect.Enabled = false;
            cb_VPN.Enabled = false;
            cb_MS.Enabled = false;
            cb_email.Enabled = false;
            cb_quota.Enabled = false;

            ro_200.Enabled = false;
            ro_500.Enabled = false;
            ro_1028.Enabled = false;

            cb_hod.Enabled = false;
            cb_staff.Enabled = false;
            cb_committee.Enabled = false;

            if (Request.QueryString["rqsid"] != null)
            {
                rqsid = Request.QueryString["rqsid"].ToString();
                QueryRequest();
            }
            if (Request.QueryString["ccsid"] != null)
            {
                ccsid = Request.QueryString["ccsid"].ToString();
                QueryCancel();
            }
        }

        public Boolean QueryRequest()
        {
            Boolean bl = false;
            sql = "select r.*,rs.rqsid,rs.rqsemail,rs.rqsquota,rs.rqsgroupmail_hod,rs.rqsgroupmail_staff,rs.rqsgroupmail_committeeother,rs.sysid,s.sysname " +
                ",a.apid,a.aplevel,a.apstatus,a.aprequestuser,concat(u.userpname, ' ', u.userfname, ' ', u.userlname) as 'UserLevel', u.userposition,a.apdate,a.apremark " +
                "    from brh_it_request.approve as a " +
                "left join brh_it_request.`user` as u on u.username = a.userid " +
                "left join brh_it_request.requestsystems as rs on rs.rqsid = a.rqsid " +
                "left join brh_it_request.request as r on r.rqid = rs.rqid " +
                "left join brh_it_request.systems as s on s.sysid = rs.sysid " +
                "where a.userid<>'0' and a.rqsid = " + rqsid + " " +
                "order by a.aplevel";
            dt = new DataTable();
            dt = cl_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
                bl = true;
                
                string request = dt.Rows[0]["rqtype"].ToString();

                string EmID = dt.Rows[0]["aprequestuser"].ToString();
                lb_EmID.Text = EmID;
                lb_fname.Text = dt.Rows[0]["rqfname"].ToString();
                lb_lname.Text = dt.Rows[0]["rqlname"].ToString();
                lb_fnameeng.Text = dt.Rows[0]["rqfnameeng"].ToString();
                lb_lnameeng.Text = dt.Rows[0]["rqlnameeng"].ToString();
                lb_post.Text = dt.Rows[0]["rqpost"].ToString();
                lb_tel.Text = dt.Rows[0]["rqphone"].ToString();
                lb_depart.Text = dt.Rows[0]["rqdepartment"].ToString();
                lb_faction.Text = dt.Rows[0]["rqfaction"].ToString();

                lb_Specailty.Text = dt.Rows[0]["rqspecailty"].ToString();
                lb_CodeCare.Text = dt.Rows[0]["rqcodecare"].ToString();
                lb_Location.Text = dt.Rows[0]["rqlocation"].ToString();

                lb_ID.Text = "เลขที่ : [" + dt.Rows[0]["rqid"].ToString() + "] (" + dt.Rows[0]["rqsid"].ToString() + "." + dt.Rows[0]["apid"].ToString() + ")";
                lb_date.Text = "Print date : " + DateTime.Now.ToString();

                string sysid = dt.Rows[0]["sysid"].ToString();

                if (request == "Request") { cb_request.Checked = true; }

                if (sysid == "1") { cb_bconnect.Checked = true; }
                if (sysid == "3") { cb_VPN.Checked = true; }
                if (sysid == "4") { cb_MS.Checked = true; }
                if (sysid == "2")
                {
                    cb_email.Checked = true;
                    lb_email.Text = dt.Rows[0]["rqsemail"].ToString();

                    string quota = dt.Rows[0]["rqsquota"].ToString();
                    if (quota == "200") { ro_200.Checked = true; }
                    if (quota == "500") { ro_500.Checked = true; }
                    if (quota == "1028") { ro_1028.Checked = true; }

                    foreach (DataRow dtr in dt.Rows)
                    {
                        if (dtr["rqsgroupmail_hod"].ToString() != "") { cb_hod.Checked = true; }
                        if (dtr["rqsgroupmail_staff"].ToString() != "") { cb_staff.Checked = true; }
                        if (dtr["rqsgroupmail_committeeother"].ToString() != "") { cb_committee.Checked = true; lb_committee.Text = dtr["rqsgroupmail_committeeother"].ToString(); }
                    }
                }

                string actor = "";
                string actorpos = "";

                foreach (DataRow dtr in dt.Rows)
                {
                    if (dtr["aplevel"].ToString() == "1")
                    {
                        lb_lv1.Text = dtr["UserLevel"].ToString();
                        actor = dtr["UserLevel"].ToString();
                        lb_pos1.Text = dtr["userposition"].ToString();
                        actorpos = dtr["userposition"].ToString();
                        lb_date1.Text = DateTime.Parse(dtr["apdate"].ToString()).ToString(formatdate);
                    }
                    if (dtr["aplevel"].ToString() == "2")
                    {
                        lb_lv2.Text = dtr["UserLevel"].ToString();
                        lb_pos2.Text = dtr["userposition"].ToString();
                        lb_date2.Text = DateTime.Parse(dtr["apdate"].ToString()).ToString(formatdate);
                    }
                    if (dtr["aplevel"].ToString() == "3")
                    {
                        lb_lv3.Text = dtr["UserLevel"].ToString();
                        lb_pos3.Text = dtr["userposition"].ToString();
                        lb_date3.Text = DateTime.Parse(dtr["apdate"].ToString()).ToString(formatdate);
                    }
                    if (dtr["aplevel"].ToString() == "4")
                    {
                        if (dtr["apstatus"].ToString() != "Cancel") { ck4_1.Visible = true; } else { ck4_2.Visible = true; }
                        lb_lv4.Text = dtr["UserLevel"].ToString();
                        lb_pos4.Text = dtr["userposition"].ToString();
                        lb_remark4.Text = "หมายเหตุ: " + dtr["apremark"].ToString();
                        lb_date4.Text = DateTime.Parse(dtr["apdate"].ToString()).ToString(formatdate);
                    }
                    if (dtr["aplevel"].ToString() == "5")
                    {
                        if (dtr["apstatus"].ToString() != "Cancel") { ck5_1.Visible = true; } else { ck5_2.Visible = true; }
                        lb_lv5.Text = dtr["UserLevel"].ToString();
                        lb_pos5.Text = dtr["userposition"].ToString();
                        lb_date5.Text = DateTime.Parse(dtr["apdate"].ToString()).ToString(formatdate);
                    }
                    if (dtr["aplevel"].ToString() == "6")
                    {
                        if (dtr["apstatus"].ToString() != "Cancel") { ck6_1.Visible = true; } else { ck6_2.Visible = true; }
                        lb_lv6.Text = dtr["UserLevel"].ToString();
                        lb_pos6.Text = dtr["userposition"].ToString();
                        lb_date6.Text = DateTime.Parse(dtr["apdate"].ToString()).ToString(formatdate);
                    }
                    if (dtr["aplevel"].ToString() == "7")
                    {
                        //lb_lv7.Text = "BRH IT GROUP";
                        lb_lv7.Text = dtr["UserLevel"].ToString();
                        //lb_pos7.Text = "IT GLS";
                        lb_pos7.Text = dtr["userposition"].ToString();
                        lb_date7.Text = DateTime.Parse(dtr["apdate"].ToString()).ToString(formatdate);
                    }
                    if (dtr["aplevel"].ToString() == "8")
                    {
                        lb_lv8.Text = actor;
                        lb_pos8.Text = actorpos;
                        lb_date8.Text = DateTime.Parse(dtr["apdate"].ToString()).ToString(formatdate);

                        if (dtr["apremark"].ToString() != "")
                        {
                            lb_remarkactor.Text = dtr["UserLevel"].ToString();
                            lb_remark.Text = dtr["apremark"].ToString();
                            lb_dateremark.Text = DateTime.Parse(dtr["apdate"].ToString()).ToString(formatdate);
                        }
                    }
                }
            }

            return bl;
        }

        public Boolean QueryCancel()
        {
            Boolean bl = false;

            return bl;
        }
    }
}