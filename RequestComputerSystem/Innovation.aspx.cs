using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RequestComputerSystem
{
    public partial class Innovation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_score_Click(object sender, EventArgs e)
        {
            Response.Write("<script>setTimeout(function(){window.location.href='InnovationSummary.aspx'}, 100);</script>");
        }
    }
}