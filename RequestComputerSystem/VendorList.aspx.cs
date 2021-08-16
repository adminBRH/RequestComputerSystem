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
    public partial class VendorList : System.Web.UI.Page
    {
         string sql = "";
        DataTable dt;
        SQLclass CL_Sql = new SQLclass();
        protected void Page_Load(object sender, EventArgs e)
        {
            list_vendor();
        }
    
    public Boolean list_vendor()
        {
            Boolean result = false;

            sql = "SELECT vd_id, vd_fname, vd_lname, vd_email, vd_shopname, vd_url, vd_pnumber, vd_address, vd_street, vd_district, vd_province, vd_zipcode FROM `vendor_user`";

            dt = new DataTable(); //ต้อง new data table ใหม่ทุกครั้งเมื่อรับค่า
            dt = CL_Sql.select(sql);

            if (dt.Rows.Count > 0) //หาข้อมูลว่ามีบรรทัดนั้นหรือไม่
            {
                vd_detail.DataSource = dt;
                vd_detail.DataBind();

            } 
            return result;
        }
    }
}