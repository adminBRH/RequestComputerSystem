using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace RequestComputerSystem.RequestJob
{
    public partial class Default : System.Web.UI.Page
    {
        string sql = "";
        DataTable dt;
        SQLclass cl_Sql = new SQLclass();

        protected void Page_Load(object sender, EventArgs e)
        {
            //dt = new DataTable();
            //dt = DB();

            //string id = "1";
            //if (TEST(id))
            //{

            //}
        }

        private DataTable DB()
        {
            sql = "select * from DB where ";
            dt = new DataTable();
            dt = cl_Sql.select(sql);
            if (dt.Rows.Count > 0)
            { }

            return dt;
        }

        private Boolean TEST(string id)
        {
            Boolean bl = false;
                 
            sql = "update db set f1 = '' where id = '" + id + "' ";
            if (cl_Sql.Modify(sql))
            {
                bl = true;
            }

            return bl;
        }

        protected void test2()
        {
            dt = DB();
        }

        protected void btn_test_ServerClick(object sender, EventArgs e)
        {
            string inp1 = inp_test.Value.ToString().Trim();
        }

        private void DDTest()
        {
            dt = new DataTable();
            dt = DB();

            dd_test.DataSource = dt;
            dd_test.DataTextField = "ft";
            dd_test.DataValueField = "fv";
            dd_test.DataBind();
        }
    }
}