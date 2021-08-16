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
    public partial class ManageHOD : System.Web.UI.Page
    {
        string sql = "";
        DataTable dt;
        SQLclass CL_Sql = new SQLclass();

        protected void Page_Load(object sender, EventArgs e)
        {
            Grid1();
        }

        public Boolean Grid1()
        {
            Boolean bl = false;

            sql = "select d.* ,concat(u1.userpname,' ',u1.userfname,' ',u1.userlname) as 'HOD1' " +
                ",concat(u2.userpname, ' ', u2.userfname, ' ', u2.userlname) as 'HOD2' " +
                "from department as d " +
                "left join `user` as u1 on u1.username = d.depthod1 " +
                "left join `user` as u2 on u2.username = d.depthod2 " +
                "Order by d.deptname ";
            dt = new DataTable();
            dt = CL_Sql.select(sql);
            if (dt.Rows.Count>0)
            {
                bl = true;
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();

            return bl;
        }

        protected void btn_edit_ServerClick(object sender, EventArgs e)
        {
            div_edit.Visible = true;

            string deptid = txtH_ID.Value.ToString();
            sql = "select d.* ,concat(u1.userpname,' ',u1.userfname,' ',u1.userlname) as 'HOD1' " +
                ",concat(u2.userpname, ' ', u2.userfname, ' ', u2.userlname) as 'HOD2' " +
                "from department as d " +
                "left join `user` as u1 on u1.username = d.depthod1 " +
                "left join `user` as u2 on u2.username = d.depthod2 " +
                "where deptid = '" + deptid + "' ";
            dt = new DataTable();
            dt = CL_Sql.select(sql);
            if (dt.Rows.Count > 0)
            {
                lbl_deptname.Text = dt.Rows[0]["deptname"].ToString();
                txt_hod1id.Value = dt.Rows[0]["depthod1"].ToString();
                txt_hod1name.Value = dt.Rows[0]["HOD1"].ToString();
                txt_hod2id.Value = dt.Rows[0]["depthod2"].ToString();
                txt_hod2name.Value = dt.Rows[0]["HOD2"].ToString();
            }
        }
    }
}