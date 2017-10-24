using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label lblTitle = (Label)this.Master.FindControl("lblTitle");
        if (Session["Admin"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        switch (Request.QueryString["x"])
        {
            case "view-all-users":
                {
                    lblTitle.Text = "Users Management";
                    panel1.Visible = false;
                    PlaceHolder1.Controls.Add(LoadControl("uc/viewallusers.ascx"));
                    break;
                }
            case "view-all-products":
                {
                    lblTitle.Text = "Products Management";
                    panel1.Visible = false;
                    PlaceHolder1.Controls.Add(LoadControl("uc/viewallproducts.ascx"));
                    break;
                }
            case "add-users":
                {
                    lblTitle.Text = "Add Users";
                    panel1.Visible = false;
                    PlaceHolder1.Controls.Add(LoadControl("uc/adduser.ascx"));
                    break;
                }
            case "add-product":
                {
                    lblTitle.Text = "Add Product";
                    panel1.Visible = false;
                    PlaceHolder1.Controls.Add(LoadControl("uc/addproduct.ascx"));
                    break;
                }

            case "view-category":
                {
                    lblTitle.Text = "Categories Management";
                    panel1.Visible = false;
                    PlaceHolder1.Controls.Add(LoadControl("uc/viewcategory.ascx"));
                    break;
                }
            case "add-category":
                {
                    lblTitle.Text = "Add Category";
                    panel1.Visible = false;
                    PlaceHolder1.Controls.Add(LoadControl("uc/addcategory.ascx"));
                    break;
                }
            case "view-orders":
                {
                    lblTitle.Text = "Orders Management";
                    panel1.Visible = false;
                    PlaceHolder1.Controls.Add(LoadControl("uc/viewallorders.ascx"));
                    break;
                }
            case "view-manu":
                {
                    lblTitle.Text = "Manufacturers Management";
                    panel1.Visible = false;
                    PlaceHolder1.Controls.Add(LoadControl("uc/viewmanufacturers.ascx"));
                    break;
                }
            case "add-manu":
                {
                    lblTitle.Text = "Add Manufacturers";
                    panel1.Visible = false;
                    PlaceHolder1.Controls.Add(LoadControl("uc/addmanu.ascx"));
                    break;
                }
            case "view-cmt":
                {
                    lblTitle.Text = "User Comment";
                    panel1.Visible = false;
                    PlaceHolder1.Controls.Add(LoadControl("uc/viewallcmt.ascx"));
                    break;
                }
        }
    }
    protected void btnUsers_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx?x=view-all-users");
    }
    protected void btnProducts_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx?x=view-all-products");
    }
    protected void btnCategories_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx?x=view-category");
    }
    protected void btnOrder_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx?x=view-orders");
    }
    protected void btnManufacturers_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx?x=view-manu");
    }
    protected void btnCmt_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx?x=view-cmt");
    }
}