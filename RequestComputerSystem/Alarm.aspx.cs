using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RequestComputerSystem
{
    public partial class Alarm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["code"] != null)
            {
                string icon = "";
                string topic = "";
                string details = "";
                string code = Request.QueryString["code"].ToString();
                switch (code)
                {
                    case "W01": icon = "warning";
                        topic = "You are not authorized to access.";
                        details = "คุณไม่ได้รับอนุญาตให้เข้าถึง<br />ผู้ที่มีสิทธิ์เข้าถึงจะต้องเป็นผู้ดูแลระบบหรือฝ่ายบุคคลเท่านั้น";
                        break;
                    case "W02": icon = "warning";
                        topic = "You are not authorized to access.";
                        details = "คุณไม่ได้รับอนุญาตให้เข้าถึง<br />ผู้ที่มีสิทธิ์เข้าถึงจะต้องเป็นระดับหัวหน้าแผนกขึ้นไปเท่านั้น";
                        break;
                    case "I01": icon = "info";
                        topic = "Please change your password.";
                        details = "กรุณาเปลี่ยนรหัสผ่านของคุณ<br />เนื่องจากสามารถคาดเดาได้ง่าย";
                        break;
                    case "E01": icon = "error";
                        topic = "Error ! Please contact to administrator.";
                        details = "เกิดข้อผิดพลาด กรุณาติดต่อผู้ดูแลระบบ";
                        break;
                    default: 
                        break;
                }

                ImgIcon(icon);
                lbl_topic.Text = topic;
                lbl_detail.Text = details;
            }
        }

        protected void ImgIcon(string icon)
        {
            string src = "../image/icons/";
            if (icon == "warning")
            {
                src += "warning_icon.png";
            } 
            else if (icon == "info")
            {
                src += "info_icon.png";
            }
            else
            {
                src += "error_icon.png";
            }

            img_icon.Src = src;
        }
    }
}