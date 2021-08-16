using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RequestComputerSystem
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string MyC = "";
            string userLoginmail = "";
            if (Request.QueryString["usermail"] != null)
            {
                userLoginmail = Request.QueryString["usermail"].ToString();
            }

            if (Request.Cookies["myCookie"] != null)
            {
                MyC = Request.Cookies["myCookie"]["UserLogin"];
                Session["UserID"] = Request.Cookies["myCookie"]["UserID"];
                Session["UserStatus"] = Request.Cookies["myCookie"]["UserStatus"];
                Session["UserLogin"] = Request.Cookies["myCookie"]["UserLogin"];
                Session["HOD"] = Request.Cookies["myCookie"]["HOD"];
                Session["UserFullName"] = Server.UrlDecode(Request.Cookies["myCookie"]["UserFullName"]);
            }

            //Session.Clear();
            if (Session["UserID"] != null)
            {
                if (Session["UserLogin"].ToString() == "test")
                {
                    Session["Test"] = "Yes"; // --------------------------- For Test -------------------------
                }
            }

            if (Session["UserLogin"] != null)
            {
                if (userLoginmail != "" && MyC != userLoginmail) { Response.Redirect("Login.aspx?logout=cookie&usermail=" + userLoginmail); }

                lblUsername.Text = "Welcome back : " + Session["UserFullName"].ToString();
            }
            else
            {
                if (userLoginmail != "")
                {
                    Response.Redirect("~/Login.aspx?usermail" + userLoginmail);
                }
                else
                {
                    string page = "";
                    if (Request.QueryString["goto"] != null)
                    {
                        page = "?goto=" + Request.QueryString["goto"].ToString();
                    }
                    Response.Redirect("~/Login.aspx" + page);
                }
            }

        }
    }
}