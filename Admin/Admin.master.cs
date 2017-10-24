using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Application["DangTruyCap"] == null)
        {
            lblOnline.Text = "0";
        }
        else
            lblOnline.Text = Application["DangTruyCap"].ToString();
        lblCounter.Text = Application["DaTruyCap"].ToString();
    }
    protected void btnLogout_Click(object sender, ImageClickEventArgs e)
    {
        Session["Admin"] = null;
        Response.Redirect("Login.aspx");
    }

}
