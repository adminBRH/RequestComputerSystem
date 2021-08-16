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
using Org.BouncyCastle.Asn1.Ocsp;

namespace RequestComputerSystem
{
    public partial class VendorEdit : System.Web.UI.Page //ประกาศเชื่อมต่อฐานข้อมูลจากคลาสที่สร้างไว้
    {
        string sql = "";
        DataTable dt;
        SQLclass CL_Sql = new SQLclass();
        string id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                id = Request.QueryString["id"].ToString();
            }
            else
            {
                Response.Redirect("VendorList.aspx");
            }
            if (!IsPostBack) //อิสโพสแบล็กคือ ให้มันทำอีเว้นครั้งเดียวเช่นเรียกชาแสดง1ครั้ง                                                                                                                                                                                0ในมอดอลเวลากดอัพเดทจะไม่เรียกมาใช้
            {
                select_data();
                showdata_mordal();
            }
            
        }  
        public Boolean select_data() //Select ดาต้ามาแสดงนะ
        {
            Boolean result = false;

            string vd_detail = id;

            edit_fname.Text = vd_detail;
            edit_lname.Text = vd_detail;
            edit_email.Text = vd_detail;
            edit_url.Text = vd_detail;
            edit_shopname.Text = vd_detail;
            edit_img.Text = vd_detail;
            edit_pnumber.Text = vd_detail;
            edit_address.Text = vd_detail;
            edit_street.Text = vd_detail;
            edit_district.Text = vd_detail;
            edit_province.Text = vd_detail;
            edit_zipcode.Text = vd_detail;

            // --------------------------------------------- Show File Upload --------------------

            string Path = "fileupload/";
            DirectoryInfo myDirInfo;
            myDirInfo = new DirectoryInfo(Server.MapPath(Path));
            FileInfo[] myFileInfo = myDirInfo.GetFiles("*," + vd_detail + "*");            
            if (myFileInfo.Length>0) 
            {
                lbl_img.Text = "<img src='" + Path + myFileInfo[0].Name + "' width='100%' /> ";
            }
            else
            {
                lbl_img.Text = "<img src='fileupload/User_profile.jpg' width='100%' /> ";
            } 

            // --------------------------------------------- Show File Upload --------------------

            sql = "SELECT * FROM vendor_user WHERE vd_id = '" + vd_detail + "' "; //SELECT vd_id FROM vendor_user; คิวรี่ด้วยโค้ดนี้นะ

            dt = new DataTable();
            dt = CL_Sql.select(sql);

            if (dt.Rows.Count > 0) //If เช็คข้อมูลในแถวว่ามีมากกว่า 0 ไหมถ้ามีให้แสดงออกมาแบบ Array
            {
                edit_fname.Text = dt.Rows[0]["vd_fname"].ToString();
            }

            if (dt.Rows.Count > 0)
            {
                edit_lname.Text = dt.Rows[0]["vd_lname"].ToString();
            }

            if (dt.Rows.Count > 0)
            { 
                edit_email.Text = dt.Rows[0]["vd_email"].ToString();
            }

            if (dt.Rows.Count > 0)
            {
                edit_url.Text = dt.Rows[0]["vd_url"].ToString();
            }
             
            if (dt.Rows.Count > 0)
            {
                edit_shopname.Text = dt.Rows[0]["vd_shopname"].ToString();
            }
            
            if (dt.Rows.Count > 0)
            {
                edit_pnumber.Text = dt.Rows[0]["vd_pnumber"].ToString();
            }

            if (dt.Rows.Count > 0)
            {
                edit_address.Text = dt.Rows[0]["vd_address"].ToString();
            }

            if (dt.Rows.Count > 0)
            {
                edit_street.Text = dt.Rows[0]["vd_street"].ToString();
            }

            if (dt.Rows.Count > 0)
            {
                edit_district.Text = dt.Rows[0]["vd_district"].ToString();
            }

            if (dt.Rows.Count > 0)
            {
                edit_province.Text = dt.Rows[0]["vd_province"].ToString();
            }

            if (dt.Rows.Count > 0)
            {
                edit_zipcode.Text = dt.Rows[0]["vd_zipcode"].ToString();
            }

            return result;
        }

        public Boolean showdata_mordal()
        {
            Boolean result = false;

            string vd_detail = id;
      
            firstname.Value = vd_detail;
            lastname.Value = vd_detail;
            vdemail.Value = vd_detail;
            vdurl.Value = vd_detail;
            vdshopname.Value = vd_detail;
            phonenumber.Value = vd_detail;
            vdaddress.Value = vd_detail;
            vdstreet.Value = vd_detail;
            vddistrict.Value = vd_detail;
            vdprovince.Value = vd_detail;
            vdstate.Value = vd_detail;


            sql = "SELECT * FROM vendor_user WHERE vd_id = '" + vd_detail + "' "; //SELECT vd_id FROM vendor_user; คิวรี่ด้วยโค้ดนี้นะ

            dt = new DataTable();
            dt = CL_Sql.select(sql);

            if (dt.Rows.Count > 0) //If เช็คข้อมูลในแถวว่ามีมากกว่า 0 ไหมถ้ามีให้แสดงออกมาแบบ Array
            {
                firstname.Value = dt.Rows[0]["vd_fname"].ToString();
            }

            if (dt.Rows.Count > 0)
            {
                lastname.Value = dt.Rows[0]["vd_lname"].ToString();
            }

            if (dt.Rows.Count > 0)
            {
                vdemail.Value = dt.Rows[0]["vd_email"].ToString();
            }

            if (dt.Rows.Count > 0)
            {
                vdurl.Value = dt.Rows[0]["vd_url"].ToString();
            }

            if (dt.Rows.Count > 0)
            {
                vdshopname.Value = dt.Rows[0]["vd_shopname"].ToString();
            }

            if (dt.Rows.Count > 0)
            {
                phonenumber.Value = dt.Rows[0]["vd_pnumber"].ToString();
            }

            if (dt.Rows.Count > 0)
            {
                vdaddress.Value = dt.Rows[0]["vd_address"].ToString();
            }

            if (dt.Rows.Count > 0)
            {
                vdstreet.Value = dt.Rows[0]["vd_street"].ToString();
            }

            if (dt.Rows.Count > 0)
            {
                vddistrict.Value = dt.Rows[0]["vd_district"].ToString();
            }

            if (dt.Rows.Count > 0)
            {
                vdprovince.Value = dt.Rows[0]["vd_province"].ToString();
            }

            if (dt.Rows.Count > 0)
            {
                vdstate.Value = dt.Rows[0]["vd_zipcode"].ToString();
            }

            return result;
        }


        public Boolean update_data() //Update ข้อมูลแทนที่เดิมโดย Update ข้อมูลทับจากค่า ID ที่ถูกส่งมาจาก Eval ในหน้า VendorList
        {
            Boolean result = false;

            string vd_detail = id; //ตัวแปลที่สร้างมาเพื่อรับค่า ID ผ่านลิงค์ จากหน้า VendorList เพื่อเรียกใช้
            vd_detail = Request.QueryString["id"];

            if (uploadimg.HasFile)
            {
                try
                {
                    if (uploadimg.PostedFile.ContentLength < 1024000)
                    {
                        string filename = Path.GetFileName(uploadimg.FileName);
                        string[] File_ar = filename.ToString().Split('.');
                        filename = File_ar[0] + "," + vd_detail + "." + File_ar[1];
                        if (File_ar[1] == "jpg" || File_ar[1] == "png")
                        {
                            string part = "~/fileupload/";


                            DirectoryInfo myDirInfo;
                            myDirInfo = new DirectoryInfo(Server.MapPath("fileupload/"));
                            FileInfo[] myFileInfo = myDirInfo.GetFiles("*," + vd_detail + "*");

                            if (myFileInfo.Length > 0)
                            {
                                string strFileFullPath = Server.MapPath("fileupload/") + myFileInfo[0].ToString();

                                if (System.IO.File.Exists(strFileFullPath))
                                {
                                    System.IO.File.Delete(strFileFullPath);
                                }
                            }

                            uploadimg.SaveAs(System.IO.Path.Combine(Server.MapPath(part), filename));
                            StatusLabel.Text = "Upload status: File uploaded!";

                            string fname1 = firstname.Value.ToString().Trim();
                            string lname1 = lastname.Value.ToString().Trim();
                            string email1 = vdemail.Value.ToString().Trim();
                            string shopname1 = vdshopname.Value.ToString().Trim();
                            string url1 = vdurl.Value.ToString().Trim();
                            string phone1 = phonenumber.Value.ToString().Trim();
                            string address1 = vdaddress.Value.ToString().Trim();
                            string street1 = vdstreet.Value.ToString().Trim();
                            string district1 = vddistrict.Value.ToString().Trim();
                            string province1 = vdprovince.Value.ToString().Trim();
                            string state1 = vdstate.Value.ToString().Trim();

                            sql = "UPDATE vendor_user SET vd_fname = '" + fname1 + "', vd_lname = '" + lname1 + "', vd_email = '" + email1 + "', vd_shopname = '" + shopname1 + "', vd_url = '" + url1 + "', vd_pnumber = '" + phone1 + "', vd_address = '" + address1 + "', vd_street = '" + street1 + "', vd_district = '" + district1 + "', vd_province = '" + province1 + "', vd_zipcode = '" + state1 + "' WHERE vd_id = '" + vd_detail + "';";

                            if (CL_Sql.Modify(sql))
                            {
                                result = true;
                            }
                        }
                        else
                            StatusLabel.Text = "Upload status: Only JPEG or PNG files are accepted!";

                    }
                    else
                        StatusLabel.Text = "Upload status: The file has to be less than 100 kb!";
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }

            return result;
        }

        public Boolean delete_data() //ลบข้อมูลใน  Database อ้างจาก ID ที่ถูกส่งมาจากหน้า Eval ในหน้า VendorList.aspx
        {
            Boolean result = false;

            string vd_detail = ""; //ตัวแปลที่สร้างมาเพื่อรับค่า ID ผ่านลิงค์ จากหน้า VendorList เพื่อเรียกใช้
            vd_detail = Request.QueryString["id"];

            string fname = firstname.Value.ToString().Trim();
            string lname = lastname.Value.ToString().Trim();
            string email = vdemail.Value.ToString().Trim();
            string shopname = vdshopname.Value.ToString().Trim();
            string url = vdurl.Value.ToString().Trim();
            //string img = upload_img.Value.ToString().Trim();
            string phone = phonenumber.Value.ToString().Trim();
            string address = vdaddress.Value.ToString().Trim();
            string street = vdstreet.Value.ToString().Trim();
            string district = vddistrict.Value.ToString().Trim();
            string province = vdprovince.Value.ToString().Trim();
            string state = vdstate.Value.ToString().Trim(); 

            sql = "DELETE FROM vendor_user WHERE vd_id = '" + vd_detail + "';";

            if (CL_Sql.Modify(sql))
            {
                result = true;
            }
            return result;
        }

        protected void savechange_ServerClick(object sender, EventArgs e) //บันทึกการกดพร้อมแจ้งเตือนสภานะ
        {
            if (update_data()) //ชื่อคลาสที่เราสร้างไว้ที่จะให้มันกระทำการบันทึก
            {
                Response.Write("<script>alert('บันทึกสำเร็จ'); window.location.href='VendorEdit.aspx?id="+ id +"'</script>");
            }
            else
            {
                Response.Write("<script>alert('ไม่สามารถบันทึกได้กรุณาติดต่อ Admin');</script>");
            }
        }

        protected void save_delete_ServerClick(object sender, EventArgs e)
        {
            //if (delete_data()) //ชื่อคลาสที่เราสร้างไว้ที่จะให้มันกระทำการบันทึก
            //{
            //    Response.Write("<script>alert('ลบข้อมูลเสร็จสิ้น');</script>");
            //}
            //else
            //{
            //    Response.Write("<script>alert('ไม่สามารถลบข้อมูลได้กรุณาติดต่อ Admin');</script>");
            //}
        }
    }
}