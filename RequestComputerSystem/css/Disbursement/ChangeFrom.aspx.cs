using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RequestComputerSystem.Disbursement
{
    public partial class ChangeFrom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddl_form_SelectedIndexChanged(object sender, EventArgs e)
        {
            string val = ddl_form.SelectedValue.ToString();
            if (val == "1")
            {
                Response.Redirect("RecordDisbursementMoney.aspx");
            }
            else if (val == "2")
            {
                Response.Redirect("DoctorTravelExpenses.aspx");
            }
            else if (val == "3")
            {
                Response.Redirect("Repayment.aspx");
            }
            else if (val == "4")
            {
                Response.Redirect("CostCancel.aspx");
            }
            else
            {
                Response.Write("<script>alert('กรุณาเลือกแบบฟอร์ม !!');</script>");
            }
        }
    }
}