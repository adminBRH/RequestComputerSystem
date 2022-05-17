using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

public class DisbursementClass
{
    string sql = "";
    DataTable dt;
    SQLclass cl_Sql = new SQLclass();

    public Boolean approval(string id, string type, string deptid)
    {
        Boolean bl = false;

        sql = "select * from department where deptid = '" + deptid + "' ";
        dt = new DataTable();
        dt = cl_Sql.select(sql);
        if (dt.Rows.Count > 0)
        {
            string hod1 = dt.Rows[0]["depthod1"].ToString();
            string hod2 = dt.Rows[0]["depthod2"].ToString();

            sql = "insert into disbursement_approve(da_type ,da_crid " +
                ",da_level1 ,da_datetime1 ,da_status1 ,da_level2 " +
                ",da_level3, da_level4, da_level5, da_level6, da_level7, da_level) " +
                "values('" + type + "','" + id + "'" +
                ",'" + hod1 + "',CURRENT_TIMESTAMP,'waiting','" + hod2 + "' ";

            string sql2 = "select * from disbursement_level where dr_type = '" + type + "' and dr_active = 'yes' order by dr_level ";
            DataTable dt2 = new DataTable();
            dt2 = cl_Sql.select(sql2);
            if (dt2.Rows.Count > 0)
            {
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    sql = sql + ",'" + dt2.Rows[i]["dr_empid"].ToString() + "' ";
                }
            }

            sql = sql + ",'1'); ";

            if (cl_Sql.Modify(sql))
            {
                bl = true;
            }
        }

        return bl;
    }

    public string Bypass(string level ,string type)
    {
        string result = "waiting";

        sql = "select * from disbursement_level where dr_empid = '-' and dr_type = '" + type + "' and dr_level = '" + level + "' ";
        dt = new DataTable();
        dt = cl_Sql.select(sql);
        if (dt.Rows.Count > 0)
        {
            result = "bypass";
        }

        return result;
    }

    public string ApprovedReject(string type, string id, string evn, string level, string remark)
    {
        string result = "";
        string bypass = "";
        while (result == "")
        {
            string NextLevel = "";
            string nextemp = "da_level1";
            string levelStatus = "";
            string levelNext = "";

            int MaxLevel = 7;

            string levelup = level;

            if (evn == "approve" && int.Parse(level) < MaxLevel)
            {
                levelNext = (int.Parse(level) + 1).ToString();
                levelStatus = Bypass(levelNext, type);
                bypass = levelStatus;
                if (bypass == "bypass")
                {
                    string loopNext = "yes";
                    while (loopNext == "yes")
                    {
                        levelNext = (int.Parse(levelNext) + 1).ToString();
                        levelStatus = Bypass(levelNext, type);
                        if (levelStatus != "bypass")
                        {
                            levelNext = (int.Parse(levelNext) - 1).ToString();
                            break;
                        }
                    }
                }
                nextemp = "da_level" + levelNext;
                NextLevel = ",da_status" + levelNext + " = '" + bypass + "' ";
                if (bypass == "bypass")
                {
                    NextLevel = NextLevel + ",da_status" + (int.Parse(levelNext) + 1).ToString() + " = 'waiting' ";
                }

            }

            if (int.Parse(level) <= MaxLevel)
            {
                levelup = levelNext;
            }

            if (bypass == "bypass") { levelup = (int.Parse(levelup) + 1).ToString(); }

            sql = "update disbursement_approve set da_datetime" + level + " = CURRENT_TIMESTAMP, da_status" + level + " = '" + evn + "', da_level = '" + levelup + "', da_remark" + level + " = '" + remark + "' " +
                NextLevel +
                "where da_crid = '" + id + "' and da_type = '" + type + "'; ";
            if (cl_Sql.Modify(sql))
            {
                string next = "yes";
                if (evn == "reject")
                {
                    next = "";
                    sql = "update disbursement_request set dr_status = '" + evn + "' where dr_id = '" + id + "' ";
                    if (cl_Sql.Modify(sql))
                    {
                        next = "yes";
                    }
                }

                string LA = LastApprove(type);
                if (LA == level)
                {
                    sql = "update disbursement_request set dr_status = '" + evn + "' where dr_id = '" + id + "' ";
                    cl_Sql.Modify(sql);
                }

                if (next == "yes")
                {
                    sql = "select * from disbursement_approve where da_crid = '" + id + "'";
                    dt = new DataTable();
                    dt = cl_Sql.select(sql);
                    if (dt.Rows.Count > 0)
                    {
                        if (bypass == "bypass")
                        {
                            nextemp = "da_level" + (int.Parse(levelNext) + 1).ToString();
                        }
                        nextemp = dt.Rows[0][nextemp].ToString();
                        if (nextemp == "")
                        {
                            sql = "update disbursement_approve set da_level" + levelup + "='-', da_status" + levelup + " = 'bypass' " +
                                "where da_crid = '" + id + "' ";
                            if (cl_Sql.Modify(sql))
                            {
                                bypass = "bypass";
                            }
                        }
                        result = nextemp;
                    }
                }
            }
            level = levelup;
            if (result != "")
            {
                break;
            }
        }
        return result;
    }

    public string LastApprove(string type)
    {
        string result = "";

        sql = "select MAX(dr_level) as 'last_level' from disbursement_level where dr_type = '" + type + "' ";
        dt = new DataTable();
        dt = cl_Sql.select(sql);
        if (dt.Rows.Count > 0)
        {
            result = dt.Rows[0]["last_level"].ToString();
        }

        return result;
    }

    public string CRID(string empid, string status)
    {
        string result = "";

        sql = "select da_crid from disbursement_approve where " +
            "\n(da_level1 = '" + empid + "' and da_status1 like '%" + status + "%' " +
            "\nor da_level2 = '" + empid + "' and da_status2 like '%" + status + "%' " +
            "\nor da_level3 = '" + empid + "' and da_status3 like '%" + status + "%' " +
            "\nor da_level4 = '" + empid + "' and da_status4 like '%" + status + "%' " +
            "\nor da_level5 = '" + empid + "' and da_status5 like '%" + status + "%' " +
            "\nor da_level6 = '" + empid + "' and da_status6 like '%" + status + "%' " +
            "\nor da_level7 = '" + empid + "' and da_status7 like '%" + status + "%' ) ";

        if (status != "waiting") // != Wait me
        {
            sql += "\nunion select dr_id as 'da_crid' from disbursement_request where dr_empid = '" + empid + "' and dr_status like '%" + status + "%' ";
        }
        dt = new DataTable();
        dt = cl_Sql.select(sql);
        if (dt.Rows.Count > 0)
        {
            for (int i=0; i<dt.Rows.Count; i++)
            {
                if (result != "")
                {
                    result = result + ",";
                }
                result = result + "'" + dt.Rows[i]["da_crid"].ToString() + "'";
            }
        }
        else
        {
            result = "''";
        }

        return result;
    }

    public Boolean SendMail(string drid,string emailTo, string subject, string htmlBody)
    {
        Boolean bl = false;

        try
        {
            //emailTo = "brh.hito@brh.co.th"; // ------- for test
            sql = "update disbursement_request set dr_sentto='" + emailTo + "' where dr_id = '" + drid + "' ";
            if (cl_Sql.Modify(sql))
            {
                RequestComputerSystem.BRH_SendMail.ServiceSoapClient BRHSendMail = new RequestComputerSystem.BRH_SendMail.ServiceSoapClient();
                BRHSendMail.MailSend(emailTo, subject, htmlBody, "info.RequestSystem@brh.co.th", "Systems Request", "", "", "", false);
                bl = true;
            }
        }
        catch
        {
            bl = false;
        }

        return bl;
    }

    public DataTable SelectMailUser(string empid)
    {
        DataTable result = new DataTable();

        sql = "select *,CONCAT(u.userpname,' ',u.userfname,' ',u.userlname) as 'fullName'  from `user` as u where u.username = '" + empid + "' ";
        dt = new DataTable();
        dt = cl_Sql.select(sql);
        if (dt.Rows.Count > 0)
        {
            result = dt;        
        }

        return result;
    }

    public string SelectFormName(string dfid)
    {
        string result = "";

        sql = "SELECT df_name FROM brh_it_request.disbursement_form where df_id = '"+ dfid +"'; ";
        dt = new DataTable();
        dt = cl_Sql.select(sql);
        if(dt.Rows.Count > 0)
        {
            string formname = dt.Rows[0]["df_name"].ToString();

            result = formname;
        }

        return result;
    }
}