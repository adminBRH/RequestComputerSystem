using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;


namespace RequestComputerSystem
{
    public partial class signin : System.Web.UI.Page
    {
        //valiable for connection
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {   
            /*
            string StrConn = "";
            //connection string
            StrConn = ConfigurationManager.ConnectionStrings["BRH_IT_REQUESTConnectionString"].ConnectionString;
            try
            {
                //connect DB
                conn = new SqlConnection(StrConn);
                conn.Open();
                if(conn.State == ConnectionState.Open)
                {
                    this.lblText.Text = "SQL Server Connected";
                }
                else
                {
                    this.lblText.Text = "SQL Server Connect Failed";
                }
                
                //Query and data
                var da = new SqlDataAdapter("select * from [user]", conn);
                //Keep Many table and referrent
                DataSet ds = new DataSet();
                //Keep 1 table
                DataTable dt = new DataTable();

                da.Fill(dt);

                //for convert html to PlaceHolder
                StringBuilder sb = new StringBuilder();
                sb.Append("<table class='table'>" +
                    "<thead><tr><th scope = 'col' >User Name</th></tr></thead><tbody>");
                foreach (DataRow dr in dt.Rows)
                {
                    sb.Append("<tr><td>" + dr["username"].ToString() + "</td></tr>");
                }
                sb.Append("</tbody></table>");
                PlaceHolder1.Controls.Add(new Literal { Text = sb.ToString() });

                // Show on Grid
                //GridView1.DataSource = dt;
                //GridView1.DataBind();
                
            }
            catch(Exception ex)
            {

            }
            */
        }

        protected void Page_Unload()
        {
            //conn.Close();
            //conn = null;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            

        }
    }
}