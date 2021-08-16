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
    public partial class WebForm1 : System.Web.UI.Page
    {
        string sql = "";
        DataTable dt;
        SQLclass cl_Sql = new SQLclass();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ddl_Board_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_Board.SelectedValue != "")
            {
                DivBody.Visible = true;

                sql = "select id,board,story,flag from brh_it_request.innovation2019 as i where i.board='" + ddl_Board.Text + "' order by story";
                dt = new DataTable();
                dt = cl_Sql.select(sql);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dtr in dt.Rows)
                    {
                        if (dtr["story"].ToString() == "S1") { ddl_story.Items.FindByValue("S1").Enabled = false; } else { ddl_story.Items.FindByValue("S1").Enabled = true; }
                        if (dtr["story"].ToString() == "S2") { ddl_story.Items.FindByValue("S2").Enabled = false; } else { ddl_story.Items.FindByValue("S2").Enabled = true; }
                        if (dtr["story"].ToString() == "S3") { ddl_story.Items.FindByValue("S3").Enabled = false; } else { ddl_story.Items.FindByValue("S3").Enabled = true; }
                        if (dtr["story"].ToString() == "S4") { ddl_story.Items.FindByValue("S4").Enabled = false; } else { ddl_story.Items.FindByValue("S4").Enabled = true; }
                        if (dtr["story"].ToString() == "S5") { ddl_story.Items.FindByValue("S5").Enabled = false; } else { ddl_story.Items.FindByValue("S5").Enabled = true; }
                        if (dtr["story"].ToString() == "S6") { ddl_story.Items.FindByValue("S6").Enabled = false; } else { ddl_story.Items.FindByValue("S6").Enabled = true; }
                        if (dtr["story"].ToString() == "S7") { ddl_story.Items.FindByValue("S7").Enabled = false; } else { ddl_story.Items.FindByValue("S7").Enabled = true; }
                    }
                }
                else
                {
                    ddl_story.Items.FindByValue("S1").Enabled = true;
                    ddl_story.Items.FindByValue("S2").Enabled = true;
                    ddl_story.Items.FindByValue("S3").Enabled = true;
                    ddl_story.Items.FindByValue("S4").Enabled = true;
                    ddl_story.Items.FindByValue("S5").Enabled = true;
                    ddl_story.Items.FindByValue("S6").Enabled = true;
                    ddl_story.Items.FindByValue("S7").Enabled = true;
                }
            }
            else
            {
                DivBody.Visible = false;
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (ddl_story.SelectedValue != "")
            {
                //Response.Write("<script>alert('" + txtBoard.Text + "');</script>");
                //Response.Write("<script>alert('" + TxtStory.Text + "');</script>");

                try
                {
                    sql = "INSERT INTO brh_it_request.innovation2019 " +
                        "(board, boardname, story, storydetail, criterion1,criterion2,criterion3,criterion4,criterion5,criterion6, flag, updatedate) " +
                        "VALUES('" + ddl_Board.Text + "', '" + txtBoard.Text + "', '" + ddl_story.Text + "', '" + TxtStory.Text + "' " +
                        ", " + val1.Text + ", " + val2.Text + ", " + val3.Text + ", " + val4.Text + ", " + val5.Text + ", " + val6.Text + " " +
                        ", 'Submit', now() )";
                    if (cl_Sql.Modify(sql) == true)
                    {
                        Response.Write("<script>alert('บันทึกผลคะแนน เรียบร้อยแล้ว !!'); setTimeout(function(){window.location.href='Innovation.aspx'}, 100);</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('ไม่สามารถบันทึกผลคะแนนได้ กรุณาติดต่อผู้ดูแลระบบ !!');</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('กรุณาเลือกหัวข้อ Innovation !!');</script>");
            }
        }
    }
}