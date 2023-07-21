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
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace RequestComputerSystem
{
    public partial class Login : System.Web.UI.Page
    {
        SQLclass cl_Sql = new SQLclass();
        DataTable dt;
        class_MD5 cl_MD5;
        string sql = "";
        string IDs = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            string user = "";
            string pass = "";
            string remember = "";
            
            user = Request.Form["InUser"];
            pass = Request.Form["InPass"];
            if (Request.Form["txt_remember"] != null) 
            {
                remember = Request.Form["txt_remember"].ToString();
            }

            string x = user + pass;

            if (Request.QueryString["IDs"] != null)
            {
                HttpCookie delCook = new HttpCookie("myCookie");
                delCook.Expires = DateTime.Now.AddDays(-1D);
                Response.Cookies.Add(delCook);

                class_EnDe cl_ED = new class_EnDe();

                x = "IDs";
                string encryptedText = Request.QueryString["IDs"].ToString();
                user = cl_ED.Decrypt(encryptedText, "12345");

                sql = "select * from  `user` where username = '" + user + "' ";
                dt = new DataTable();
                dt = cl_Sql.select(sql);
                if (dt.Rows.Count > 0)
                {
                    user = dt.Rows[0]["username"].ToString();
                    pass = dt.Rows[0]["userpassword"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('ไม่มี User บนระบบนี้ กรุณาติดต่อ Admin !!'); setTimeout(function(){window.location.href='http://10.121.10.212/'}, 10);</script>");
                }

            }
            else if (Request.QueryString["logout"] != null)
            {
                string logout = Request.QueryString["logout"].ToString();

                Session.Clear();

                if (logout == "cookie")
                {
                    HttpCookie delCook = new HttpCookie("myCookie");
                    delCook.Expires = DateTime.Now.AddDays(-1D);
                    Response.Cookies.Add(delCook);
                }

                Response.Redirect("login.aspx?New=y");
            }
            else { }

            if (Request.Cookies["myCookie"] != null && Request.QueryString["IDs"] == null)
            {
                if (Request.QueryString["New"] == null)
                {
                    if (Request.QueryString["logout"] == null)
                    {
                        Response.Redirect("Default.aspx");
                    }
                }
            }
            else
            {
                if (x != "")
                {
                    //Label1.Text = user + " / " + pass;
                    //try
                    //{
                    string alert = "";

                    cl_MD5 = new class_MD5();

                    if (Request.QueryString["IDs"] == null)
                    {
                        pass = cl_MD5.MD5Hash(pass);
                    }

                    string sql1 = "";
                    sql1 = "select *,concat(userpname,' ',userfname,' ',userlname) as 'UserFullName' from `user` where username='" + user + "' and userpassword='" + pass + "'";

                    dt = cl_Sql.select(sql1);
                    if (dt.Rows.Count > 0)
                    {
                        Session["UserID"] = dt.Rows[0]["userid"].ToString();
                        Session["UserLogin"] = dt.Rows[0]["username"].ToString();
                        string FullName = dt.Rows[0]["userpname"].ToString();
                        if (FullName != "")
                        {
                            FullName += " ";
                        }
                        FullName += dt.Rows[0]["userfname"].ToString() + " " + dt.Rows[0]["userlname"].ToString();
                        Session["UserFullName"] = FullName;
                        Session["UserDeptid"] = dt.Rows[0]["userdeptcode"].ToString();

                        string status = dt.Rows[0]["userstatus"].ToString();
                        Session["UserStatus"] = status;

                        if (dt.Rows[0]["userdateedit"].ToString() == null)
                        {
                            Session["ChangePass"] = "Yes";
                        }
                        else
                        {
                            Session["ChangePass"] = "No";
                        }

                        if (status.ToLower() == "hod")
                        {
                            Session["HOD"] = "Yes";
                        }
                        else
                        {
                            Session["HOD"] = "No";
                            if (status != "admin")
                            {
                                sql1 = "select * from department as d where (d.depthod1='" + dt.Rows[0]["username"].ToString() + "' or d.depthod2='" + dt.Rows[0]["username"].ToString() + "') ";
                                dt = new DataTable();
                                dt = cl_Sql.select(sql1);
                                if (dt.Rows.Count > 0)
                                {
                                    Session["HOD"] = "Yes";
                                }
                            }
                        }

                        alert = "Welcome : " + Session["UserStatus"].ToString();

                        if (remember == "remember")
                        {
                            HttpCookie Cook = new HttpCookie("myCookie");

                            Cook["UserID"] = Session["UserID"].ToString();
                            Cook["UserLogin"] = Session["UserLogin"].ToString();
                            Cook["UserStatus"] = Session["UserStatus"].ToString();
                            Cook["HOD"] = Session["HOD"].ToString();
                            Cook.Values.Add("UserFullName", Server.UrlEncode(Session["UserFullName"].ToString()));
                            Cook["UserDeptid"] = Session["UserDeptid"].ToString();
                            Cook.Expires = DateTime.Now.AddDays(7);
                            
                            Response.Cookies.Add(Cook);
                        }

                        Goto();
                    }
                    else
                    {
                        Session.Clear();
                        alert = "Incorrect User Name or Password !!";
                        Response.Write("<script>alert('" + alert + "')</script>");
                    }

                    //}
                    //catch (Exception ex)
                    //{
                    //    Response.Write("<script>alert('" + ex.Message + "')</script>");
                    //}
                }
                else
                {
                    OnSystem();
                }
            }
        }

        public void OnSystem()
        {
            if (Session["UserID"] != null)
            {
                Goto();
            }
        }

        public void Goto()
        {
            if (Request.QueryString["goto"] != null)
            {
                string url = Request.Url.ToString();
                int lenUrl = url.Length;
                int find = url.IndexOf("goto=") + 5;
                string part = url.Substring(find, (lenUrl - find));
                Response.Redirect(part);
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

    }
}