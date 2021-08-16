using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RequestComputerSystem.Disbursement
{
    public partial class DisbursementDoctorDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void next_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("ChangeFrom.aspx");
        }
    }
}