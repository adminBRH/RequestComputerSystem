using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using IronBarCode;
using System.Drawing;

namespace RequestComputerSystem.ArcusAir
{
    public partial class GenerateBarcode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
            else
            {
                CheckData();
            }
            //CreateBarcode();
        }

        public string GenBarcode(string user, string pass)
        {
            string result = "";

            string path = "images/barcodeArcusAir/";
            string filename = user + ".jpg";
            try
            {
                BarcodeWriter.CreateBarcode(pass, BarcodeWriterEncoding.Code128).ResizeTo(400, 100).SaveAsImage(System.IO.Path.Combine(Server.MapPath(path), filename));
                result = path + filename;
            }
            catch
            {
                result = "";
            }
            return result;
        }

        protected void btnGenBarcode_Click(object sender, EventArgs e)
        {
            
        }

        protected void CheckData()
        {
            string user = txt_user.Value.ToString().Trim();
            string pass = txt_pass.Value.ToString().Trim();
            if (user == "" || pass == "")
            {

            }
            else
            {
                string fileName = "images/barcodeArcusAir/" + user + ".jpg";
                if (File.Exists(Server.MapPath(fileName)))
                {
                    File.Delete(Server.MapPath(fileName));
                }

                string path = GenBarcode(user, pass);
                if (path != "")
                {
                    img_barcode.Src = path;
                    lbl_script.Text = user;
                }
                else
                {
                    Response.Write("<script>alert('ไม่สามารถสร้างบาร์โค้ดได้ กรุณาติดต่อผู้ดูแลระบบ !!');</script>");
                }
            }
        }
    }
}