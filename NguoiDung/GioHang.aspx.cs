using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class GioHang : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //hien thi san pham tu gio hang
            GridView1.DataSource = (DataTable)Session["GioHang"];
            GridView1.DataBind();
            if (Session["TongTien"] != null)
                lblTongCong.Text = "Total: " + Session["TongTien"].ToString() + "$";
        }
        if (Session["GioHang"] == null)
        {
            btnDatHang.Enabled = false;
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            if (Session["GioHang"] != null)
            {
                int i = e.RowIndex;
                DataTable dt = new DataTable();
                Label lblSL = (Label)this.Master.FindControl("lblSL");
                Label lblTT = (Label)this.Master.FindControl("lblTongTien");
                dt = (DataTable)Session["GioHang"];
                lblSL.Text = (Convert.ToInt32(Session["TongSl"]) - Convert.ToInt32(dt.Rows[i][2])).ToString();
                lblTT.Text = (Convert.ToInt32(Session["TongTien"]) - Convert.ToInt32(dt.Rows[i][4])).ToString();
                dt.Rows[i].Delete();
                Session["GioHang"] = dt;
                Session["TongSL"] = lblSL.Text;
                Session["TongTien"] = lblTT.Text;
            }
            GridView1.DataSource = (DataTable)Session["GioHang"];
            GridView1.DataBind();
            lblTongCong.Text = "Total: " + Session["TongTien"].ToString() + "$";
        }
        catch (Exception ex)
        { 
        
        }
    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["GioHang"];
            int tongSL = 0;
            int tongTien = 0;
            Label lblSL = (Label)this.Master.FindControl("lblSL");
            Label lblTT = (Label)this.Master.FindControl("lblTongTien");
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                TextBox txtSoLuong = (TextBox)GridView1.Rows[i].Cells[3].FindControl("txtSoLuong");
                dt.Rows[i][2] = int.Parse(txtSoLuong.Text);
                tongSL += int.Parse(txtSoLuong.Text);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i][4] = Convert.ToInt32(dt.Rows[i][2]) * Convert.ToInt32(dt.Rows[i][3]);
                tongTien += Convert.ToInt32(dt.Rows[i][4]);
            }
            Session["GioHang"] = dt;
            Session["TongTien"] = tongTien;
            Session["TongSL"] = tongSL;
            lblSL.Text = Session["TongSL"].ToString();
            lblTT.Text = Session["TongTien"].ToString();
            GridView1.DataSource = (DataTable)Session["GioHang"];
            GridView1.DataBind();
            if (Session["TongTien"] != null)
                lblTongCong.Text = "Total: " + Session["TongTien"].ToString() + "$";
        }
        catch (Exception ex)
        {
            
        }
    }
    protected void btnXoa_Click(object sender, EventArgs e)
    {
        try
        {
            Session["GioHang"] = null;
            Session["TongTien"] = 0;
            Session["TongSL"] = 0;
            Label lblSL = (Label)this.Master.FindControl("lblSL");
            Label lblTT = (Label)this.Master.FindControl("lblTongTien");
            lblSL.Text = Session["TongSL"].ToString();
            lblTT.Text = Session["TongTien"].ToString();
            GridView1.DataSource = (DataTable)Session["GioHang"];
            GridView1.DataBind();
            if (Session["TongTien"] != null)
                lblTongCong.Text = "Total: " + Session["TongTien"].ToString() + "$";
            btnDatHang.Enabled = false;
        }
        catch (Exception ex)
        { 
        
        }
    }
    protected void btnDatHang_Click(object sender, EventArgs e)
    {
        Response.Redirect("DatHang.aspx");
    }
}