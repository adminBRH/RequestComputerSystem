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
    public partial class InnovationSummary : System.Web.UI.Page
    {
        string sql = "";
        DataTable dt;
        SQLclass cl_Sql = new SQLclass();

        protected void Page_Load(object sender, EventArgs e)
        {
            string JavaScript = "var pass = prompt('Please enter Password', '');" +
                "if (pass != '7881') { " +
                "alert('รหัสผ่านไม่ถูกต้อง'); setTimeout(function(){window.location.href='Innovation.aspx'}, 100); " +
                "} ";
            Response.Write("<script>" + JavaScript + "</script>");


            sql = "select id,story,board,(criterion1+criterion2+criterion3+criterion4+criterion5+criterion6) as 'Sum' " +
                "from brh_it_request.innovation2019 order by story,board ";
            dt = new DataTable();
            dt = cl_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
                int TotalS1 = 0; int TotalS2 = 0; int TotalS3 = 0; int TotalS4 = 0; int TotalS5 = 0; int TotalS6 = 0; int TotalS7 = 0;
                foreach (DataRow dtr in dt.Rows)
                {
                    string Story = dtr["story"].ToString();
                    string board = dtr["board"].ToString();
                    string Sum = dtr["sum"].ToString();

                    if (Story == "S1" && board == "Board1") { lb_S1B1.Text = Sum; }
                    if (Story == "S1" && board == "Board2") { lb_S1B2.Text = Sum; }
                    if (Story == "S1" && board == "Board3") { lb_S1B3.Text = Sum; }
                    if (Story == "S1") { TotalS1 += int.Parse(Sum); }

                    if (Story == "S2" && board == "Board1") { lb_S2B1.Text = Sum; }
                    if (Story == "S2" && board == "Board2") { lb_S2B2.Text = Sum; }
                    if (Story == "S2" && board == "Board3") { lb_S2B3.Text = Sum; }
                    if (Story == "S2") { TotalS2 += int.Parse(Sum); }

                    if (Story == "S3" && board == "Board1") { lb_S3B1.Text = Sum; }
                    if (Story == "S3" && board == "Board2") { lb_S3B2.Text = Sum; }
                    if (Story == "S3" && board == "Board3") { lb_S3B3.Text = Sum; }
                    if (Story == "S3") { TotalS3 += int.Parse(Sum); }

                    if (Story == "S4" && board == "Board1") { lb_S4B1.Text = Sum; }
                    if (Story == "S4" && board == "Board2") { lb_S4B2.Text = Sum; }
                    if (Story == "S4" && board == "Board3") { lb_S4B3.Text = Sum; }
                    if (Story == "S4") { TotalS4 += int.Parse(Sum); }

                    if (Story == "S5" && board == "Board1") { lb_S5B1.Text = Sum; }
                    if (Story == "S5" && board == "Board2") { lb_S5B2.Text = Sum; }
                    if (Story == "S5" && board == "Board3") { lb_S5B3.Text = Sum; }
                    if (Story == "S5") { TotalS5 += int.Parse(Sum); }

                    if (Story == "S6" && board == "Board1") { lb_S6B1.Text = Sum; }
                    if (Story == "S6" && board == "Board2") { lb_S6B2.Text = Sum; }
                    if (Story == "S6" && board == "Board3") { lb_S6B3.Text = Sum; }
                    if (Story == "S6") { TotalS6 += int.Parse(Sum); }

                    if (Story == "S7" && board == "Board1") { lb_S7B1.Text = Sum; }
                    if (Story == "S7" && board == "Board2") { lb_S7B2.Text = Sum; }
                    if (Story == "S7" && board == "Board3") { lb_S7B3.Text = Sum; }
                    if (Story == "S7") { TotalS7 += int.Parse(Sum); }

                }
                lb_S1Sum.Text = TotalS1.ToString();
                lb_S2Sum.Text = TotalS2.ToString();
                lb_S3Sum.Text = TotalS3.ToString();
                lb_S4Sum.Text = TotalS4.ToString();
                lb_S5Sum.Text = TotalS5.ToString();
                lb_S6Sum.Text = TotalS6.ToString();
                lb_S7Sum.Text = TotalS7.ToString();
            }
        }
    }
}