using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

using System.IO;

namespace RequestComputerSystem
{
    public partial class vendor_register : System.Web.UI.Page
    {
        string sql = "";
        DataTable dt;
        SQLclass CL_Sql = new SQLclass();
        private bool result;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Boolean InsertData()
        {
            Boolean result = false;

            //if (uploadimg.HasFile)
            //{
            //try
            //{
            //if (uploadimg.PostedFile.ContentType == "image/jpeg")
            //{
            //if (uploadimg.PostedFile.ContentLength < 1024000)
            //{
            // string filename = Path.GetFileName(uploadimg.FileName);
            // string[] File_ar = filename.ToString().Split('.');
            // filename = File_ar[0] + "," + Vendorid + "." + File_ar[1];
            // uploadimg.SaveAs(Server.MapPath("fileupload\\") + filename);
            //  StatusLabel.Text = "Upload status: File uploaded!";

            //string sql = "INSERT INTO `vendor_user`" +
            // "(vd_img)" + "VALUES('" + filename + "');";

            // if (CL_Sql.Modify(sql))
            // {
            //  result = true;
            // }

            string fname = firstname.Value.ToString().Trim();
            string lname = lastname.Value.ToString().Trim();
            string email = vdemail.Value.ToString().Trim();
            string shopname = vdshopname.Value.ToString().Trim();
            string url = vdurl.Value.ToString().Trim();
            string phone = phonenumber.Value.ToString().Trim();
            string address = vdaddress.Value.ToString().Trim();
            string street = vdstreet.Value.ToString().Trim();
            string district = vddistrict.Value.ToString().Trim();
            string province = vdprovince.Value.ToString().Trim();
            string zipcode = vdzipcode.Value.ToString().Trim();

            sql = "INSERT INTO `vendor_user`" +
            "(vd_fname, vd_lname, vd_email, vd_shopname, vd_url, vd_pnumber, vd_address, vd_street, vd_district, vd_province, vd_zipcode)" +
            "VALUES('" + fname + "', '" + lname + "', '" + email + "', '" + shopname + "', '" + url + "', '" + phone + "', '" + address + "', '" + street + "', '" + district + "', '" + province + "', '" + zipcode + "');";

            if (CL_Sql.Modify(sql))
            {
                result = true;
            }

            // }
            //  else
            //   StatusLabel.Text = "Upload status: The file has to be less than 100 kb!";
            //}
            // else
            //  StatusLabel.Text = "Upload status: Only JPEG files are accepted!";
            // }
            // catch (Exception ex)
            // {
            //StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
            //}
            //}



            return result;
        }

        protected void savedata_ServerClick(object sender, EventArgs e)
        {
            {
                if (InsertData())
                {
                    Response.Write("<script>alert('บันทึกสำเร็จ'); window.location.href='VendorEdit.aspx';</script>");

                }
                else
                {
                    Response.Write("<script>alert('ไม่สามารถบันทึกได้กรุณาติดต่อ Admin');</script>");
                }
            }
        }
    }
}