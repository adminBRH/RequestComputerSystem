using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using MySql.Data.MySqlClient;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;


public class ConnectDB
{
    public SqlConnection SqlStrCon()
    {
        //return new SqlConnection("Data Source=BRH-DBS01.BDMS.CO.TH;Initial Catalog=BRH_IT_REQUEST" +
        //    ";Persist Security Info=True;User ID=sa;Password=P@ssw0rd");
        return new SqlConnection("Data Source=203.154.41.76;Initial Catalog=RunDB" +
            ";Persist Security Info=True;User ID=sa;Password=P@ssw0rd@brh");
    }
}
public class SQLclass
{
    //string connection = "Server=localhost;User Id=root; Password=P@ssw0rd; Database=BRH_IT_REQUEST; charset=utf8;Pooling=false";
    string connection = "Server=10.3.10.103;User Id=clusteruser; Password=clusterp@$$; Database=brh_it_request; charset=utf8;Pooling=false";

    string connection2 = "Server=db1.telecorp.co.th;User Id=telecorp; Password=@Telecorp$12345; Database=brh_hospitaldb; charset=utf8;Pooling=false";

    //SQL Server Class
    #region
    public DataTable select(string sql)
    {
        MySqlConnection conn = new MySqlConnection(connection);
        conn.Open();
        MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        conn.Close();
        return dt;
    }
    #endregion

    public DataTable selectBconnect(string sql)
    {
        //SqlConnection conn = new ConnectDB().SqlStrCon();
        SqlConnection SLQConn = new SqlConnection("Data Source=10.121.13.41;Initial Catalog=BRH_Bconnect_RPT" +
            ";Persist Security Info=True;User ID=reports;Password=reports");
        SLQConn.Open();
        SqlDataAdapter da = new SqlDataAdapter(sql, SLQConn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        SLQConn.Close();
        return dt;
    }
    
    public DataTable selectStrategy(string sql)
    {
        //SqlConnection conn = new ConnectDB().SqlStrCon();
        SqlConnection SLQConn = new SqlConnection("Data Source=BRH-DBS01.BDMS.CO.TH;Initial Catalog=BRH_IT_REQUEST" +
            ";Persist Security Info=True;User ID=sa;Password=P@ssw0rd");
        SLQConn.Open();
        SqlDataAdapter da = new SqlDataAdapter(sql, SLQConn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        SLQConn.Close();
        return dt;
    }

    public string ToJSON(string sql)
    {
        string json = string.Empty;

        MySqlConnection conn = new MySqlConnection(connection2);
        conn.Open();
        MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);

        //var ls = new List<mytable>();
        json = "[";
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (dt.Rows.IndexOf(dr) > 0) { json = json + ","; }
                json = json + "{";
                string comma = "";
                foreach (DataColumn dc in dr.Table.Columns)
                {
                    json = json + comma;
                    comma = ",";
                    json = json + "\"" + dc.ColumnName + "\"";
                    json = json + ":";
                    json = json + "\"" + dr[dc.ColumnName].ToString() + "\"";
                }
                json = json + "}";
            }
        }
        json = json + "]";

        return json;
    }

    public Boolean Modify(string sql)
    {
        MySqlConnection conn = new MySqlConnection(connection);
        MySqlCommand command = conn.CreateCommand();
        command.CommandText = sql;
        try
        {
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public string LastID(string id, string table)
    {
        string StID = "";
        string sql = "SELECT LAST_INSERT_ID("+ id + ") as LastID from brh_it_request." + table + "  order by " + id + " desc";
        DataTable dts = new DataTable();
        dts = select(sql);
        StID = dts.Rows[0]["LastID"].ToString();
        return StID;
    }

    public string EmpName(string empid)
    {
        string result = "";

        string sql = "select concat(userpname,' ',userfname,' ',userlname) as 'fullname' from user where username = '" + empid + "' ";
        DataTable dte = new DataTable();
        dte = select(sql);
        if (dte.Rows.Count > 0)
        {
            result = dte.Rows[0]["fullname"].ToString();
        }
        return result;
    }
}

public class Files
{
    public string Show(string path, string id)
    {
        string result = "";
        string FileLink = "";
        string FileName = "";
        DirectoryInfo myDirInfo;
        myDirInfo = new DirectoryInfo(HttpContext.Current.Server.MapPath(path));
        FileInfo[] arrFileInfo = myDirInfo.GetFiles("id" + id + ",*");
        if (arrFileInfo.Length > 0) {
            foreach (FileInfo myFileInfo in arrFileInfo)
            {
                string[] FNs = myFileInfo.Name.Split(',');
                int ml = FNs.Length;
                string name = "";
                for (int i = 1; i < ml; i++)
                {
                    if (name != "")
                    {
                        name = name + ",";
                    }
                    name = name + FNs[i].ToString();
                }
                FileName = "- " + name;
                FileLink = FileLink + ("<a target='_blank' href='" + path + myFileInfo.Name + "' >" + FileName + "</a><br />");
            }
        }
        else
        {
            FileLink = "No file !!";
        }
        result = FileLink;

        return result;
    }
}
