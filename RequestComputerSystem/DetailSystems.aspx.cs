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
    public partial class DetailSystems : System.Web.UI.Page
    {
        string sql = "";
        DataTable dt;
        SQLclass cl_Sql = new SQLclass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["apid"] != null)
            {
                string apid = Request.QueryString["apid"].ToString();
                sql = "select a.*,al.aplname,r.rqid,rs.sysid,s.sysname,rs.rqsemail,rs.rqsquota,rs.rqsgroupmail_hod,rs.rqsgroupmail_staff,rs.rqsgroupmail_committeeother " +
                    ",concat(r.rqpname,' ',r.rqfname, ' ',r.rqlname) as 'UserReqName',d.deptname " +
                    ",concat(u2.userpname,' ',u2.userfname,' ',u2.userlname) as 'userCreate',u2.userposition as 'userCreateposition' " +
                    ",r.rqcodecare ,r.rqlocation ,r.rqspecailty " +
                    "from brh_it_request.approve as a " +
                    "left join brh_it_request.approvelevel as al on al.apllevel=a.aplevel " +
                    "left join brh_it_request.requestsystems as rs on a.rqsid = rs.rqsid " +
                    "left join brh_it_request.request as r on r.rqid = rs.rqid " +
                    "left join brh_it_request.systems as s on rs.sysid = s.sysid " +
                    "left join brh_it_request.department as d on d.deptid = r.rqdepartment " +
                    "left join brh_it_request.`user` as u2 on a.userid=u2.username " +
                    "where apid = " + apid;
                dt = new DataTable();
                dt = cl_Sql.select(sql);
                if (dt.Rows.Count > 0)
                {
                    txt_rqsid.Text = dt.Rows[0]["rqsid"].ToString();
                    if (dt.Rows[0]["aplevel"].ToString() == "2")
                    {
                        btn_edit.Visible = true;
                        txt_rqid.Text = dt.Rows[0]["rqid"].ToString();
                    }

                    lbl_systems.Text = "<b>ระบบที่ร้องขอ : </b>" + dt.Rows[0]["sysname"].ToString();

                    if (dt.Rows[0]["sysid"].ToString() == "2")
                    {
                        div_email.Visible = true;
                        lbl_email.Text = dt.Rows[0]["rqsemail"].ToString();
                        lbl_quota.Text = "<b>Quota : </b>" + dt.Rows[0]["rqsquota"].ToString() + " MB";

                        lbl_Groupmail.Text = "<b>Group Mail : </b>";
                        if (dt.Rows[0]["rqsgroupmail_hod"].ToString() != "") 
                        {
                            div_hod.Visible = true;
                            lbl_hod.Text = dt.Rows[0]["rqsgroupmail_hod"].ToString();
                        }
                        if (dt.Rows[0]["rqsgroupmail_staff"].ToString() != "")
                        {
                            div_staff.Visible = true;
                            lbl_staff.Text = dt.Rows[0]["rqsgroupmail_staff"].ToString();
                        }
                        if (dt.Rows[0]["rqsgroupmail_committeeother"].ToString() != "")
                        {
                            div_committee.Visible = true;
                            lbl_committee.Text = dt.Rows[0]["rqsgroupmail_committeeother"].ToString();
                        }
                    }

                    lbl_userreq.Text = "<b>ผู้ใช้งานระบบ : </b>" + dt.Rows[0]["UserReqName"].ToString();
                    lbl_userid.Text = "<b>รหัสพนักงาน : </b>" + dt.Rows[0]["aprequestuser"].ToString();
                    lbl_post.Text = "<b>ตำแหน่ง : </b>" + dt.Rows[0]["deptname"].ToString();
                    lbl_spec.Text = "<b>Specailty : </b>" + dt.Rows[0]["rqspecailty"].ToString();
                    lbl_care.Text = "<b>Code Care : </b>" + dt.Rows[0]["rqcodecare"].ToString();
                    lbl_lo.Text = "<b>Location : </b>" + dt.Rows[0]["rqlocation"].ToString();

                    lbl_status.Text = "<b>This Status : </b>" + dt.Rows[0]["aplname"].ToString();
                    lbl_by.Text = "<b>By : </b>" + dt.Rows[0]["userCreate"].ToString();
                    lbl_bypost.Text = "<b>ตำแหน่ง : </b>" + dt.Rows[0]["userCreateposition"].ToString();
                    lbl_datetime.Text = "<b>" + dt.Rows[0]["apdate"].ToString() + "</b>";


                    sql = "select a.aplevel,a.apstatus,al.aplname,a.apdate,concat(u.userpname,' ',u.userfname,' ',u.userlname) as 'LastUserName',u.userposition as 'Lastuserposition', a.apremark " +
                        "from brh_it_request.approve as a " +
                        "left join brh_it_request.approvelevel as al on al.apllevel=a.aplevel " +
                        "left join brh_it_request.`user` as u on if (a.userid='0',a.apuserapprove1,a.userid)= u.username " +
                        "where a.rqsid = " + dt.Rows[0]["rqsid"].ToString() + " " +
                        "order by a.aplevel desc";
                    dt = new DataTable();
                    dt = cl_Sql.select(sql);
                    if (dt.Rows.Count > 0)
                    {
                        string LastUserName = "";
                        string Lastuserposition = "";
                        if (dt.Rows[0]["aplevel"].ToString() == "7")
                        {
                            LastUserName = "BRH IT GROUP";
                            Lastuserposition = "";
                        }
                        else
                        {
                            LastUserName = dt.Rows[0]["LastUserName"].ToString();
                            Lastuserposition = dt.Rows[0]["Lastuserposition"].ToString();
                        }

                        div_laststatus.Visible = true;
                        lbl_lastStatus.Text = "<b>Last Status : </b>" + dt.Rows[0]["apstatus"].ToString();
                        lbl_lastaction.Text = dt.Rows[0]["aplname"].ToString();
                        lbl_lastby.Text = "<b>By : </b>" + LastUserName;
                        lbl_lastbypost.Text = "<b>ตำแหน่ง : </b>" + Lastuserposition;
                        lbl_lastdatetime.Text = "<b>" + dt.Rows[0]["apdate"].ToString() + "</b>";
                        if (dt.Rows[0]["apstatus"].ToString() == "Wait") { lbl_lastdatetime.Visible = false; }
                        string apremark = dt.Rows[0]["apremark"].ToString();
                        lbl_lastremark.Text = "<b>หมายเหตุ : </b>" + apremark;
                        if (apremark == "" || apremark == null) { lbl_lastremark.Visible = false; }
                    }
                }
            }
        }

        protected void btn_edit_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("RequestEdit.aspx?rqid=" + txt_rqid.Text);
        }
    }
}